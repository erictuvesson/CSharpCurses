namespace CSharpCurses.Controls
{
    using System;

    public class Label : Widget
    {
        public string Text
        {
            get => text;
            set
            {
                if (text != value)
                {
                    // TODO: Clear buffer
                    text = value;
                    requireDraw = true;
                }
            }
        }
        private string text = string.Empty;

        public Label(int x, int y, string text)
            : base(x, y)
        {
            this.Text = text;
        }

        protected override void OnDraw(int x, int y)
        {
            base.OnDraw(x, y);

            Terminal.Write(x, y, Text);
        }
    }
}
