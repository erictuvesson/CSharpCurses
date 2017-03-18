namespace CSharpCurses.Controls
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Container : Widget, IEnumerable
    {
        public bool Running = true;

        private List<Widget> widgets = new List<Widget>();

        public Container(int x, int y, int width, int height)
            : base(x, y)
        {

        }

        public void Draw()
        {
            base.Draw(X, Y);
        }

        public virtual void Redraw()
        {
            // Force Redraw everything
        }

        public void Add(Widget item)
        {
            widgets.Add(item);
        }

        public void Remove(Widget item)
        {
            widgets.Remove(item);
        }

        public override void Update()
        {
            // TODO: Improve
            requireDraw = true;

            foreach (var item in widgets)
            {
                item.Update();
            }
            base.Update();
        }

        protected override void OnDraw(int x, int y)
        {
            foreach (var item in widgets)
            {
                item.Draw(X, Y);
            }
            base.OnDraw(x, y);
        }

        public IEnumerator GetEnumerator() => widgets.GetEnumerator();
    }
}
