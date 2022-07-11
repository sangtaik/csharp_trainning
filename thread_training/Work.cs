
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadingTutorial
{
    class Work
    {
        public void Count()
        {
            Console.WriteLine("Thread 1 Start");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Thread 1 End");
        }

        public void CountSleep()
        {
            Console.WriteLine("Thread 1 Start");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("CountSleep" + i);
                Thread.Sleep(500);
            }
            Console.WriteLine("Thread 1 End");
        }


        public void Alpabets()
        {
            Console.WriteLine("Thread 2 Start");
            for (char c = 'A'; c <= 'Z'; c++)
            {
                Console.WriteLine(c);
            }
            Console.WriteLine("Thread 2 End");
        }

        public int[] iArray = new int[20];

        public void CollectData()
        {
            Console.WriteLine("Thread 3 Start");
            for (int i = 0; i < 20; i++)
            {
                iArray[i] = i + 1;
                Console.Write(",");
                Thread.Sleep(500);
            }
            Console.WriteLine("Thread 3 End");
        }

    }


    class ThreadTutorial
    {
        public void Run1()
        {
            Work w = new Work();
            Console.WriteLine("Main Thread Start");

            ThreadStart s = w.Count;
            Thread thread1 = new Thread(s);
            thread1.Start();

            Console.WriteLine("Main Thread Ends");
            Console.ReadKey();
        }

        public void Run2()
        {
            Work w = new Work();
            Console.WriteLine("Main Thread Start");

            ThreadStart s = w.Count;
            Thread thread1 = new Thread(s);
            thread1.Start();

            thread1.Join();

            Console.WriteLine("Main Thread Ends");
            Console.ReadKey();
        }

        public void Run3()
        {
            Work w = new Work();
            Console.WriteLine("Main Thread Start");

            ThreadStart s = w.Count;
            Thread thread1 = new Thread(s);
            thread1.Start();

            Thread.Sleep(1000);

            Console.WriteLine("Main Thread Ends");
            Console.ReadKey();
        }

        public void Run4()
        {
            Work w = new Work();
            Console.WriteLine("Main Thread Start");

            ThreadStart s = w.Count;
            Thread thread1 = new Thread(s);
            thread1.Start();
            thread1.Join();
            Thread.Sleep(1000);

            Console.WriteLine("Main Thread Ends");
            Console.ReadKey();
        }

        public void Run5()
        {
            Work w = new Work();
            Console.WriteLine("Main Thread Start");

            ThreadStart s1 = w.CountSleep;
            Thread thread1 = new Thread(s1);
            thread1.Start();

            // Thread.Sleep(1000);
            // thread1.Join();

            Console.WriteLine("Main Thread Ends");
            Console.ReadKey();
        }
        // join 시점이 어떻게 되는지 확인
        public void Run6()
        {
            Work w = new Work();
            Console.WriteLine("Main Thread Start");

            ThreadStart s1 = w.CountSleep;
            Thread thread1 = new Thread(s1);
            thread1.Start();

            // Thread.Sleep(1000);
            thread1.Join();

            Console.WriteLine("Main Thread Ends");
            Console.ReadKey();
        }

        public void Run7()
        {
            Work w = new Work();
            Console.WriteLine("Main Thread Start");

            ThreadStart s1 = w.CountSleep;
            Thread thread1 = new Thread(s1);
            thread1.Start();

            Thread.Sleep(1000);


            Console.WriteLine("Main Thread Ends");
            Console.ReadKey();
        }

        public void Run8()
        {
            Work w = new Work();
            Console.WriteLine("Main Thread Start");

            ThreadStart s1 = w.CountSleep;
            Thread thread1 = new Thread(s1);
            thread1.Start();
            thread1.Join();

            Thread.Sleep(1000);


            Console.WriteLine("Main Thread Ends");
            Console.ReadKey();
        }

        public void Run9()
        {
            Work w = new Work();
            Console.WriteLine("Main Thread Start");

            ThreadStart s1 = w.Count;
            ThreadStart s2 = w.Alpabets;
            Thread thread1 = new Thread(s1);
            Thread thread2 = new Thread(s2);
            thread1.Start();
            thread2.Start();

            Console.WriteLine("Main Thread Ends");
            Console.ReadKey();
        }

        public void Run10()
        {
            Work w = new Work();
            Console.WriteLine("Main Thread Start");

            ThreadStart s1 = w.Count;
            ThreadStart s2 = w.Alpabets;
            Thread thread1 = new Thread(s1);
            Thread thread2 = new Thread(s2);
            thread1.Start();
            thread2.Start();

            thread1.Join();
            // thread2.Join();

            Console.WriteLine("Main Thread Ends");
            Console.ReadKey();
        }

        public void Run11()
        {
            Work w = new Work();
            Console.WriteLine("Main Thread Start");

            ThreadStart s1 = w.Count;
            ThreadStart s2 = w.Alpabets;
            Thread thread1 = new Thread(s1);
            Thread thread2 = new Thread(s2);
            thread1.Start();
            thread2.Start();

            Thread.Sleep(1000);

            Console.WriteLine("Main Thread Ends");
            Console.ReadKey();
        }

        public void Run12()
        {
            Work w = new Work();
            Console.WriteLine("Main Thread Start");

            ThreadStart s1 = w.Count;
            ThreadStart s2 = w.Alpabets;
            Thread thread1 = new Thread(s1);
            Thread thread2 = new Thread(s2);
            thread1.Start();
            thread2.Start();

            Thread.Sleep(1000);
            thread1.Join();

            Console.WriteLine("Main Thread Ends");
            Console.ReadKey();
        }

        public void Run13()
        {
            Work w = new Work();
            Console.WriteLine("Main Thread Start");

            ThreadStart s1 = w.Count;
            ThreadStart s2 = w.Alpabets;
            Thread thread1 = new Thread(s1);
            Thread thread2 = new Thread(s2);
            thread1.Start();
            thread2.Start();

            thread2.Join();

            Console.WriteLine("Main Thread Ends");
            Console.ReadKey();
        }

        public void Run14()
        {
            Work w = new Work();
            Console.WriteLine("Main Thread Start");

            ThreadStart s1 = w.Count;
            ThreadStart s2 = w.Alpabets;
            Thread thread1 = new Thread(s1);
            Thread thread2 = new Thread(s2);
            thread1.Start();
            thread2.Start();

            Thread.Sleep(1000);
            Thread.Sleep(1000);

            Console.WriteLine("Main Thread Ends");
            Console.ReadKey();
        }

    }
}

