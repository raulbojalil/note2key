using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;

namespace Note2Key
{
    public partial class Form1 : Form
    {
        private InputSimulator inputSimulator;
        private string tempText;

        private Dictionary<Note, VirtualKeyCode> KeyMappings = new Dictionary<Note, VirtualKeyCode>
        {
            { Note.A0, VirtualKeyCode.VK_A },
            { Note.ASharp0, VirtualKeyCode.VK_B },
            { Note.B0, VirtualKeyCode.VK_C },

            { Note.C1, VirtualKeyCode.VK_D },
            { Note.CSharp1, VirtualKeyCode.VK_E },
            { Note.D1, VirtualKeyCode.VK_F },
            { Note.DSharp1, VirtualKeyCode.VK_G },
            { Note.E1, VirtualKeyCode.VK_H },
            { Note.F1, VirtualKeyCode.VK_I },
            { Note.FSharp1, VirtualKeyCode.VK_J },
            { Note.G1, VirtualKeyCode.VK_K },
            { Note.GSharp1, VirtualKeyCode.VK_L },
            { Note.A1, VirtualKeyCode.VK_M },
            { Note.ASharp1, VirtualKeyCode.VK_N },
            { Note.B1, VirtualKeyCode.VK_O },

            { Note.C2, VirtualKeyCode.VK_P },
            { Note.CSharp2, VirtualKeyCode.VK_Q },
            { Note.D2, VirtualKeyCode.VK_R },
            { Note.DSharp2, VirtualKeyCode.VK_S },
            { Note.E2, VirtualKeyCode.VK_T },
            { Note.F2, VirtualKeyCode.VK_U },
            { Note.FSharp2, VirtualKeyCode.VK_V },
            { Note.G2, VirtualKeyCode.VK_W },
            { Note.GSharp2, VirtualKeyCode.VK_X },
            { Note.A2, VirtualKeyCode.VK_Y },
            { Note.ASharp2, VirtualKeyCode.VK_Z },
            { Note.B2, VirtualKeyCode.VK_1 },

            { Note.C3, VirtualKeyCode.VK_2 },
            { Note.CSharp3, VirtualKeyCode.VK_3 },
            { Note.D3, VirtualKeyCode.VK_4 },
            { Note.DSharp3, VirtualKeyCode.VK_5 },
            { Note.E3, VirtualKeyCode.VK_6 },
            { Note.F3, VirtualKeyCode.VK_7 },
            { Note.FSharp3, VirtualKeyCode.VK_8 },
            { Note.G3, VirtualKeyCode.VK_9 },
            { Note.GSharp3, VirtualKeyCode.VK_0 },
            { Note.A3, VirtualKeyCode.UP },
            { Note.ASharp3, VirtualKeyCode.DOWN },
            { Note.B3, VirtualKeyCode.LEFT },

            { Note.C4, VirtualKeyCode.RIGHT },
            { Note.CSharp4, VirtualKeyCode.SPACE },
            { Note.D4, VirtualKeyCode.BACK },
            { Note.DSharp4, VirtualKeyCode.RETURN },
            { Note.E4, VirtualKeyCode.ESCAPE },
            { Note.F4, VirtualKeyCode.INSERT },
            { Note.FSharp4, VirtualKeyCode.DELETE },
            { Note.G4, VirtualKeyCode.HOME },
            { Note.GSharp4, VirtualKeyCode.END },
            { Note.A4, VirtualKeyCode.PRIOR },
            { Note.ASharp4, VirtualKeyCode.NEXT },
            { Note.B4, VirtualKeyCode.DIVIDE },

            { Note.C5, VirtualKeyCode.MULTIPLY },
            { Note.CSharp5, VirtualKeyCode.SUBTRACT },
            { Note.D5, VirtualKeyCode.ADD },
            { Note.DSharp5, VirtualKeyCode.OEM_COMMA },
            { Note.E5, VirtualKeyCode.OEM_PERIOD },
            { Note.F5, VirtualKeyCode.SHIFT },
            { Note.FSharp5, VirtualKeyCode.CONTROL },
            { Note.G5, VirtualKeyCode.MENU },
            { Note.GSharp5, VirtualKeyCode.TAB },

        };

        public Form1()
        {
            InitializeComponent();
            tempText = lblNoteName.Text;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnStop.Enabled = false;

            int waveInDevices = WaveIn.DeviceCount;

            if (waveInDevices > 0)
            {
                for (int index = 0; index < waveInDevices; index++)
                {
                    WaveInCapabilities deviceInfo = WaveIn.GetCapabilities(index);
                    cmbRecordingDevice.Items.Add(deviceInfo.ProductName);
                }

                inputSimulator = new InputSimulator();
                Keyboard.KeyPressed += Keyboard_KeyPressed;
                Keyboard.VolumeChanged += Keyboard_VolumeChanged;
                Keyboard.Stopped += Keyboard_Stopped;
            }
            else
            {
                MessageBox.Show("No recording devices found!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbRecordingDevice.Items.Add("No recording devices found");
                cmbRecordingDevice.Enabled = false;
                btnStart.Enabled = false;
            }

            cmbRecordingDevice.SelectedIndex = 0;
        }

        void Keyboard_Stopped(object sender, EventArgs e)
        {
            pgbVolume.Value = 0;
            btnStart.Enabled = true;
            cmbRecordingDevice.Enabled = true;
            lblNoteName.Enabled = false;
            lblNoteName.Text = tempText;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (WaveIn.DeviceCount > 0)
            {
                try
                {
                    Keyboard.StartListening((int)cmbRecordingDevice.SelectedIndex);
                    btnStop.Enabled = true;
                    btnStart.Enabled = false;
                    cmbRecordingDevice.Enabled = false;
                    lblNoteName.Enabled = true;
                }
                catch (Exception ex)
                {
                    Keyboard.StopListening();
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Keyboard.StopListening();
            btnStop.Enabled = false;
        }

        void Keyboard_VolumeChanged(int volume)
        {
            pgbVolume.Value = volume;
        }

        void Keyboard_KeyPressed(Note note, double frequency)
        {
            if (KeyMappings.ContainsKey(note))
                inputSimulator.Keyboard.KeyDown(KeyMappings[note]);

            lblNoteName.Text = string.Format("{0} ({1} Hz)", Utils.GetNoteName(note), frequency);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Keyboard.StopListening();
        }

    }
}
