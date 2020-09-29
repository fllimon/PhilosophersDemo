using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using PhilosopherDemo.Const;

namespace PhilosopherDemo
{
    class Program
    {
        private static List<Philosopher> somePhilosophers = new List<Philosopher>();
        private static List<Fork> forks = new List<Fork>();
        
        static void Main(string[] args)
        {
            for (int i = 0; i < DefaultSetting.DEFAULT_MAX_PHILOSOPHER_COUNT; i++)
            {
                somePhilosophers.Add(new Philosopher((i + 1).ToString(), i));
            }

            for (int i = 0; i < DefaultSetting.DEFAULT_MAX_FORK_COUNT; i++)
            {
                forks.Add(new Fork());
            }

            Thread t1 = new Thread(somePhilosophers[0].Start);
            Thread t2 = new Thread(somePhilosophers[1].Start);
            Thread t3 = new Thread(somePhilosophers[2].Start);
            Thread t4 = new Thread(somePhilosophers[3].Start);
            Thread t5 = new Thread(somePhilosophers[4].Start);

            t1.Start(forks);
            t1.Name = "th1 - Thread";
            PhilosopherAnalyzer analyzer1 = new PhilosopherAnalyzer(somePhilosophers[0]);


            t2.Start(forks);
            t2.Name = "th2 - Thread";
            PhilosopherAnalyzer analyzer2 = new PhilosopherAnalyzer(somePhilosophers[1]);

            t3.Start(forks);
            t3.Name = "th3 - Thread";
            PhilosopherAnalyzer analyzer3 = new PhilosopherAnalyzer(somePhilosophers[2]);

            t4.Start(forks);
            t4.Name = "th4 - Thread";
            PhilosopherAnalyzer analyzer4 = new PhilosopherAnalyzer(somePhilosophers[3]);

            t5.Start(forks);
            t5.Name = "th5 - Thread";
            PhilosopherAnalyzer analyzer5 = new PhilosopherAnalyzer(somePhilosophers[4]);

            t1.Join();
            t2.Join();
            t3.Join();
            t4.Join();
            t5.Join();
        }
    }
}
