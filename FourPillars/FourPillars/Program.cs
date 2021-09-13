using System;

namespace FourPillars {
    public class Program {
        public static void Main(string[] args) {
            Console.WriteLine("Hello World!");

            Animal dog = new Dog("Dan", 2);
            Animal husky = new Husky("Pickles", 3);

            Console.WriteLine(dog.Speak());
            Console.WriteLine(husky.Speak());

            Console.WriteLine(dog.GetInfo());
            Console.WriteLine(husky.GetInfo());

            Console.WriteLine(dog.GetType());
            Console.WriteLine(husky.GetType());

            Dog sameDog = dog as Dog;
            Husky sameHusky = husky as Husky;
            if (sameDog != null) {
                Console.WriteLine(sameDog.DogOnly());
            }
            if (sameHusky != null) {
                Console.WriteLine(sameHusky.HuskyOnly());
            }

            StaticClass.SayHello();

            StaticClass sClass = new StaticClass();
            sClass.SayHello2();

            StaticClass sClass2 = new StaticClass();
            StaticClass sClass3 = new StaticClass();

            StaticClass.SayHello();
        }
    }
}
