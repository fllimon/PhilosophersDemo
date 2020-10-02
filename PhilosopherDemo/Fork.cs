using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhilosopherDemo
{
    class Fork
    {
        private bool _used;
        private int _forkNumber;
        private object _syncObj = new object();

        public Fork(int forkNumber)
        {
            _forkNumber = forkNumber;
        }

        public bool IsUsingForks
        {
            get
            {
                lock (_syncObj)
                {
                    return _used;
                }
            }
            set
            {
                lock (_syncObj)
                {
                    _used = value;
                }
            }
        }

        public int ForkNumber
        {
            get 
            {
                return _forkNumber;
            }
        }

    }
}
