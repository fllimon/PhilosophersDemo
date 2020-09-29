using PhilosopherDemo.Delegate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PhilosopherDemo
{
    class PhilosopherAnalyzer
    {
        private readonly Philosopher _somePhilosopher = null;

        public PhilosopherAnalyzer(Philosopher philosopher)
        {
            _somePhilosopher = philosopher;

            philosopher.Hungry += GetHungryHandler;
            //philosopher.Dead += GetDieHandler;
            philosopher.Think += GetThinkHandler;
        }

        private void GetHungryHandler(object sender, EatPhilosopherEventArgs args)
        {
#if true
            Logger.Log(DateTime.Now, Thread.CurrentThread.Name, $"Философ {_somePhilosopher.PhilosopherName} поел! " +
                       $"-- Статус голода: {_somePhilosopher.IsHungry} -- Статус думает: {_somePhilosopher.IsThink} -- Статус жизни: {_somePhilosopher.IsDead}");

            Console.WriteLine($"Философ {_somePhilosopher.PhilosopherName} поел!");
#endif
        }

        private void GetThinkHandler(object sender, ThinkPhilosopherEventArgs args)
        {
            if (!_somePhilosopher.IsHungry)
            {
#if true
                Logger.Log(DateTime.Now, Thread.CurrentThread.Name, $"Философ {_somePhilosopher.PhilosopherName} думает... " +
                           $"-- Статус голода: {_somePhilosopher.IsHungry} -- Статус думает: {_somePhilosopher.IsThink} -- Статус жизни: {_somePhilosopher.IsDead}");
               
                Console.WriteLine($"Философ {_somePhilosopher.PhilosopherName} думает...");
#endif
            }
        }
    }
}
