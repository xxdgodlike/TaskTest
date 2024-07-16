using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TaskTest
{
    public class Code
    {
        public static string StringPractice(string text)
        {
            string pattern = @"\d+(\.\d+)?"; // 匹配整数和小数  

            MatchCollection matches = Regex.Matches(text, pattern);

            string number = matches.Count == 1 ? matches[0].Value : string.Empty;
            if (string.IsNullOrEmpty(number)) 
            {
                return number;
            }

            if (!number.Contains(".")) 
            {
                return number + ".00";
            }
            string[] parts = number.Split('.');
            if (parts[1].Length < 2)
            {
                return parts[0] + "." + parts[1].Substring(0, parts[1].Length) + "0";
            }
            return parts[0] + "." + parts[1].Substring(0, 2);
        }
    }
}
