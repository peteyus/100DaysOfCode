namespace CodeWars.Day4
{
    using System;
    using System.Text;

    public class Kata
    {
        public static string PigIt(string str)
        {
            var result = new StringBuilder();

            var words = str.Split(' ');
            foreach (string word in words)
            {
                if (char.IsLetter(word[0]))
                {
                    for (int i = 1; i < word.Length; i++)
                    {
                        result.Append(word[i]);
                    }

                    result.Append($"{word[0]}ay ");
                }
                else
                {
                    result.Append($"{word} ");
                }
            }

            result.Length -= 1;
            return result.ToString();
        }
    }
}
