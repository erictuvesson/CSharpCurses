namespace CSharpCurses
{
    public static class StringExtensions
    {
        public static string New(string str, int length)
        {
            return str + new string(' ', length - str.Length);
        }

        public static string EnsureLengthS(this string str, char insert, int length)
        {
            if (str.Length >= length)
                return str;

            return new string(insert, length - str.Length) + str;
        }

        /// <summary>
        /// "Hello World " => "ello World H"
        /// </summary>
        public static string MoveRight(this string str, int count = 1)
        {
            var first = str.Substring(0, count);
            return str.Remove(0, count) + first;
        }

        /// <summary>
        /// "Hello World " => " Hello World"
        /// </summary>
        public static string MoveLeft(this string str, int count = 1)
        {
            var start = str.Length - count;
            var first = str.Substring(start, count);
            return str.Remove(start, count).Insert(0, first);
        }
    }
}
