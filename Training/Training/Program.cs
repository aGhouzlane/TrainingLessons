using System;
using System.Collections;
using System.Collections.Generic;
using Training.Data;

namespace Training {
    public class Program {
        public const string _name = "Dan Pickles";

        public static void Main(string[] args) {
            //ctrl + s, ctrl + shift + s to save all
            //ctrl + shift + B to build solution
            //Console.WriteLine("Hello World!");

            //Day1Examples();
            Day2Examples();
        }

        public static void Day2Examples() {
            //object are pass by reference
            //primitives are pass by value

            Day2 passExample = new Day2();
            Day1 testItem = new Day1(1, "Test Name");

            Console.WriteLine($"Starting Id: {testItem.Id}");
            Console.WriteLine($"Starting Name: {testItem.Name}");
            passExample.ObjectPassed(testItem);
            Console.WriteLine($"Starting Id: {testItem.Id}");
            Console.WriteLine($"Starting Name: {testItem.Name}");

            int testInt = 2;
            Console.WriteLine($"Starting Int: {testInt}");
            passExample.PrimitivePassed(ref testInt);
            Console.WriteLine($"Starting Int: {testInt}");

            int[] myArray = new int[3];
            myArray[0] = 5;
            myArray[1] = 4;
            myArray[2] = 3;

            int i = 0;
            Console.WriteLine("While loop 1");
            while (i < 3) {
                Console.WriteLine(myArray[i]);
                // i++ increments then exaluates i, is shorthand for i = i + 1;
                // i-- decrements then exaluates i, is shorthand for i = i - 1;
                // ++i is the same as i++, but increments before evaluating i
                // --i is the same as i--, but decrements before evaluating i
                i++;
            }

            Console.WriteLine("For loop 1");
            for(int j = 0; j < myArray.Length; j++) {
                Console.WriteLine(myArray[j]);
            }

            Console.WriteLine("For loop 2");
            for (int j = 0; j < myArray.Length; ++j) {
                Console.WriteLine(myArray[j]);
            }

            Console.WriteLine("Do while loop");
            //always executes atleast once
            i = 0;
            do {
                Console.WriteLine(myArray[i]);
                i++;
            } while (i < 3);

            Console.WriteLine("Copy array");
            //copy an array
            //var newArray = myArray;
            int[] newArray = new int[myArray.Length];
            i = 0;
            while (i < myArray.Length) {
                //newArray[i] = myArray[i];
                Console.WriteLine(newArray[i]);
                i++;
            }

            myArray[2] = 75;
            Console.WriteLine($"my array: {myArray[2]}");
            Console.WriteLine($"new array: {newArray[2]}");

            Console.WriteLine("New new array:");
            int[] newNewArray = { 1, 2, 3 };
            i = 0;
            while (i < newNewArray.Length) {
                Console.WriteLine(newNewArray[i]);
                i++;
            }

            Console.WriteLine("foreach loop");
            foreach(int x in myArray) {
                Console.WriteLine(x);
            }

            Console.WriteLine("Catch error");
            Console.WriteLine("For loop with error");
            try {
                for (int j = 0; j < myArray.Length;) {
                    Console.WriteLine(myArray[++j]);
                }
            } catch (IndexOutOfRangeException e) {
                Console.WriteLine("Caught it");
            } catch (Exception e) {
                Console.WriteLine("General exception");
            } finally {
                Console.WriteLine("I always run");
            }

            Console.WriteLine("I finished executing");

            testItem.Id = 75;
            passExample.Remove(testItem);
        }

        public static void Day1Examples() {
            Console.WriteLine("Day 1 stuff");

            int _int = 1;
            double _double = 2.0, _double2 = 2.0d;
            //suffix f or F for float literals
            //suffix d or D for double literals
            //suffix m or M for decimal literals
            float _float = 3.0f;
            decimal _decimal = 4.0m;
            //must cast these
            double total = _double + (double)_float + (double)_decimal;

            //var will decide the type based on what's assigned
            var anything = "string";

            bool _bool = true;
            char _char = 'A';

            //same namespace so no using necessary
            Day1 myClass = new Day1();

            myClass.Id = (int)_double;
            myClass.Name = _name;

            Day1 myClass2 = new Day1(2, "Joe Blow");

            Console.WriteLine(myClass.SayHello());

            IEnumerable myList = myClass.CovariantReturn();

            //cannt instantiate an abstract class
            //cant instantiate an interface
            //Animal animal = new Animal();
            Animal dog = new Dog("Fiddo", "Grey", false);
            Animal cat = new Cat("Kitty", "Black", "Green");

            Console.WriteLine(((Dog)dog).Move(45));
            Console.WriteLine(cat.Move());
            Console.WriteLine(dog.View());
            Console.WriteLine(cat.View());

            //static classes are called by class name
            //Console.WriteLine(StaticClass.Hello());

            Console.WriteLine(dog.GetType());
            Dog sameDog = dog as Dog;
            //as keyword returns null in type cannot be converted
            //Dog someCat = cat as Dog;

            Console.WriteLine(sameDog.DogMethod());
            Console.WriteLine($"Has a collar: {sameDog.Collar}");
            //Console.WriteLine(someCat.DogMethod());

            Sedan car1 = new Sedan();
            IVehicle car2 = new Sedan();

            //VirtualAnimal bear = new VirtualAnimal();
            //Bear bear2 = new Bear();

            //Console.WriteLine(bear2.Speak());
            Cat sameCat = cat as Cat;
            Console.WriteLine(sameCat.GetTail());
        }
    }
}
 