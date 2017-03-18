namespace CSharpCurses.Test.Tests
{
    using CSharpCurses;
    using CSharpCurses.Controls;
    using System;

    class ClockTest : Test
    {
        private string previousTimeText = new string(' ', 4);

        private readonly string[][] numbers = new string[][] { Zero, One, Two, Three, Four, Five, Six, Seven, Eight, Nine };

        public ClockTest()
            : base("Clock Test", "")
        {

        }

        protected override void Initialize(Container container)
        {

        }

        public override void Update()
        {
            var currentTimeText = DateTime.Now.ToString("HHssmm");

            System.Diagnostics.Debug.WriteLine(currentTimeText);

            int i = 2;
            if (currentTimeText[0] != previousTimeText[0])
                Terminal.WriteVertical(i, 2, IntToStr(currentTimeText[0]));

            i += 15;
            if (currentTimeText[1] != previousTimeText[1])
                Terminal.WriteVertical(i, 2, IntToStr(currentTimeText[1]));

            i += 2;

            i += 15;
            if (currentTimeText[2] != previousTimeText[2])
                Terminal.WriteVertical(i, 2, IntToStr(currentTimeText[2]));

            i += 15;
            if (currentTimeText[3] != previousTimeText[3])
                Terminal.WriteVertical(i, 2, IntToStr(currentTimeText[3]));

            previousTimeText = currentTimeText;
        }

        private string[] IntToStr(char cIndex)
        {
            switch (cIndex)
            {
                default:
                case '0': return Zero;
                case '1': return One;
                case '2': return Two;
                case '3': return Three;
                case '4': return Four;
                case '5': return Five;
                case '6': return Six;
                case '7': return Seven;
                case '8': return Eight;
                case '9': return Nine;
            }
        }

        static readonly string[] Zero = new[]
        {
            "  XXXXXXXX  ",
            " XX      XX ",
            "XX        XX",
            "XX        XX",
            "XX        XX",
            "XX        XX",
            "XX        XX",
            "XX        XX",
            "XX        XX",
            "XX        XX",
            " XX      XX ",
            "  XXXXXXXX  ",
        };
        static readonly string[] One = new[]
        {
            "      XX    ",
            "   XXXXX    ",
            "      XX    ",
            "      XX    ",
            "      XX    ",
            "      XX    ",
            "      XX    ",
            "      XX    ",
            "      XX    ",
            "      XX    ",
            "      XX    ",
            "  XXXXXXXXX ",
        };
        static readonly string[] Two = new[]
        {
            "   XXXXXXX  ",
            " XXX    XXX ",
            "XX        XX",
            "          XX",
            "        XXX ",
            "      XXX   ",
            "    XXX     ",
            "  XXX       ",
            " XX         ",
            "XX          ",
            "XX          ",
            "XXXXXXXXXXXX",
        };
        static readonly string[] Three = new[]
        {
            "   XXXXXXX  ",
            " XXX    XXX ",
            "XX        XX",
            "          XX",
            "        XXX ",
            "     XXXX   ",
            "        XXX ",
            "          XX",
            "          XX",
            "XX        XX",
            " XXX    XXX ",
            "   XXXXXX   ",
        };
        static readonly string[] Four = new[]
        {
            "       XXXXX",
            "      XX  XX",
            "     XX   XX",
            "    XX    XX",
            "   XX     XX",
            "  XX      XX",
            " XXXXXXXXXXX",
            "          XX",
            "          XX",
            "          XX",
            "          XX",
            "          XX",
        };
        static readonly string[] Five = new[]
        {
            " XXXXXXXXXXX",
            "XX          ",
            "XX          ",
            "XX          ",
            "XX          ",
            "XX          ",
            "XXXXXXXXXX  ",
            "         XX ",
            "          XX",
            "          XX",
            "         XX ",
            "XXXXXXXXX   ",
        };
        static readonly string[] Six = new[]
        {
            " XXXXXXXXXXX",
            "XX          ",
            "XX          ",
            "XX          ",
            "XX          ",
            "XXXXXXXXXX  ",
            "XX       XX ",
            "XX        XX",
            "XX        XX",
            "XX        XX",
            " XX      XX ",
            "  XXXXXXXX  ",
        };
        static readonly string[] Seven = new[]
        {
            "XXXXXXXXXXXX",
            "          XX",
            "          XX",
            "         XX ",
            "        XX  ",
            "       XX   ",
            "      XX    ",
            "     XX     ",
            "    XX      ",
            "   XX       ",
            "  XX        ",
            " XX         ",
        };
        static readonly string[] Eight = new[]
        {
            "  XXXXXXXX  ",
            " XX      XX ",
            "XX        XX",
            "XX        XX",
            " XX      XX ",
            "  XXXXXXXX  ",
            " XX      XX ",
            "XX        XX",
            "XX        XX",
            "XX        XX",
            " XX      XX ",
            "  XXXXXXXX  ",
        };
        static readonly string[] Nine = new[]
        {
            "  XXXXXXXX  ",
            " XX      XX ",
            "XX        XX",
            "XX        XX",
            " XX       XX",
            "  XXXXXXXXXX",
            "          XX",
            "          XX",
            "          XX",
            "          XX",
            "          XX",
            "          XX",
        };
    }
}
