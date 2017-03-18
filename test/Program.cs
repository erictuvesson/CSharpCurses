namespace CSharpCurses.Test
{
    using CSharpCurses.Test.Tests;
    using CSharpCurses;
    using CSharpCurses.Controls;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {
            // adding colors from text, allows for rainbow text
            // "^cFF" == ^x(White|White)
            /*
            var inputTest = "H^cFFello ^cFFW^cFForld";
            var result = Regex.Matches(inputTest, "(\\^c)..");

            foreach (var item in result)
            {

            }*/

            var container = new Container(0, 0, Terminal.Columns, Terminal.Rows);

            int testIndex = 2;
            Test test = null;

            switch (testIndex)
            {
                default:
                case 0:
                    test = new ClockTest();
                    break;

                case 1:
                    test = new ScrollingLabelTest();
                    break;

                case 2:
                    test = new ProgressBarTest();
                    break;
            }

            test.Run(container);

            Terminal.Run(container, test.Update, test.KeyDown);
        }
    }
}