//참조 : https://www.c-sharpcorner.com/UploadFile/1d42da/1/
static class akshay
{
    static Thread th1;
    static void ChildThread()
    {
        try
        {
            throw new Exception();
        }
        catch (Exception)
        {
            try
            {
                Console.WriteLine("1 thread are going to sleep mode");
                Thread.Sleep(5000);
                Console.WriteLine("1 now thread is out of sleep");
            }
            catch (ThreadAbortException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }

    static void ChildThread2()
    {
        try
        {
            throw new Exception();
        }
        catch (Exception)
        {
            try
            {
                Console.WriteLine("2 thread are going to sleep mode");
                Thread.Sleep(2000);
                Console.WriteLine("2 now thread is out of sleep");
            }
            catch (ThreadAbortException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
    static void Console_CancelKeyPress(Object sender, ConsoleCancelEventArgs e)
    {
        Console.WriteLine("aborting");
        if (th1 != null)
        {
            th1.Abort();
            th1.Join();
        }
    }

    public static void Run()
    {
        // CTRL + C를 누르면 Abort 호출
        Console.CancelKeyPress += new ConsoleCancelEventHandler(Console_CancelKeyPress);
        th1 = new Thread(ChildThread);
        th1.Start();
        th1.Join();
        Console.Read();
    }
}