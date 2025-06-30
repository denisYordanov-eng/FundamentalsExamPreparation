using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03_SantaSecretHelper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Read input.
            int substringKey = int.Parse(Console.ReadLine());
            string inputLine = Console.ReadLine();
           
           Dictionary<string,string> kidsBehaviour = new Dictionary<string,string>();
            while(inputLine != "end")
            {
               string decodedMessage = DecodeInput(substringKey, inputLine);
               string regexPatern = @"@(?<name>[A-Za-z]+)[^.!]*!(?<status>[GN])";

                var matches = Regex.Matches(decodedMessage, regexPatern);

                foreach (Match item in matches)
                {
                    string key = item.Groups["name"].Value;
                    string value = item.Groups["status"].Value;

                    if (!kidsBehaviour.ContainsKey(key))
                    {
                        kidsBehaviour[key] = " ";
                    }
                    kidsBehaviour[key] = value;


                    inputLine = Console.ReadLine();
                }
            }
                //Print output.
                var goodkids = kidsBehaviour.Where(b => b.Value == "G");
            foreach (var kvp in goodkids)
            {
                Console.WriteLine(kvp.Key);
            }
    }

        private static string DecodeInput(int substringKey, string inputLine)
        {
            List<char> chars = new List<char>();
            for (int i = 0; i < inputLine.Length; i++)
            {
                int currentChar = (int)inputLine[i];
                int charToAdd = currentChar - substringKey;

                char newChar = (char)charToAdd;
                chars.Add(newChar);
            }
            string message = new string(chars.ToArray());
            return message;
        }
    }
}
