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
            Console.WriteLine("Hello World!");

            Day1Examples();
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
            Console.WriteLine(StaticClass.Hello());

            Console.WriteLine(dog.GetType());
            Dog sameDog = dog as Dog;
            //as keyword returns null in type cannot be converted
            //Dog someCat = cat as Dog;

            Console.WriteLine(sameDog.DogMethod());
            Console.WriteLine($"Has a collar: {sameDog.Collar}");
            //Console.WriteLine(someCat.DogMethod());

            Sedan car1 = new Sedan();
            IVehicle car2 = new Sedan();

            //virtual can be instantiated and may or may not have a useable implementation
            //VirtualAnimal bear = new VirtualAnimal();
            //Bear bear2 = new Bear();

            //Console.WriteLine(bear2.Speak());
            Cat sameCat = cat as Cat;
            Console.WriteLine(sameCat.GetTail());
        }
    }
}
