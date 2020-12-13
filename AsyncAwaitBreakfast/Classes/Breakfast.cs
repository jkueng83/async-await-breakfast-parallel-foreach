using AsyncAwaitBreakfast.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitBreakfest.Classes
{
    public class Breakfast
    {

        public static Coffee PourCoffee()
        {
            Console.WriteLine("Pour Coffee...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Coffee is finish");

            return new Coffee();
        }

        public static Juice PourJuice()
        {
            Console.WriteLine("Pour Juice...");
            Task.Delay(2000).Wait();
            Console.WriteLine("Juice is finish");

            return new Juice();
        }

        public static Bacon FryBacon(int quantity)
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

        public static async Task<Bacon> FryBaconAsync(int quantity)
        {
            Console.WriteLine($"Putting {quantity} slices of bacon in the pan");
            Console.WriteLine("Cooking first side of bacon...");
            await Task.Delay(3000);

            for (int i = 1; i <= quantity; i++)
            {
                Console.WriteLine($"flipping {i}. slice of bacon");
            }

            Console.WriteLine("Cooking second side of bacon...");
            await Task.Delay(3000);
            Console.WriteLine("Put bacon on plate");

            return new Bacon(quantity);
        }

        public static Bacon EatBacon(ref Bacon bacon, int quantityEat)
        {
            bacon.EatBacon(quantityEat);

            return bacon;
        }

        public static Eggs FryEggs(int quantity)
        {
            Console.WriteLine($"Putting {quantity} eggs in the pan");
            Console.WriteLine("Cooking eggs...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put eggs on plate");

            return new Eggs();
        }

        public static async Task<Eggs> FryEggsAsync(int quantity)
        {
            Console.WriteLine($"Putting {quantity} eggs in the pan");
            Console.WriteLine("Cooking eggs...");
            await Task.Delay(3000);
            Console.WriteLine("Put eggs on plate");

            return new Eggs();
        }

        public static Toast[] ToastBread(int quantity)
        {

            Console.WriteLine($"Take {quantity} slices of toast bread");

            Task.Delay(500 * quantity).Wait();

            Toast[] toasts = new Toast[quantity];

            for (int i = 0; i < quantity; i += 2)
            {
                Console.WriteLine($"Toasting slice {i + 1} of {quantity}");
                toasts[i] = new Toast();

                if (i + 2 <= quantity)
                {
                    Console.WriteLine($"Toasting slice {i + 2} of {quantity}");
                    toasts[i + 1] = new Toast();
                }
                
                Task.Delay(3000).Wait();
            }

            return toasts;
        }

        public static async Task<Toast[]> ToastBreadAsync(int quantity)
        {
            Console.WriteLine($"Take {quantity} slices of toast bread");

            await Task.Delay(500 * quantity);

            Toast[] toasts = new Toast[quantity];

            for (int i = 0; i < quantity; i += 2)
            {
                Console.WriteLine($"Toasting slice {i + 1} of {quantity}");
                toasts[i] = new Toast();

                if (i + 2 <= quantity)
                {
                    Console.WriteLine($"Toasting slice {i + 2} of {quantity}");
                    toasts[i + 1] = new Toast();
                }
                await Task.Delay(3000);
            }

            return toasts;
        }

        public static void ApplyButter(Toast toast) => toast.ApplyButter();

        public static void ApplyJam(Toast toast) => toast.ApplyJam();       
    }
}
