
// reference1 :  https://hijuworld.tistory.com/73?category=817153
// reference2 :  https://www.c-sharpcorner.com/article/understanding-multithreading-and-multitasking-in-c-sharp/
// reference3 :  크로스 플랫폼 개발을 위한 C# 7과 닷넷 코어 2.0 책
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTaskingShareResourceTutorial
{
    class Work
    {
        static int num = 0;
        public void MethodA()
        {
            for (int i = 0; i < 50000; i++)
            {                
                    num++;                
            }
        }
        public void MethodB()
        {
            for (int i = 0; i < 50000; i++)
            {
                num--;
            }
        }
 
    }

    class WorkLock {
        static int num = 0;
        static object conch = new object();
        public void MethodA()
        {
            for (int i = 0; i < 50000; i++)
            {
                lock (conch)     //잠금
                {
                    num++;
                }    //풀림
            }
        }
        public void MethodB()
        {
            for (int i = 0; i < 50000; i++)
            {
                lock (conch)     //잠금
                {    
                    num--;
                }    //풀림
            }
        }
 
    }


class WorkInterLock {
        static int num = 0;
        // static object conch = new object();
        public void MethodA()
        {
            for (int i = 0; i < 50000; i++)
            {
                Interlocked.Increment(ref num);
            }
        }
        public void MethodB()
        {
            for (int i = 0; i < 50000; i++)
            {
                Interlocked.Decrement(ref num);
            }
        }
    }


    class MultiTaskingTutorial
    {
        public void Run1() 
        {
            //여러 스레드가 하나에 자원에 접근할 때 하나가 해당 자원을 점유하고 있으면 다른 스레드에서는 접근을 못하고 대기하게 해야한다.
            //아래 예제는 변수 num 에 두개으 스레드가 접근하여 하나의 스레드(MethodA)는 num값을 하나 증가시키고 다른 스레드(MethodB)는 num 값을 감소시킨다.

            Console.WriteLine("Main Thread Start");

            Work w = new Work();
            Task aTask = Task.Factory.StartNew(w.MethodA);
            Task bTask = Task.Factory.StartNew(w.MethodB);
            Task.WaitAll(new Task[] { aTask, bTask });

            Console.WriteLine("Main Thread Ends");
        }

        public void Run2() 
        {
            /*
            동기화 문제를 해결하기 위해서는 lock으로 num을 접근하는 코드에 넣어서 해결할 수 있다.
            아래 예제는 동기화 이슈를 해결한 코드이다.
            물론 소요시간은 위에 예제보다 더 많이 걸리게 된다. lock이 걸리면 다른 스레드는 대기하기 때문에 시간이 오래 걸린다.
            
            단점 : locker문제는 잠금이 느리고 실제로 관련이없는 다른 곳에서 재사용하면 아무 이유없이 다른 스레드를 차단할 수 있다는 것이다.
            */
            Console.WriteLine("Main Thread Start");

            WorkLock w = new WorkLock();
            Task aTask = Task.Factory.StartNew(w.MethodA);
            Task bTask = Task.Factory.StartNew(w.MethodB);
            Task.WaitAll(new Task[] { aTask, bTask });
            
            Console.WriteLine("Main Thread Ends");
        }

        public void Run3() 
        {
            /* 
            lock보다 더 좋은 제안입니다.
            중단될 수 없는 '원 히트'로 읽기, 증가 및 쓰기를 효과적으로 수행하므로 안전합니다. 
            이 때문에 다른 코드에는 영향을 미치지 않으며 다른 코드도 잠그는 것을 기억할 필요가 없습니다. 
            또한 매우 빠릅니다(MSDN에서 말했듯이 최신 CPU에서 이것은 종종 말 그대로 단일 CPU 명령입니다).
            */
            Console.WriteLine("Main Thread Start");

            WorkInterLock w = new WorkInterLock();
            Task aTask = Task.Factory.StartNew(w.MethodA);
            Task bTask = Task.Factory.StartNew(w.MethodB);
            Task.WaitAll(new Task[] { aTask, bTask });
            
            Console.WriteLine("Main Thread Ends");
        }
        
    }
}