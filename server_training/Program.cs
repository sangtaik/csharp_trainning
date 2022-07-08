/*
https://www.c-sharpcorner.com/article/understanding-multithreading-and-multitasking-in-c-sharp/
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace MultithreadingTutorial
{

    class Program
    {
        static void Main(string[] age)
        {

            int userInput = 0;
            do
            {
                userInput = DisplayMenu();
                ThreadTutorial t1 = new ThreadTutorial();
                if (userInput == 0) { System.Environment.Exit(1);}
                if (userInput == 1) { t1.Run1(); continue;}
                if (userInput == 2) { t1.Run2(); continue;}
                if (userInput == 3) { t1.Run3(); continue;}
                if (userInput == 4) { t1.Run4(); continue;}
                if (userInput == 5) { t1.Run5(); continue;}
                if (userInput == 6) { t1.Run6(); continue;}
                if (userInput == 7) { t1.Run7(); continue;}
                if (userInput == 8) { t1.Run8(); continue;}
                if (userInput == 9) { t1.Run9(); continue;}
                if (userInput == 10) { t1.Run10(); continue;}
                if (userInput == 11) { t1.Run11(); continue;}
                if (userInput == 12) { t1.Run12(); continue;}
                if (userInput == 13) { akshay.Run(); continue;}


            } while (userInput != 4);

            static int DisplayMenu()
            {
                Console.Clear();
                while (true)
                {
                    Console.WriteLine("");
                    Console.WriteLine();
                    Console.WriteLine("1. thread one, 2. thread two, 3. thread join, 4. thread sleep, 5. sleep + join, 6. join");
                    Console.WriteLine("0. exit");
                    int result;
                    if (Int32.TryParse(Console.ReadLine(), out result))
                        return result;
                    else
                        Console.WriteLine("Please enter a number");
                }
            }
        }
    }
}
