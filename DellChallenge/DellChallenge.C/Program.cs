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
            IntegerAdditionDemo();
            Console.ReadKey();
        }

        /// <summary>
        /// Demo method for working with IntegerAddition class
        /// </summary>
        private static void IntegerAdditionDemo()
        {
            // Create new instance of the IntegerAddition
            IntegerAddition integerAddition = new IntegerAddition();

            // Perform two basic additions, one with two terms and another with three terms
            int sum1 = integerAddition.Add(1, 3);
            int sum2 = integerAddition.Add(1, 3, 5);

            // Display the result
            Console.WriteLine($"First result is {sum1}");
            Console.WriteLine($"Second result is {sum2}");
        }
    }

    /// <summary>
    /// Performs addition of integer numbers
    /// </summary>
    public class IntegerAddition
    {
        /// <summary>
        /// Adds two integer numbers (terms) and returns the result (their sum)
        /// </summary>
        /// <param name="firstTerm">First term of the addition</param>
        /// <param name="secondTerm">Second term of the addition</param>
        /// <returns>The sum of firstTerm and secondTerm, e.g. firstTerm + secondTerm.</returns>
        public int Add(int firstTerm, int secondTerm)
        {
            return firstTerm + secondTerm;
        }

        /// <summary>
        /// Adds three integer numbers (terms) and returns the result (their sum)
        /// </summary>
        /// <param name="firstTerm">First term of the addition</param>
        /// <param name="secondTerm">Second term of the addition</param>
        /// <param name="thirdTerm">Third term of the addition</param>
        /// <returns>The sum of firstTerm, secondTerm, and thirdTerm, e.g. firstTerm + secondTerm + thirdTerm.</returns>
        public int Add(int firstTerm, int secondTerm, int thirdTerm)
        {
            return firstTerm + secondTerm + thirdTerm;
        }
    }
}
