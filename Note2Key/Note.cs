using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note2Key
{
    public enum Note
    {
        [NoteName("?")]
        Unknown,

        [NoteName("C0")]
        C0,
        [NoteName("C#0 / Db0")]
        CSharp0,
        [NoteName("D0")]
        D0,
        [NoteName("D#0/Eb0")]
        DSharp0,
        [NoteName("E0")]
        E0,
        [NoteName("F0")]
        F0,
        [NoteName("F#0 / Gb0")]
        FSharp0,
        [NoteName("G0")]
        G0,
        [NoteName("G#0 / Ab0")]
        GSharp0,
        [NoteName("A0")]
        A0,
        [NoteName("A#0 / Bb0")]
        ASharp0,
        [NoteName("B0")]
        B0,

        [NoteName("C1")]
        C1,
        [NoteName("C#1 / Db1")]
        CSharp1,
        [NoteName("D1")]
        D1,
        [NoteName("D#1 / Eb1")]
        DSharp1,
        [NoteName("E1")]
        E1,
        [NoteName("F1")]
        F1,
        [NoteName("F#1 / Gb1")]
        FSharp1,
        [NoteName("G1")]
        G1,
        [NoteName("G#1 / Ab1")]
        GSharp1,
        [NoteName("A1")]
        A1,
        [NoteName("A#1 / Bb1")]
        ASharp1,
        [NoteName("B1")]
        B1,

        [NoteName("C2")]
        C2,
        [NoteName("C#2 / Db2")]
        CSharp2,
        [NoteName("D2")]
        D2,
        [NoteName("D#2 / Eb2")]
        DSharp2,
        [NoteName("E2")]
        E2,
        [NoteName("F2")]
        F2,
        [NoteName("F#2 / Gb2")]
        FSharp2,
        [NoteName("G2")]
        G2,
        [NoteName("G#2 / Ab2")]
        GSharp2,
        [NoteName("A2")]
        A2,
        [NoteName("A#2 / Bb2")]
        ASharp2,
        [NoteName("B2")]
        B2,

        [NoteName("C3")]
        C3,
        [NoteName("C#3 / Db3")]
        CSharp3,
        [NoteName("D3")]
        D3,
        [NoteName("D#3 / Eb3")]
        DSharp3,
        [NoteName("E3")]
        E3,
        [NoteName("F3")]
        F3,
        [NoteName("F#3 / Gb3")]
        FSharp3,
        [NoteName("G3")]
        G3,
        [NoteName("G#3 / Ab3")]
        GSharp3,
        [NoteName("A3")]
        A3,
        [NoteName("A#3 / Bb3")]
        ASharp3,
        [NoteName("B3")]
        B3,

        [NoteName("C4")]
        C4,
        [NoteName("C#4 / Db4")]
        CSharp4,
        [NoteName("D4")]
        D4,
        [NoteName("D#4 / Eb4")]
        DSharp4,
        [NoteName("E4")]
        E4,
        [NoteName("F4")]
        F4,
        [NoteName("F#4 / Gb4")]
        FSharp4,
        [NoteName("G4")]
        G4,
        [NoteName("G#4 / Ab4")]
        GSharp4,
        [NoteName("A4")]
        A4,
        [NoteName("A#4 / Bb4")]
        ASharp4,
        [NoteName("B4")]
        B4,

        [NoteName("C5")]
        C5,
        [NoteName("C#5 / Db5")]
        CSharp5,
        [NoteName("D5")]
        D5,
        [NoteName("D#5 / Eb5")]
        DSharp5,
        [NoteName("E5")]
        E5,
        [NoteName("F5")]
        F5,
        [NoteName("F#5 / Gb5")]
        FSharp5,
        [NoteName("G5")]
        G5,
        [NoteName("G#5 / Ab5")]
        GSharp5,
        [NoteName("A5")]
        A5,
        [NoteName("A#5 / Bb5")]
        ASharp5,
        [NoteName("B5")]
        B5,

        [NoteName("C6")]
        C6,
        [NoteName("C#6 / Db6")]
        CSharp6,
        [NoteName("D6")]
        D6,
        [NoteName("D#6 / Eb6")]
        DSharp6,
        [NoteName("E6")]
        E6,
        [NoteName("F6")]
        F6,
        [NoteName("F#6 / Gb6")]
        FSharp6,
        [NoteName("G6")]
        G6,
        [NoteName("G#6 / Ab6")]
        GSharp6,
        [NoteName("A6")]
        A6,
        [NoteName("A#6 / Bb6")]
        ASharp6,
        [NoteName("B6")]
        B6,

        [NoteName("C7")]
        C7,
        [NoteName("C#7 / Db7")]
        CSharp7,
        [NoteName("D7")]
        D7,
        [NoteName("D#7 / Eb7")]
        DSharp7,
        [NoteName("E7")]
        E7,
        [NoteName("F7")]
        F7,
        [NoteName("F#7 / Gb7")]
        FSharp7,
        [NoteName("G7")]
        G7,
        [NoteName("G#7 / Ab7")]
        GSharp7,
        [NoteName("A7")]
        A7,
        [NoteName("A#7 / Bb7")]
        ASharp7,
        [NoteName("B7")]
        B7,

        [NoteName("C8")]
        C8,
        [NoteName("C#8 / Db8")]
        CSharp8,
        [NoteName("D8")]
        D8,
        [NoteName("D#8 / Eb8")]
        DSharp8,
        [NoteName("E8")]
        E8,
        [NoteName("F8")]
        F8,
        [NoteName("F#8 / Gb8")]
        FSharp8,
        [NoteName("G8")]
        G8,
        [NoteName("G#8 / Ab8")]
        GSharp8,
        [NoteName("A8")]
        A8,
        [NoteName("A#8 / Bb8")]
        ASharp8,
        [NoteName("B8")]
        B8
    }

    public class NoteName : Attribute
    {
        private string _name;

        public NoteName(string name)
        {
            _name = name;
        }

        public string Name
        {
            get { return _name; }
        }
    }
}
