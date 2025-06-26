using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _01_SinoTheWalker
{
    internal class Program
    {
        static void Main(string[] args)
        {
          
                DateTime time = DateTime.ParseExact(Console.ReadLine(),
                    "HH:mm:ss",
                    CultureInfo.InvariantCulture);

                BigInteger steps = BigInteger.Parse(Console.ReadLine()) % 86400;
                BigInteger timeInSeconds = BigInteger.Parse(Console.ReadLine()) % 86400;

            BigInteger totalTimeNeeded = steps * timeInSeconds;

                var finalTime = time.AddSeconds((double)totalTimeNeeded);

                Console.WriteLine("Time Arrival: {0:HH:mm:ss}",finalTime);
            
        }
    }
}
