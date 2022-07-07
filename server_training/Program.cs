/*
https://www.c-sharpcorner.com/article/understanding-multithreading-and-multitasking-in-c-sharp/
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading_and_Multitasking {
    class Program {
        static void Main(string[] age) {
            Work w = new Work();
            Console.WriteLine("Main Thread Start");

            ThreadStart s = w.Count;
            Thread thread1 = new Thread(s);
            thread1.Start();

            Console.WriteLine("Main Thread Ends");
            Console.ReadKey();
        }
    }
}