namespace CSharpCurses.Controls
{
    using System;

    public class Widget
    {
        public int X { get; set; }
        public int Y { get; set; }

        public ConsoleColor? Foreground
        {
            get => foreground;
            set
            {
                if (foreground != value)
                {
                    foreground = value;
                    requireDraw = true;
                }
            }
        }
        private ConsoleColor? foreground = null;

        public ConsoleColor? Background
        {
            get => background;
            set
            {
                if (background != value)
                {
                    background = value;
                    requireDraw = true;
                }
            }
        }
        private ConsoleColor? background = null;

        protected bool requireDraw = true;

        public Widget(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public void Draw(int x, int y)
        {
            if (requireDraw)
            {
                var previousFg = Console.ForegroundColor;
                var previousBg = Console.BackgroundColor;

                if (foreground.HasValue) Console.ForegroundColor = foreground.Value;
                if (background.HasValue) Console.BackgroundColor = background.Value;

                OnDraw(X + x, Y + y);

                Console.ForegroundColor = previousFg;
                Console.BackgroundColor = previousBg;

                requireDraw = false;
            }
        }

        public virtual void Update()
        {

        }

        protected virtual void OnDraw(int x, int y)
        {

        }
    }
}
