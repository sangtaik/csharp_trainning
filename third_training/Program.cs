using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateChain 

{
    delegate void PDelegate(int a, int b);

    class Program
    {
        static void Plus(int a, int b)
        {
            Console.WriteLine("{0} + {1} = {2}", a, b, a + b);
        }

        static void Minus(int a, int b)
        {
            Console.WriteLine("{0} - {1} = {2}", a, b, a - b);
        }

        static void Division(int a, int b)
        {
            Console.WriteLine("{0} / {1} = {2}", a, b, a / b);
        }

        static void Multiplication(int a, int b)
        {
            Console.WriteLine("{0} * {1} = {2}", a, b, a * b);
        }

        static void Main(string[] args)
        {
            // pd 하나에 Delegate를 사용하여 4개의 함수를 할당하였다.
            PDelegate pd = (PDelegate)Delegate.Combine(new PDelegate(Plus),
                new PDelegate(Minus), new PDelegate(Division), new PDelegate(Multiplication));

            pd(20, 10); // pd를 호출 (결과는 4개의 함수 실행 결과가 순차적으로 나온다.)

            pd -=(PDelegate)Delegate.Combine(new PDelegate(Plus),
                new PDelegate(Minus), new PDelegate(Division), new PDelegate(Multiplication));

            if (pd is null) {
                Console.WriteLine(pd);
            }



        }
    }
}

