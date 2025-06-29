using System; 


    internal class Program
    {
        static void Main(string[] args)
        {
            long numberOfBatches = long.Parse(Console.ReadLine());

            long totalBoxes = 0;
            for (int i = 0; i < numberOfBatches; i++)
            {
                //Read input.
                int flourInGrams, sugarInGrams, cocoaInGrams;
                ReadInput(out flourInGrams, out sugarInGrams, out cocoaInGrams);


                byte cup = 140;
                byte bigSpoon = 20;
                byte smallSpoon = 10;
                byte singleCookie = 25;
                int cookiesPerBox = 5;

                int flourCups, sugarSpoons, cocoaSpoons;
                CalculateIngredimends(flourInGrams, sugarInGrams, cocoaInGrams, cup, bigSpoon, smallSpoon, out flourCups, out sugarSpoons, out cocoaSpoons);
                long totalCookiesPerBake = CalculateCookiesPerBatch(cup, bigSpoon, smallSpoon, singleCookie, flourCups, sugarSpoons, cocoaSpoons);

               
                if (flourCups <= 0 ||
                    sugarSpoons <= 0 ||
                    cocoaSpoons <= 0)
                {
                    Console.WriteLine("Ingredients are not enough for a box of cookies.");

                }

                else
                {
                    long boxesOfCookies = totalCookiesPerBake / cookiesPerBox;

                    if (boxesOfCookies > 0)
                    {
                        Console.WriteLine("Boxes of cookies: {0:F0}", (boxesOfCookies));
                    }
                    totalBoxes += boxesOfCookies;
                }
            }

            Console.WriteLine("Total boxes: {0:F0}",totalBoxes);
        }

        private static long CalculateCookiesPerBatch(byte cup, byte bigSpoon, byte smallSpoon, byte singleCookie, int flowerCups, int sugarSpoons, int cocoaSpoons)
        {
            return (long)((cup + smallSpoon + bigSpoon) * Math.Min(Math.Min(flowerCups, sugarSpoons), cocoaSpoons) / singleCookie);
        }

        private static void CalculateIngredimends(int flowerInGrams, int sugarInGrams, int cocoaInGrams, byte cup, byte bigSpoon, byte smallSpoon, out int flowerCups, out int sugarSpoons, out int cocoaSpoons)
        {
            flowerCups = flowerInGrams / cup;
            sugarSpoons = sugarInGrams / bigSpoon;
            cocoaSpoons = cocoaInGrams / smallSpoon;
        }

        private static void ReadInput(out int flourInGrams, out int sugarInGrams, out int cocoaInGrams)
        {
            flourInGrams = int.Parse(Console.ReadLine());
            sugarInGrams = int.Parse(Console.ReadLine());
            cocoaInGrams = int.Parse(Console.ReadLine());
        }
    }

