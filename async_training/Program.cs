using System.Diagnostics; // Stopwatch

namespace Async_Tutorial
{

    class Program
    {
        static void Main(string[] age)
        {

            int userInput = 0;
            do
            {
                userInput = DisplayMenu();
                var timer = Stopwatch.StartNew();  //시간 측정 시작
                // 실행 로직
                Tutorial t1 = new Tutorial();
                if (t1 is not null) {
                    if (userInput == 0) { System.Environment.Exit(1);}
                    if (userInput == 1) { t1.Run1(); printTime(timer); Console.ReadLine(); continue;}
                    if (userInput == 2) { t1.Run2(); printTime(timer); Console.ReadLine(); continue;}
                    if (userInput == 3) { t1.Run3(); printTime(timer); Console.ReadLine(); continue;}
                    // if (userInput == 4) { t1.Run4(); printTime(timer); Console.ReadLine(); continue;}
                    // if (userInput == 5) { t1.Run5(); printTime(timer); Console.ReadLine(); continue;}
                    // if (userInput == 6) { t1.Run6(); printTime(timer); Console.ReadLine(); continue;}
                    // if (userInput == 7) { t1.Run7(); printTime(timer); Console.ReadLine(); continue;}


                }
                


            } while (userInput >= 0);

            static int DisplayMenu()
            {
                Console.Clear();
                while (true)
                {
                    Console.WriteLine("");
                    Console.WriteLine(); 
                    Console.WriteLine(@"1. sync, 2. async, 3. async 2");
                    Console.WriteLine("0. exit");
                    int result;
                    if (Int32.TryParse(Console.ReadLine(), out result))
                        return result;
                    else
                        Console.WriteLine("Please enter a number");
                }
            }
        }

        static void printTime(Stopwatch timer) {
            timer.Stop();      //시간 측정 끝
            Console.WriteLine("excute time : " + timer.ElapsedMilliseconds + "s");
        }
    }
}
