using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace _02_SoftUniKaraoke
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Read Input.
            string patern = @",\s+";
            string[] singers = (Regex.Split(Console.ReadLine(), patern))
                .ToArray();


            string[] songs = Regex.Split(Console.ReadLine(), patern);

            Dictionary<string, HashSet<string>> dict = new Dictionary<string, HashSet<string>>();

            string inputline = Console.ReadLine();
            while (inputline != "dawn")
            {
                string[] input = Regex.Split(inputline, patern)
                    .ToArray();

                string currentSinger = input[0];
                string songName = input[1];
                string award = input[2];

                if (singers.Contains(currentSinger) &&
                    songs.Contains(songName))
                {
                    if (!dict.ContainsKey(currentSinger))
                    {
                        dict[currentSinger] = new HashSet<string>();
                    }
                    dict[currentSinger].Add(award);
                }


                inputline = Console.ReadLine();
            }
            // PrintOutput.
            if (dict.Count > 0)
            {
                foreach (var singer in dict.OrderByDescending(a => a.Value.Count))
                {
                    Console.WriteLine($"{singer.Key}: {singer.Value.Count} awards");
                    foreach (var award in singer.Value.OrderBy(a => a))
                    {
                        Console.WriteLine($"--{award}");
                    }
                }
            }
            else
            {
                Console.WriteLine("No awards");
            }
        }
    }
}
