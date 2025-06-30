using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _02SantaGifts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());

            List<int> listOfInt = Console.ReadLine()
                .Split(new[] { ' ' }, 
                StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToList();

            int currentIndex = 0;
            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string currentCommand = command[0];

                if (currentCommand == "Forward")
                {
                    int steps = int.Parse(command[1]);
                   currentIndex = Move(listOfInt ,steps,currentIndex);
                   
                }
                else if(currentCommand == "Back")
                {
                    int steps = int.Parse (command[1]);
                    steps *= -1;
                   currentIndex = Move(listOfInt ,steps, currentIndex);
                   
                }
                else if(currentCommand == "Gift")
                {
                    int index = int.Parse(command[1]);
                    int  value = int.Parse(command[2]);
                    currentIndex = MakeAGift(listOfInt, index, value,currentIndex);
                }
                else if (currentCommand == "Swap")
                {
                    int value1 = int.Parse(command[1]);
                    int value2 = int.Parse(command[2]);
                    listOfInt = SwapElements(listOfInt, value1, value2);

                }
            }
            //Print ouput.
            Console.WriteLine($"Position: {currentIndex}");
            Console.WriteLine(string.Join (", ", listOfInt));
        }

        private static List<int> SwapElements(List<int> listOfInt, int value1, int value2)
        {
            int index1 = listOfInt.IndexOf (value1);

            int index2 = listOfInt.IndexOf (value2);

            listOfInt.RemoveAt (index1);
            listOfInt.Insert (index1, value2);

            listOfInt.RemoveAt(index2);
            listOfInt.Insert(index2, value1);
            return listOfInt;
        }

        private static int MakeAGift(List<int> listOfInt, int index, int value, int currentIndex)
        {
           if(index < 0 || index > listOfInt.Count)
            {
                return currentIndex;
            }
            listOfInt.Insert(index, value);
            currentIndex = index;
            return currentIndex;
        }

        private static int Move(List<int> listOfInt, int steps, int currentIndex)
        {
            int newIndex = currentIndex + steps;
            if (newIndex < 0 || newIndex >= listOfInt.Count)
            {
                return currentIndex; // Return the same index.
            }
            
            listOfInt.RemoveAt(newIndex);
             int currentValue = listOfInt.ElementAt(newIndex);
            currentIndex = listOfInt.IndexOf(currentValue);
            return currentIndex; // Return new index.
        }
    }
}
