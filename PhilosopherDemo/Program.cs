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
        static void Main(string[] args)
        {
            Fork fork1 = new Fork(1);
            Fork fork2 = new Fork(2);
            Fork fork3 = new Fork(3);
            Fork fork4 = new Fork(4);
            Fork fork5 = new Fork(5);

            Philosopher somePhilosopher1 = new Philosopher("Ph1", fork1, fork2);
            Philosopher somePhilosopher2 = new Philosopher("Ph2", fork2, fork3);
            Philosopher somePhilosopher3 = new Philosopher("Ph3", fork3, fork4);
            Philosopher somePhilosopher4 = new Philosopher("Ph4", fork4, fork5);
            Philosopher somePhilosopher5 = new Philosopher("Ph5", fork5, fork1);


            Thread t1 = new Thread(somePhilosopher1.Start);
            Thread t2 = new Thread(somePhilosopher2.Start);
            Thread t3 = new Thread(somePhilosopher3.Start);
            Thread t4 = new Thread(somePhilosopher4.Start);
            Thread t5 = new Thread(somePhilosopher5.Start);

            t1.Start();
            t1.Name = "th1 - Thread";
            PhilosopherAnalyzer analyzer1 = new PhilosopherAnalyzer(somePhilosopher1);


            t2.Start();
            t2.Name = "th2 - Thread";
            PhilosopherAnalyzer analyzer2 = new PhilosopherAnalyzer(somePhilosopher2);

            t3.Start();
            t3.Name = "th3 - Thread";
            PhilosopherAnalyzer analyzer3 = new PhilosopherAnalyzer(somePhilosopher3);

            t4.Start();
            t4.Name = "th4 - Thread";
            PhilosopherAnalyzer analyzer4 = new PhilosopherAnalyzer(somePhilosopher4);

            t5.Start();
            t5.Name = "th5 - Thread";
            PhilosopherAnalyzer analyzer5 = new PhilosopherAnalyzer(somePhilosopher5);

            t1.Join();
            t2.Join();
            t3.Join();
            t4.Join();
            t5.Join();
        }
    }
}
