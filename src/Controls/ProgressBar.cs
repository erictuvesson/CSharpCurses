namespace CSharpCurses.Controls
{
    using System;
    using System.Diagnostics;

    public class ProgressBar : Widget
    {
        public float Progress
        {
            get => progress;
            set
            {
                var newValue = Math.Min(Math.Max(value, 0.0f), 1.0f);
                if (progress != newValue)
                {
                    progress = newValue;
                    requireDraw = true;
                }
            }
        }
        private float progress = 0.0f;

        public int Width
        {
            get => width;
            set
            {
                if (width != value)
                {
                    width = value;
                    requireDraw = true;
                }
            }
        }
        private int width; 

        public ProgressBar(int x, int y, int w)
            : base(x, y)
        {
            Debug.Assert(w > 3);

            this.Width = w;
        }

        protected override void OnDraw(int x, int y)
        {
            base.OnDraw(x, y);

            Console.SetCursorPosition(x, y);

            Console.Write("[");

            // Width - Border - Text
            int progressWidth = Width - 2 - 5;
            int progressLength = (int)(progressWidth * progress);

            Console.Write(new string('=', progressLength) + new string(' ', progressWidth - progressLength));

            //Console.BackgroundColor = ConsoleColor.Gray;
            //Console.Write(new string(' ', progressLength));
            //
            //Console.BackgroundColor = Background ?? ConsoleColor.Black; // TODO: Get Default BackgroundColor
            //Console.Write(new string(' ', progressWidth - progressLength));

            Console.Write("] " + string.Format("{0:P0}", progress).EnsureLengthS(' ', 4)); // "100%"
        }
    }
}
