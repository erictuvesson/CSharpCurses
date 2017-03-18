namespace CSharpCurses.Controls
{
    public class ScrollingLabel : Label
    {
        public int Ticks { get; set; }
        public bool MoveRight { get; set; }

        private int currentTicks = 0;

        public ScrollingLabel(int x, int y, string text, bool moveRight = false, int ticks = 30)
            : base(x, y, text)
        {
            this.MoveRight = moveRight;
            this.Ticks = ticks;
        }

        public override void Update()
        {
            currentTicks++;
            if (currentTicks > Ticks)
            {
                currentTicks -= Ticks;
                if (MoveRight)
                {
                    Text = Text.MoveRight();
                }
                else
                {
                    Text = Text.MoveLeft();
                }
            }
            base.Update();
        }
    }
}
