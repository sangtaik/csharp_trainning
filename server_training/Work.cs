
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreading_and_Multitasking {
    class Work {
        public void Count() {
            Console.WriteLine("Thread 1 Start");
            for (int i = 0; i < 100; i++) {
                Console.WriteLine(i);
            }
            Console.WriteLine("Thread 1 End");
        }

    }
}