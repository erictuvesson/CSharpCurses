namespace CSharpCurses.Test.Tests
{
    using CSharpCurses;
    using CSharpCurses.Controls;
    using System;

    class ScrollingLabelTest : ModelTest
    {
        public ScrollingLabelTest() 
            : base("Scrolling Label Test", "Testing the scrolling labels!")
        {

        }

        protected override void Initialize(Container container)
        {
            container.Add(new ScrollingLabel(2, 2, StringExtensions.New("Hello World ", TextLength - 4), false, 10) { Background = ConsoleColor.DarkBlue });
            container.Add(new Label(0, 2, "\u221A"));
            container.Add(new Label(TextLength - 1, 2, "\u221A"));

            container.Add(new ScrollingLabel(2, 3, StringExtensions.New("Hello World ", TextLength - 4), true, 10) { Foreground = ConsoleColor.DarkCyan });
            container.Add(new Label(0, 3, "\u221A"));
            container.Add(new Label(TextLength - 1, 3, "\u221A"));
        }
    }
}
