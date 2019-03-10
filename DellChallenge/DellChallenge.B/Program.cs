using System;

namespace DellChallenge.B
{
    class Program
    {
        static void Main(string[] args)
        {
            // Given the classes and interface below, please constructor the proper hierarchy.
            // Feel free to refactor and restructure the classes/interface below.
            // (Hint: Not all species and Fly and/or Swim)
            /*
             * There are many ways to design this, depending on what we want to achieve.
             * I chose to create interfaces for fliers and swimmers.
             * I also chose to leave move common actions (Eat and Drink) to the base Species 
             * class, we could also choose to use the ISpecies interface for that purpose and it
             * would be correct as well (again, depending on our goals).
             * Humans can fly (with machines) and swim, birds can only fly, fish can only swim.
             * They all eat and drink and have a species name ("GetSpecies")             
             */
        }
    }

    public interface IFlier
    {
        void Fly();
    }

    public interface ISwimmer
    {
        void Swim();
    }

    public abstract class Species
    {
        public abstract void GetSpecies();
        public abstract void Eat();
        public abstract void Drink();
    }

    public class Human : Species, IFlier, ISwimmer
    {
        public override void GetSpecies()
        {
            Console.WriteLine("I am a human being.");
        }

        public override void Drink()
        {
            Console.WriteLine("I drink lots of things: water, coffee, beer, juice, wine... all sorts of things.");
        }

        public override void Eat()
        {
            Console.WriteLine("I seem to be the top of the food chain on my planet. I eat most other species of plants and animals. Certainly birds and fish have been on my diet for millenia.");
        }

        public void Fly()
        {
            Console.WriteLine("Although for thousands of years (or maybe millions) I was unable to fly, things have recently changed. I can now build flying machines and fly.");
        }

        public void Swim()
        {
            Console.WriteLine("I can learn to swim without any special gear. I can also build machines that can cross large bodies of water, or even go underwater for a long time, much like a fish does.");
        }
    }

    public class Bird : Species, IFlier
    {
        public override void GetSpecies()
        {
            Console.WriteLine("I am a bird.");
        }

        public override void Eat()
        {
            Console.WriteLine("I eat grains, flies, and sometimes other animals.");
        }

        public override void Drink()
        {
            Console.WriteLine("I drink water. I prefer it fresh.");
        }

        public void Fly()
        {
            Console.WriteLine("I can fly like a natural! Well, most of the time at least. There are some birds who cannot fly, but let's not be picky.");
        }
    }

    public class Fish : Species, ISwimmer
    {
        public override void GetSpecies()
        {
            Console.WriteLine("I am a fish.");
        }

        public override void Eat()
        {
            Console.WriteLine("I eat algae, worms and other fish mostly.");
        }

        public override void Drink()
        {
            Console.WriteLine("I suppose you could say I drink water. Maybe it would be more correct to say that I breathe the water. Anyways, you get the point.");
        }

        public void Swim()
        {
            Console.WriteLine("I can swim like a natural! No need for any gear or stuff!");
        }
    }
}

