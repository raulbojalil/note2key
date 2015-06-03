using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note2Key
{
    public delegate void KeyPressedDelegate(Note note, double frequency);
    public delegate void VolumeChangedDelegate(int volume);

    /// <summary>
    /// Represents a musical keyboard connected to a Mic/Line-in jack (not to be confused by a computer keyboard)
    /// </summary>
    public class Keyboard
    {
        /// <summary>
        /// Occurs when a key is pressed. Reports the corresponding note and frequency.
        /// </summary>
        public static event KeyPressedDelegate KeyPressed;

        /// <summary>
        /// Raised periodically to inform the user of the max volume (from 0 to 100).
        /// </summary>
        public static event VolumeChangedDelegate VolumeChanged;

        /// <summary>
        /// Occurs when the recording device is stopped
        /// </summary>
        public static event EventHandler Stopped;

        private static WaveIn waveSource = null;
        private static WaveOut waveOut = null;
        private static MeteringSampleProvider meteringProvider = null;
        private static SampleChannel sampleChannel = null;
        private static WaveInProvider waveProvider = null;
        private static bool noteIdentified = false;
        private static float volume = 0;

        private static Note[] notes = { 

        Note.C0, Note.CSharp0, Note.D0, Note.DSharp0, Note.E0, Note.F0, Note.FSharp0, Note.G0, Note.GSharp0, Note.A0, Note.ASharp0, Note.B0, 
        Note.C1, Note.CSharp1, Note.D1, Note.DSharp1, Note.E1, Note.F1, Note.FSharp1, Note.G1, Note.GSharp1, Note.A1, Note.ASharp1, Note.B1, 
        Note.C2, Note.CSharp2, Note.D2, Note.DSharp2, Note.E2, Note.F2, Note.FSharp2, Note.G2, Note.GSharp2, Note.A2, Note.ASharp2, Note.B2, 
        Note.C3, Note.CSharp3, Note.D3, Note.DSharp3, Note.E3, Note.F3, Note.FSharp3, Note.G3, Note.GSharp3, Note.A3, Note.ASharp3, Note.B3, 
        Note.C4, Note.CSharp4, Note.D4, Note.DSharp4, Note.E4, Note.F4, Note.FSharp4, Note.G4, Note.GSharp4, Note.A4, Note.ASharp4, Note.B4, 
        Note.C5, Note.CSharp5, Note.D5, Note.DSharp5, Note.E5, Note.F5, Note.FSharp5, Note.G5, Note.GSharp5, Note.A5, Note.ASharp5, Note.B5,
        Note.C6, Note.CSharp6, Note.D6, Note.DSharp6, Note.E6, Note.F6, Note.FSharp6, Note.G6, Note.GSharp6, Note.A6, Note.ASharp6, Note.B6,
        Note.C7, Note.CSharp7, Note.D7, Note.DSharp7, Note.E7, Note.F7, Note.FSharp7, Note.G7, Note.GSharp7, Note.A7, Note.ASharp7, Note.B7,
        Note.C8, Note.CSharp8, Note.D8, Note.DSharp8, Note.E8, Note.F8, Note.FSharp8, Note.G8, Note.GSharp8, Note.A8, Note.ASharp8, Note.B8

        };

        private static double toneStep = Math.Pow(2, 1.0 / 12);

        /// <summary>
        /// Starts listening the keyboard on the specified recording device
        /// </summary>
        public static void StartListening(int deviceNumber)
        {
            waveSource = new WaveIn();
            waveOut = new WaveOut();

            waveSource.WaveFormat = new WaveFormat(44100, 1);
            waveSource.DeviceNumber = deviceNumber;

            waveSource.DataAvailable += new EventHandler<WaveInEventArgs>(waveSource_DataAvailable);
            waveSource.RecordingStopped += waveSource_RecordingStopped;

            waveProvider = new WaveInProvider(waveSource);
            sampleChannel = new SampleChannel(waveProvider);
            meteringProvider = new MeteringSampleProvider(sampleChannel);
            meteringProvider.StreamVolume += meteringProvider_StreamVolume;

            waveOut.Init(new SampleToWaveProvider(meteringProvider));

            waveSource.StartRecording();
            waveOut.Play();
        }

        /// <summary>
        /// Stops listening the keyboard
        /// </summary>
        public static void StopListening()
        {
            if (waveSource != null)
                waveSource.StopRecording();
        }

        private static void meteringProvider_StreamVolume(object sender, StreamVolumeEventArgs e)
        {
            volume = e.MaxSampleValues[0];
            VolumeChanged((int)(volume * 100));
        }

        private static void waveSource_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (volume < 0.2) 
            { 
                noteIdentified = false; 
                return; 
            }

            if (noteIdentified) return;

            var frequency = Utils.FindFundamentalFrequency(e.Buffer, 44100, 60, 1300);

            noteIdentified = true;

            if (frequency > 0)
            {
                double closestFrequency;
                var note = FindClosestNote(frequency, out closestFrequency);
                

                if(note != Note.Unknown)
                    KeyPressed(note, closestFrequency);
            }
        }

        private static Note FindClosestNote(double frequency, out double closestFrequency)
        {
            closestFrequency = -1;

            //const double initialFrequency = 27.50;
            const double initialFrequency = 16.35;

            int toneIndex = (int)Math.Round(Math.Log(frequency / initialFrequency, toneStep));
            if (toneIndex < 0 || toneIndex >= notes.Length) return Note.Unknown;

            closestFrequency = Math.Pow(toneStep, toneIndex) * initialFrequency;
            return notes[toneIndex];
        }

        private static void waveSource_RecordingStopped(object sender, EventArgs e)
        {
            if (waveSource != null)
            {
                waveSource.Dispose();
                waveOut.Stop();
                waveOut.Dispose();
                waveSource = null;
                Stopped(null, null);
            }
        }

    }
}
