using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhilosopherDemo
{
    class EatPhilosopherEventArgs : EventArgs
    {
        public bool Hungry { get; private set; }

        public EatPhilosopherEventArgs(bool hungry)
        {
            Hungry = hungry;
        }
    }
}
