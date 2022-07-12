
// reference1 : https://velog.io/@jinuku/C-async-await%EB%A5%BC-%EC%9D%B4%EC%9A%A9%ED%95%98%EC%97%AC-%EB%B9%84%EB%8F%99%EA%B8%B0%EB%A5%BC-%EB%8F%99%EA%B8%B0%EC%B2%98%EB%9F%BC-%EA%B5%AC%ED%98%84%ED%95%98%EA%B8%B0-1
// reference2 : https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics; // Stopwatch

namespace Async_Tutorial
{
    class Work
    {
        public int GetPrimesCount(int start, int count)
        {
            return ParallelEnumerable.Range(start, count).Count(n => // 소수의 개수를 계산해서 return
                    Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0));
        }
        public Task<int> GetPrimesCountAsync(int start, int count)
        {
            return Task.Run(() =>
                ParallelEnumerable.Range(start, count).Count(n => // 소수의 개수를 계산해서 return
                    Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
        }
    }

    // These classes are intentionally empty for the purpose of this example. They are simply marker classes for the purpose of demonstration, contain no properties, and serve no other purpose.


    class Tutorial
    {
        public void Run1()  // async는 반환형이 void, Task 
        {
            //동기
            Console.WriteLine("Main Thread Start");

            Work w = new Work();
            int result = w.GetPrimesCount(2, 1000000);
            Console.WriteLine(result);

            Console.WriteLine("Main Thread Ends");
        }

        public async void Run2()  // async는 반환형이 void, Task 
        {
            // 비동기
            Console.WriteLine("Main Thread Start");

            var timer = Stopwatch.StartNew();  //시간 측정 시작
            Work w = new Work();
            int result = await w.GetPrimesCountAsync(2, 1000000);
            Console.WriteLine(result);

            timer.Stop();      //시간 측정 끝
            Console.WriteLine("excute async time : " + timer.ElapsedMilliseconds + "s");
            Console.WriteLine("Main Thread Ends");
        }
        public void Run3() // GetAwaiter(), OnComplted 함수 사용하여 async 구현
        {
            Console.WriteLine("Main Thread Start");

            var timer = Stopwatch.StartNew();  // async는 시간 측정 코드가 다른 위치에 있다.
            Work w = new Work();
            var awaiter = w.GetPrimesCountAsync(2, 1000000).GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                int result = awaiter.GetResult();
                Console.WriteLine(result);

                timer.Stop();      //시간 측정 끝
                Console.WriteLine("excute async time : " + timer.ElapsedMilliseconds + "s");
            });

 
            Console.WriteLine("Main Thread Ends");
        }
    }
}