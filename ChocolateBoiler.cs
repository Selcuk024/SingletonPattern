using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Singleton
{
    internal class ChocolateBoiler
    {
        private bool empty;
        private bool boiled;
        private static ChocolateBoiler instance = null;
        private static readonly object lockObject = new object();
        private ChocolateBoiler()
        {
            empty = true;
            boiled = false;
        }

        public static ChocolateBoiler GetInstance()
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new ChocolateBoiler();
                    }
                }
            }
            return instance;
        }

        public bool IsEmpty { get { return this.empty; } }
        public bool IsBoiled { get { return this.boiled; } }
        public void Fill()
        {
            if (empty)
            {
                empty = false;
                boiled = false;
            }
        }
        public void Drain()
        {
            if (!empty && boiled)
            {
                empty = true;
            }
        }
        public void Boil()
        {
            if (!empty && !boiled)
            {
                boiled = true;
            }
        }
    }
}
