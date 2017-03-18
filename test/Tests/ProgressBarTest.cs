namespace CSharpCurses.Test.Tests
{
    using CSharpCurses;
    using CSharpCurses.Controls;
    using System;
    using System.Linq;

    class ProgressBarTest : ModelTest
    {
        const int taskCount = 10;

        private ProgressBar[] taskProgressBars = new ProgressBar[taskCount];
        private Label[] taskLabels = new Label[taskCount];

        private bool taskRunning = false;

        private Random rng = new Random();

        public ProgressBarTest()
            : base("ProgressBar Test", "Testing the progressbar gui!")
        {

        }

        protected override void Initialize(Container container)
        {
            StatusLabel.Text = "Waiting... Press ENTER to start.";

            for (int i = 0; i < taskCount; i++)
            {
                container.Add(taskProgressBars[i] = new ProgressBar(10, i, TextLength - 11));
                container.Add(taskLabels[i] = new Label(0, i, StringExtensions.New($"Task #{ i + 1 }", 10)));
            }
        }

        public override void Update()
        {
            if (taskRunning)
            {
                int index = rng.Next(0, 10);
                taskProgressBars[index].Progress += 0.01f;
                if (taskProgressBars[index].Progress == 1.0f)
                {
                    taskProgressBars[index].Background = ConsoleColor.DarkGreen;
                    taskLabels[index].Background = ConsoleColor.DarkGreen;
                }

                if (taskProgressBars.Where(e => e.Progress == 1.0f).Count() == taskCount) // TODO: Bad lol
                {
                    StatusLabel.Text = "Completed!";
                    StatusLabel.Foreground = ConsoleColor.Green;
                }
            }
        }

        public override void KeyDown(ConsoleKeyInfo keyInfo)
        {
            if (keyInfo.Key == ConsoleKey.Enter) // && !taskRunning)
            {
                // TODO: Clear part
                //gui.Remove(startLabel);
                //startLabel.Text = new string(' ', TextLength);

                StatusLabel.Text = "Running...";
                StatusLabel.Foreground = ConsoleColor.Yellow;
                taskRunning = true;
            }
        }
    }
}
