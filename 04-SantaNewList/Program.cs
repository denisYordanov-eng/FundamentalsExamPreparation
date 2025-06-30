using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04_SantaNewList
{
    internal class Program
    {
       
            static void Main(string[] args)
        {
           string inputline = Console.ReadLine();
            string regexSplitPattern = @"(->)";
            Dictionary<string,int> toysAmount = new Dictionary<string,int>();
            Dictionary<string,int> kidPoints = new Dictionary<string,int>();
            while (inputline != "END")
            {
              string[] input = 
                    Regex.Split(inputline, regexSplitPattern);

                input = input.Where(t => t != "->").ToArray();
                if (input[0] == "Remove")
                {
                    string kidName = input[1];
                    kidPoints.Remove(kidName);
                    inputline = Console.ReadLine();
                    continue;
                }
              
                string name = input[0];
                string toyName = input[1];
                int amount = int.Parse(input[2]);

                if (!kidPoints.ContainsKey(name))
                {
                    kidPoints[name] = 0;
                }
                kidPoints[name] += amount;

                if (!toysAmount.ContainsKey(toyName))
                {
                    toysAmount[toyName] = 0;
                }
                toysAmount[toyName] += amount;

                inputline = Console.ReadLine();
            }
            Console.WriteLine("Children:");
            foreach (var kid in kidPoints.OrderByDescending(p =>p.Value).ThenBy(n =>n.Key))
            {
                string kidName = kid.Key;
                int points = kid.Value;
                Console.WriteLine($"{kidName} -> {points}");
            }

            Console.WriteLine("Presents:");
            foreach (var toys in toysAmount)
            {
                string toyName = toys.Key;
                int quantity = toys.Value;
                Console.WriteLine($"{toyName} -> {quantity}");
            }
        }
    }
}