using System;
using UnityContainerPractice.ConstructorInjection;

namespace UnityContainerPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            //registerResolve();
            constructorInjection();
            Console.ReadKey();

        }

        static void registerResolve()
        {
            //RegisterResolve.one();
            //RegisterResolve.two();
            //RegisterResolve.three();
            //RegisterResolve.four();
            //RegisterResolve.five();
            RegisterResolve.six();
        }

        static void constructorInjection()
        {
            //Demo.one();
            //Demo.two();
            Demo.twoAgain();
            //Demo.three();
            //Demo.threeInstead();
        }
    }
}
