namespace CSharpCurses
{
    using CSharpCurses.Controls;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    
    public static class Terminal
    {
        static List<Container> containers = new List<Container>();

        public static int Columns => Console.BufferWidth;
        public static int Rows => Console.BufferHeight;

        public static ConsoleColor DefaultBackgroundColor { get; }
        public static ConsoleColor DefaultForegroundColor { get; }

        static Terminal()
        {
            DefaultBackgroundColor = Console.BackgroundColor;
            DefaultForegroundColor = Console.ForegroundColor;

            Console.BufferHeight = Console.WindowHeight;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.TreatControlCAsInput = true;
        }

        #region Write Methods
        public static bool Write(int x, int y, string str)
        {
            if (x >= 0 && x < Terminal.Columns && 
                y >= 0 && y < Terminal.Rows)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(str);
                return true;
            }
            return false;
        }

        public static void WriteVertical(int x, int y, string[] str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                Write(x, y + i, str[i]);
            }
        }
        #endregion

        public static void Run(int delay, Action tick)
        {
            if (tick == null) throw new ArgumentNullException(nameof(tick));

            bool running = true;
            RunLoop(running, delay, tick);
        }

        public static void Run(Container container, Action update = null, Action<ConsoleKeyInfo> keyDown = null)
        {
            if (container == null) throw new ArgumentNullException(nameof(container));

            containers.Add(container);

            container.Redraw();
            Screen.Redraw();

            Screen.Refresh();

            RunLoop(container.Running, 10, () =>
            {
                update?.Invoke();

                container.Update();
                container.Draw();
            }, keyDown);

            Screen.Clear();
        }
        
        private static void RunLoop(bool running, int delay, Action tick, Action<ConsoleKeyInfo> keyDown = null)
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    var keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.Escape ||
                        keyInfo.Key == ConsoleKey.C && keyInfo.Modifiers.HasFlag(ConsoleModifiers.Control))
                    {
                        break;
                    }
                    else
                    {
                        keyDown?.Invoke(keyInfo);
                    }
                }
                running = false;
            });

            while (running)
            {
                tick();
                System.Threading.Thread.Sleep(delay);
            }
        }

        static class Screen
        {
            public static void Clear() { }
            public static void Refresh() { }
            public static void Redraw() { }
        }
    }
}
