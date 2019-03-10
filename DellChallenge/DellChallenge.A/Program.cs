using System;

namespace DellChallenge.A
{
    class Program
    {
        static void Main(string[] args)
        {
            // State and explain console output order.

            /*
             The program displays:

            A.A()
            B.B()
            A .Age

            The flow goes like this:

            * First we invoke the constructor of class B with "new B()"
            * However, class B is derived from class A, which causes the runtime to automatically invoke the constructor of class A before invoking any code from B's constructor
            * This causes the "A.A()" output from A's constructor "Console.WriteLine("A.A()");"
            * After A's constructor finishes, execution comes to B's constructor
            * This causes the "B.B()" output from B's constructor "Console.WriteLine("B.B()");"
            * After the WriteLine we have "Age = 0" which is calling the setter for Age in the base class
            * Inside the setter, the _age field (private to class A) is set to 0
            * Then still inside the setter, we get the "A .Age" output from the next Console.WriteLine
            * Execution of the setter finisesh, control comes back to construcor B, which is also finished, so we're back to Main
            * The Console.ReadKey() waits until a key is pressed (and returns the key but the value is not stored in our case)
            
             **/

            new B();
            Console.ReadKey();
        }
    }

    class A
    {
        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                _age = value;
                Console.WriteLine("A .Age");
            }
        }


        public A()
        {
            Console.WriteLine("A.A()");
        }
    }

    class B : A
    {
        public B()
        {
            Console.WriteLine("B.B()");
            Age = 0;
        }
    }
}
