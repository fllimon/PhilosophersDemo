using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhilosopherDemo
{
    class ThinkPhilosopherEventArgs : EventArgs
    {
        public bool IsThink { get; private set; }

        public ThinkPhilosopherEventArgs(bool isThink)
        {
            IsThink = isThink;
        }
    }
}
