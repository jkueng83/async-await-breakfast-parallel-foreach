using AsyncAwaitBreakfast.Classes;
using AsyncAwaitBreakfest.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitBreakfast
{
    class Program
    {
        static async Task Main(string[] args)
        {
            DateTime startTime;
            DateTime endTime;

            Console.WriteLine("Aufgabe Breakfast");

            if (true)
            {
                Console.WriteLine();
                Console.WriteLine("-----------------------------");
                Console.WriteLine("--- Make normal Breakfast ---");
                Console.WriteLine("-----------------------------");

                startTime = System.DateTime.Now;

                var coffee = Breakfast.PourCoffee();
                var eggs = Breakfast.FryEggs(4);
                var bacon = Breakfast.FryBacon(10);
                var toastBreads = Breakfast.ToastBread(3);

                foreach (var toastBread in toastBreads)
                {
                    Breakfast.ApplyButter(toastBread);
                }

                foreach (var toastBread in toastBreads)
                {
                    Breakfast.ApplyJam(toastBread);
                }

                var juice = Breakfast.PourJuice();

                endTime = System.DateTime.Now;

                var cookingTime = endTime - startTime;

                Console.WriteLine("*** Breakfast is finish!!! It took " + cookingTime + " (hh:mm:ss.ms)");
            }

            if (true)
            {
                Console.WriteLine();
                Console.WriteLine("----------------------------");
                Console.WriteLine("--- Make async Breakfast ---");
                Console.WriteLine("----------------------------");

                startTime = System.DateTime.Now;

                var coffee2 = Breakfast.PourCoffee();// PureCoffe();
                var eggsTask = Breakfast.FryEggsAsync(4); 
                var baconTask = Breakfast.FryBaconAsync(10); 
                var toastTask =  MakeToastWithButterAndJamAsync(3);

                var breakfastTasks = new List<Task> { eggsTask, baconTask, toastTask };
                while (breakfastTasks.Count > 0)
                {
                    Task finishedTask = await Task.WhenAny(breakfastTasks);
                    if (finishedTask == eggsTask)
                    {
                        Console.WriteLine("eggs are ready");
                    }
                    else if (finishedTask == baconTask)
                    {
                        Console.WriteLine("bacon is ready");
                    }
                    else if (finishedTask == toastTask)
                    {
                        Console.WriteLine("toast is ready");
                    }
                    breakfastTasks.Remove(finishedTask);
                }

                Juice juice = Breakfast.PourJuice();

                endTime = System.DateTime.Now;
                var cookingTime = endTime - startTime;

                Console.WriteLine("*** Async Breakfast is finish!!! It took " + cookingTime + " (hh:mm:ss.ms)");
            }

            Console.WriteLine();
            Console.WriteLine("press enter to start Parallel ForEach");
            Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("------------------------");
            Console.WriteLine("--- Parallel ForEach ---");
            Console.WriteLine("------------------------");

            int length = 1000;
            int[] numbers = new int[length];

            for (int i = 0; i < length; i++)
            {
                numbers[i] = i;
            }

            int counter = 0;

            Parallel.ForEach(numbers, (x) =>
            {
                counter++;
                Console.WriteLine("number: " + x + " - counter: " + counter);
            });

            Console.ReadLine();
        }

        static async Task<Toast[]> MakeToastWithButterAndJamAsync(int number)
        {
            var toasts = await Breakfast.ToastBreadAsync(number); 

            foreach (var toast in toasts)
            {
                Breakfast.ApplyButter(toast);
            }

            foreach (var toast in toasts)
            {
                Breakfast.ApplyJam(toast);
            }

            return toasts; 
        }

        static async Task<Coffee> PureCoffe()
        {
            var Coffee = Breakfast.PourCoffee();

            return Coffee;
        }                
    }
}
