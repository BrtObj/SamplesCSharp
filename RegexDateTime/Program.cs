using System;
using System.Text.RegularExpressions;

namespace RegexDateTime
{
    class Program
    {
        static void Main(string[] args)
        {

            DateTime dtMin = new DateTime(0001, 01, 01);
            DateTime dtMax = new DateTime(9999, 12, 31);
            Console.WriteLine("Running..");
            while (dtMin < dtMax)
            {
                string curTime = dtMin.ToString("yyyy-MM-dd hh:mm");
                if (!Regex.IsMatch(curTime, "^((?!0000)[0-9]{4}-" +
                                               "((0[1-9]|1[0-2])-(0[1-9]|1[0-9]|2[0-8])|" +
                                               "(0[13-9]|1[0-2])-(29|30)|(0[13578]|1[02])-31)|" +
                                               "([0-9]{2}(0[48]|[2468][048]|[13579][26])|" +
                                               "(0[48]|[2468][048]|[13579][26])00)-02-29)" +
                                               "\\s([01][0-9]|2[0-3]):[0-5][0-9]$"))
                {
                    Console.WriteLine(curTime);
                    break;
                }
                dtMin = dtMin.AddDays(1);
            }
            Console.WriteLine("All passed!");
            Console.ReadKey();
        }
    }
}
