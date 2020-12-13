using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitBreakfest.Classes
{
    public class Toast
    {
        private bool withButter;
        private bool withJam;

        public void ApplyButter()
        {
            Console.WriteLine("Apply Butter on Toast");
            this.withButter = true;
        }

        public void ApplyJam()
        {
            Console.WriteLine("Apply Jam on Toast");
            this.withJam = true;
        }

        public bool ButterApplied
        {
            get
            {
                Console.WriteLine("Apply Butter on Toast");               
                Task.Delay(1000).Wait();
                Console.WriteLine("Butter is on Toast");
                return this.withButter;
            }
        }

        public bool JamApplied
        {
            get
            {
                Console.WriteLine("Apply Jam on Toast");
                Task.Delay(1000).Wait();
                Console.WriteLine("Jam is on Toast");
                return this.withJam;
            }
        }

    }
}
