using System;
using System.Collections.Generic;
using System.Text;

namespace AsyncAwaitBreakfest.Classes
{
    public class Eggs
    {
        int quantity;// List<Egg> eggs;

        public Eggs()
        {
            //  this.eggs = new List<Egg>();
        }
               
        public int Length
        {
            get { return this.quantity; }
        }


        public string Print()
        {
            return this.quantity + " eggs";
        }

    }
}
