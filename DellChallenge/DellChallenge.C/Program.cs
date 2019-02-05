using System;

namespace DellChallenge.C
{
    class Program
    {
        static void Main(string[] args)
        {
            // Please refactor the code below whilst taking into consideration the following aspects:
            //      1. clean coding
            //      2. naming standards
            //      3. code reusability, hence maintainability
            StartHere();
            Console.ReadKey();
        }

        private static void StartHere()
        {
            myObject _MyNewObject = new myObject();
            int obj1 = _MyNewObject.Do(1, 3);
            int num2 = _MyNewObject.DoExtended(1, 3, 5);
            Console.WriteLine(obj1);
            Console.WriteLine(num2);
        }
    }

    class myObject
    {

        public int Do(int a, int b)
        {
            return a + b;
        }

        public int DoExtended(int a, int b, int c)
        { return a + b + c;
        }
    }
}
