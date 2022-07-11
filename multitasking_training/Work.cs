
// reference1 :  https://hijuworld.tistory.com/72
// reference2 :  https://www.c-sharpcorner.com/article/understanding-multithreading-and-multitasking-in-c-sharp/
// reference3 :  크로스 플랫폼 개발을 위한 C# 7과 닷넷 코어 2.0 책
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTaskingTutorial
{
    class Work
    {
        public void FuncA()
        {
            Console.WriteLine("A함수 시작");
            Thread.Sleep(1000);
            Console.WriteLine("A함수 끝");
        }
        public void FuncB()
        {
            Console.WriteLine("B함수 시작");
            Thread.Sleep(2000);
            Console.WriteLine("B함수 끝");
        }
        public void FuncC()
        {
            Console.WriteLine("C함수 시작");
            Thread.Sleep(3000);
            Console.WriteLine("C함수 끝");
        }

        public int TestA()
        {
            Console.WriteLine("TestA Start");
            Thread.Sleep(1000);
            Console.WriteLine("TestA End");
            return 10;
        }
        public int TestB(int i)
        {
            Console.WriteLine("TestB Start");
            Thread.Sleep(1000);
            Console.WriteLine("TestB End");
            return i + 10;
        }
    }

    class File {
        public void Copy()
        {
            Console.WriteLine("Thread 1 Start");
            FileStream inStream = new FileStream(@"..\DummyFile.txt", FileMode.Open, 
                                                    FileAccess.Read, FileShare.None);
            FileStream outStream = new FileStream(@"..\DummyFileCreate.txt", FileMode.Create, 
                                                    FileAccess.Write, FileShare.Read);  
            using (inStream)
            {
                while(true) 
                {
                    int b = inStream.ReadByte();
                    if (b == -1)
                        break;
                    outStream.WriteByte((byte)b);

                }
            }               
            Console.WriteLine("Thread 1 End");
        }
    }


    class MultiTaskingTutorial
    {
        // 결과는 파일이 복사를 시작하기도 전에 메인 스레드가 종료되었음을 보여줍니다. 
        // 서브 Task에서 파일이 복사되는 동안 메인 스레드에서 다른 작업을 수행할 수 있음을 의미

        public void Run1() 
        {
            File f = new File();
            Console.WriteLine("Main Thread Start");

            Task t = new Task(f.Copy);
            t.Start();

            Console.WriteLine("Main Thread Ends");
            Console.ReadKey();
        }

        public void Run2() // 기본적으로 순차적인 실행
        {
            Console.WriteLine("Main Thread Start");

            Work w = new Work();
            w.FuncA();           //A함수 호출
            w.FuncB();           //B함수 호출
            w.FuncC();           //C함수 호출
            
            Console.WriteLine("Main Thread Ends");
        }

        public void Run3()  // 멀티 태스킹 실행
        {
            Console.WriteLine("Main Thread Start");
            Work w = new Work();
            Task taskA = new Task(w.FuncA); //태스크 객체
            Task taskB = new Task(w.FuncB);
            Task taskC = new Task(w.FuncC);
            taskA.Start();         //태스크 A시작
            taskB.Start();         //태스크 B시작
            taskC.Start();         //태스크 C시작
            taskA.Wait();         //태스크 A 끝날때까지 대기
            taskB.Wait();         //태스크 B 끝날때까지 대기
            taskC.Wait();         //태스크 C 끝날때까지 대기
            Console.WriteLine("Main Thread Ends");
        }

        
        public void Run4()  // 멀티 태스킹 실행
        {
            Console.WriteLine("Main Thread Start");
            Work w = new Work();
            Task taskA = Task.Factory.StartNew(w.FuncA);  //쓰레드 A 생성 후 시작
            Task taskB = Task.Run(new Action(w.FuncB));   //쓰레드 B 생성 후 시작
            Task taskC = Task.Factory.StartNew(w.FuncC);  //쓰레드 C 생성 후 시작
            Task[] tasks = {taskA, taskB, taskC};       //쓰레드 종료까지 대기
            Task.WaitAll(tasks);
            Console.WriteLine("Main Thread Ends");
        }

        public void Run5()  // 멀티 태스킹 실행
        {
            Console.WriteLine("Main Thread Start");
            Work w = new Work();
            var test = Task.Factory.StartNew(w.TestA)
                                .ContinueWith(task=>w.TestB(task.Result));
            Console.WriteLine("result : " + test.Result);
            Console.WriteLine("Main Thread Ends");
        }

        public void Run6()  // 중첩 태스킹 실행
        {
            Console.WriteLine("Main Thread Start");
            var outer = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Outer task 시작");
                var inner = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Inner task 시작.");
                    Thread.Sleep(2000);
                    Console.WriteLine("Inner task 종료.");
                });            
            });
            outer.Wait();
            Console.WriteLine("Outer task 종료.");
            Console.WriteLine("Main Thread Ends");
        }

        public void Run7()  // 중첩 태스킹 실행 + Inner 태스크 종료 후, Outer 태스크 종료
        {
            Console.WriteLine("Main Thread Start");
                        var outer = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Outer task 시작");
                var inner = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Inner task 시작.");
                    Thread.Sleep(2000);
                    Console.WriteLine("Inner task 종료.");
                }, TaskCreationOptions.AttachedToParent); // Inner 태스크가 완료되기를 기달리고 Outer 태스크가 완료           
            });
            outer.Wait();
            Console.WriteLine("Outer task 종료.");
            Console.WriteLine("Main Thread Ends");
        }



        
    }
}