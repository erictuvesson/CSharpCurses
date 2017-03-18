namespace CSharpCurses.Test.Tests
{
    using CSharpCurses;
    using CSharpCurses.Controls;
    using System;

    abstract class Test
    {
        public readonly string Title;
        public readonly string Description;

        public Test(string title, string description)
        {
            this.Title = title;
            this.Description = description;
        }

        public virtual void Run(Container container)
        {
            Initialize(container);
        }

        protected abstract void Initialize(Container container);

        public virtual void Update()
        {

        }

        public virtual void KeyDown(ConsoleKeyInfo keyInfo)
        {

        }
    }


    /**
     *     Title 
     *     
     *       Description
     *     
     *     Content
     *     ...
     *     ...
     *     
     *       Status
     *       
     *     [ System ]
     */
    abstract class ModelTest : Test
    {
        public Label TitleLabel { get; private set; }
        public Label StatusLabel { get; private set; }

        public int TextLength => CSharpCurses.Terminal.Columns - 5 * 2;

        public Container ChildContainer { get; private set; }

        public ModelTest(string title, string description)
            : base(title, description)
        {

        }

        public override void Run(Container container)
        {
            container.Add(TitleLabel = new Label(5, 2, Title) { Foreground = ConsoleColor.DarkGray });
            container.Add(new Label(7, 4, Description) { Foreground = ConsoleColor.DarkGray });

            container.Add(ChildContainer = new Container(5, 7, Terminal.Columns - 10, Terminal.Rows - 7));

            container.Add(StatusLabel = new Label(7, Terminal.Rows - 6, string.Empty) { Foreground = ConsoleColor.DarkGray });
            //container.Add(startLabel = new Label(5, Terminal.Rows - 4, StringExtensions.New("Press ENTER to start", TextLength)));
            container.Add(new Label(5, Terminal.Rows - 3, StringExtensions.New("Ctrl-C / ESC to Exit", TextLength)) { Background = ConsoleColor.DarkRed });

            Initialize(ChildContainer);
        }

    }
}
