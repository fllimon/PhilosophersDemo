using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PhilosopherDemo.Delegate;

namespace PhilosopherDemo
{
    class Philosopher
    {
        #region =======------ PRIVATE DATA -------========

        private bool _isHungry = false;
        private bool _isDeath = false;
        private bool _isThink = false;
        private string _philosopherName;
        private int _handForks;
        private int _time;

        private DeathPhilosopher _deathPhilosopher = null;
        private EatPhilosopher _eatPhilosopher = null;
        private ThinkPhilosopher _thinkPhilosopher = null;

        private static object _philosopherObj = new object();

        #endregion

        #region =======------- PROPERTIES -------=======

        public string PhilosopherName
        {
            get
            {
                return _philosopherName;
            }
        }

        public bool IsDead
        {
            get
            {
                return _isDeath;
            }
            private set
            {
                _isDeath = value;
            }
        }

        public bool IsHungry
        {
            get
            {
                return _isHungry;
            }
            private set
            {
                _isHungry = value;
            }
        }

        public bool IsThink
        {
            get
            {
                return _isThink;
            }
            private set
            {
                _isThink = value;
            }
        }

        #endregion

        #region =======------ EVENT'S ---------========

        public event DeathPhilosopher Dead
        {
            add
            {
                _deathPhilosopher += value;
            }
            remove
            {
                _deathPhilosopher -= value;
            }
        }

        public event EatPhilosopher Hungry
        {
            add
            {
                _eatPhilosopher += value;
            }
            remove
            {
                _eatPhilosopher -= value;
            }
        }

        public event ThinkPhilosopher Think
        {
            add
            {
                _thinkPhilosopher += value;
            }
            remove
            {
                _thinkPhilosopher -= value;
            }
        }

        #endregion

        #region ========------- CTOR -------=========

        public Philosopher(string name, int handForks)
        {
            _philosopherName = name;
            _handForks = handForks;
            Dead += GetDieHandler;
        }

        #endregion

        private void GetForks(List<Fork> fork)
        {
            int firstFork = _handForks;
            int secondFork = (_handForks + 1) % (fork.Count - 1);

            if (!fork[firstFork].IsUsingForks && !fork[secondFork].IsUsingForks)
            {
                if (_eatPhilosopher != null)
                {
                    _eatPhilosopher(this, new EatPhilosopherEventArgs(_isHungry));
                }

                _isThink = true;

#if true
                Console.WriteLine($"Философ {_philosopherName} ест вилками {firstFork} - {secondFork}");

                Logger.Log(DateTime.Now, Thread.CurrentThread.Name, $"Философ {_philosopherName} ест вилками {firstFork} - {secondFork} -- " +
                           $"Статус голода: {_isHungry} -- Статус думает: {_isThink} -- Статус жизни: {_isDeath}");
#endif
            }

            if (_thinkPhilosopher != null)
            {
                _thinkPhilosopher(this, new ThinkPhilosopherEventArgs(_isThink));
            }

            if (_deathPhilosopher != null)
            {

                _deathPhilosopher(this, new DeathPhilosopherEventArgs(_time));
            }
        }

        public void Start(object obj)
        {
            if (_isDeath)
            {
                //Thread.CurrentThread.Abort();   // ToDo: Вопрос !!!

                return;
            }

            while (true)
            {
                Thread.Sleep(1000);

                lock (_philosopherObj)
                {
                    _time = DateTime.Now.Millisecond;
                    ChangeStatus();
                    
                    if (_isHungry)
                    {
                        GetForks((List<Fork>)obj);
                    }
                }
            }
        }

        private void ChangeStatus()
        {
            _isThink = false;
            _isHungry = !_isHungry;
        }

        private void GetDieHandler(object sender, DeathPhilosopherEventArgs args)
        {
            if (args.Time > 800)
            {
#if true
                Logger.Log(DateTime.Now, Thread.CurrentThread.Name, $"Философ {_philosopherName} поел! " +
                       $"-- Статус голода: {_isHungry} -- Статус думает: {_isThink} -- Статус жизни: {_isDeath} ");

                Console.WriteLine($"Философ {_philosopherName} умер...");
#endif
                _isDeath = true;
            }
        }
    }
}
