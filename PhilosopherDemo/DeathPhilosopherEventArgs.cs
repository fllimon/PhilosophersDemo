using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhilosopherDemo.Delegate
{
    class DeathPhilosopherEventArgs : EventArgs
    {
        public int Time { get; private set; }

        public DeathPhilosopherEventArgs(int time)
        {
            Time = time;
        }
    }
}
