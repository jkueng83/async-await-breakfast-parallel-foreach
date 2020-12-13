using AsyncAwaitBreakfest.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitBreakfast.Classes
{
    public class BreakfastAsyncAwait
    {
        private static async Task<Bacon> FryBacon(int quantity)
        {
            Console.WriteLine($"Putting {quantity} slices of bacon in the pan");
            Console.WriteLine("Cooking first side of bacon...");
            Task.Delay(3000).Wait();

            for (int i = 1; i <= quantity; i++)
            {
                Console.WriteLine($"flipping {i}. slice of bacon");
            }
            Console.WriteLine("Cooking second side of bacon...");
             Task.Delay(3000).Wait();
            Console.WriteLine("Put bacon on plate");
            return new Bacon(quantity);
        }
    }
}
