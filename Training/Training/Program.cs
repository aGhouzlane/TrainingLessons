using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Training.Data;
using Training.Factories;
using Training.Threading;

namespace Training {
    public class Program {
        public const string _name = "Dan Pickles";

        public static void Main(string[] args) {
            //ctrl + s, ctrl + shift + s to save all
            //ctrl + shift + B to build solution
            //Console.WriteLine("Hello World!");

            //Day1Examples();
            //Day2Examples();
            //Day3Examples();
            //Day4Examples();

            //stops the program from completing before Day4Examples is done
            //Console.ReadLine();

            //MoreDay4Examples();
            //Day4ProducerConsumer();
            //Day4WrongThreadsTest();

            //hacker rank diagonal difference
            //first argument is n
            //int n = Convert.ToInt32(args[0].Trim());

            //List<List<int>> arr = new List<List<int>>();

            //for (int i = 0; i < n; i++) {
            //    arr.Add(args[i + 1].TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList());
            //}

            //int result = diagonalDifference(arr);

            //Console.WriteLine(result);
        }

        public static void Day4WrongThreadsTest() {
            //Console.WriteLine($"Singleton {MySingleton.Instance.GetHashCode()}");
            //This just shows how MySingleton is not thread save whereas MySingleton2 is
            List<Thread> testList = new List<Thread>();
            for (int i = 0; i < 4; i++) {
                Thread Temp = new Thread(() => {
                    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: Singleton {MySingleton.Instance.GetHashCode()}");
                });
                testList.Add(Temp);
            }

            foreach (var t in testList) {
                t.Start();
            }

            foreach (var th in testList) {
                th.Join();
            }
        }

        public static void Day4ProducerConsumer() {
            //basic example, but could easily get more complex
            Random rand = new Random();
            ProducerConsumer pcExample = new ProducerConsumer();

            Thread p1 = new Thread(() => {
                int val = rand.Next(20, 51);

                for (int i = 0; i < 5; i++) {
                    pcExample.AddProduce(val);
                    Thread.Sleep(3000);
                }
            });

            Thread p2 = new Thread(() => {
                int val = rand.Next(20, 51);

                for (int i = 0; i < 5; i++) {
                    pcExample.AddProduce(val);
                    Thread.Sleep(3000);
                }
            });

            Thread c1 = new Thread(() => {
                int val = rand.Next(20, 51);

                for (int i = 0; i < 5; i++) {
                    pcExample.ConsumeProduce(val);
                    Thread.Sleep(3000);
                }
            });

            Thread c2 = new Thread(() => {
                int val = rand.Next(20, 51);

                for (int i = 0; i < 5; i++) {
                    pcExample.ConsumeProduce(val);
                    Thread.Sleep(3000);
                }
            });

            p1.Start();
            p2.Start();
            c1.Start();
            c2.Start();

            p1.Join();
            p2.Join();
            c1.Join();
            c2.Join();
        }

        public static void MoreDay4Examples() {
            Console.WriteLine("\nThreading examples");

            BankAccount act1 = new BankAccount(100);
            BankAccount act2 = new BankAccount(100);
            BankAccount act3 = new BankAccount(100);
            Person p1 = new Person("Dan Pickles", act1);
            Person p2 = new Person("John Doe", act2);
            Person p3 = new Person("Jane Doe", act2);
            Person p4 = new Person("Bob Ross", act3);
            Random rand = new Random();
            List<Thread> tasks = new List<Thread>();

            Thread thread1 = new Thread(() => ManageAccount(p1, rand));
            tasks.Add(thread1);
            Thread thread2 = new Thread(() => ManageAccount(p2, rand));
            tasks.Add(thread2);
            Thread thread3 = new Thread(() => ManageAccount(p3, rand));
            tasks.Add(thread3);

            Dog dog = new Dog("Test", "Blue", true);

            Thread thread4 = new Thread(dog.ThreadTest);
            tasks.Add(thread4);
            Thread thread5 = new Thread(new ThreadStart(dog.ThreadTest));
            tasks.Add(thread5);

            Thread thread6 = new Thread(() => {
                for (int i = 0; i < 3; i++) {
                    double val = rand.NextDouble() * (50.50 - 20.50) + 20.50;
                    p4.Add(val);
                    Thread.Sleep(3000);
                    val = rand.NextDouble() * (50.50 - 20.50) + 20.50;
                    p4.Withdraw(val);
                }
            });
            tasks.Add(thread6);

            foreach (Thread t in tasks) {
                t.Start();
            }

            foreach (Thread th in tasks) {
                th.Join();
            }

            Console.WriteLine("All threads finished");

            Thread newThread = new Thread(() => { Thread.Sleep(1200000000); });

            newThread.Start();
            
            newThread.Interrupt();
            Console.WriteLine("Thread Interrupted");

            newThread.Join();
        }

        private static void ManageAccount(Person p, Random rando) {
            /* lambda expression
             * () => { statements; }
             * 
             * void Method() {
             *  statements;
             * }
             */
            for (int i = 0; i < 3; i++) {
                double val = rando.NextDouble() * (50.50 - 20.50) + 20.50;
                p.Add(val);
                Thread.Sleep(3000);
                val = rando.NextDouble() * (50.50 - 20.50) + 20.50;
                p.Withdraw(val);
            }
        }

        public static async Task Day4Examples() {
            await BreakfastAsync.MakeBreakfast();
        }

        public static int diagonalDifference(List<List<int>> arr) {
            int diff = 0, sum1 = 0, sum2 = 0;
            int n = arr.Count;

            //get thhe sum of both diagonals
            for (int i = 0; i < n; i++) {
                sum1 += arr[i][i];
                sum2 += arr[i][n - 1 - i];
            }

            diff = Math.Abs(sum2 - sum1);

            return diff;
        }

        public struct Day3Struct {
            //structs are a value type
            public int id;
            public string name;
            //reference types like lists and objects are still references in structs
            //and can be changed just other like reference types
            private List<string> colors;

            //cannot have an explicit parameterless constructor
            //must fully assign everything before exiting the constructor
            public Day3Struct(int id, string name) {
                this.id = id;
                this.name = name;
                this.colors = new List<string>();
            }

            //structs can have methods just like classes
            public void AddColor(string color) {
                colors.Add(color);
            }

            public override string ToString() {
                return $"{id} [{string.Join(", ", colors)}]";
            }
        }

        //value types in structs are not changed by methods because they are value types
        //unlike objects where you are given a reference
        public static void MutateStruct(Day3Struct stru) {
            stru.id = 75;
            Console.WriteLine("In method {0}", stru.id);
        }

        public static void Day3Examples() {
            Day3Struct myStruct = new Day3Struct(1, "Test Name");
            var newStruct = myStruct;
            Console.WriteLine($"Struct id: {myStruct.id}");
            Console.WriteLine($"New struct id: {newStruct.id}");

            myStruct.id = 2;
            Console.WriteLine($"Struct id: {myStruct.id}");
            Console.WriteLine($"New struct id: {newStruct.id}");
            MutateStruct(myStruct);
            Console.WriteLine($"Struct id: {myStruct.id}");

            myStruct.AddColor("Blue");
            myStruct.AddColor("Red");
            Console.WriteLine(myStruct);
            Console.WriteLine(newStruct);

            //IEnumerable<> collections
            //Many collections implement IEnumerable ontop of other interfaces
            //this gives a user common methods to call
            //in the case of IEnumerable this allows a user to iterate over the 
            //elements in the collection
            List<int> myList = new List<int>();
            LinkedList<int> myLList = new LinkedList<int>();
            Dictionary<string, string> birthdays = new Dictionary<string, string>();
            SortedDictionary<string, string> sBirthdays = new SortedDictionary<string, string>();
            HashSet<string> hSet = new HashSet<string>();
            SortedSet<string> sSet = new SortedSet<string>();

            myList.Add(3);
            myList.Add(6);
            myList.Add(4);
            Console.WriteLine($"{string.Join(", ", myList)}");
            Console.WriteLine(myList[1]);
            myLList.AddLast(3);
            myLList.AddLast(6);
            myLList.AddLast(4);
            Console.WriteLine($"{string.Join(", ", myList)}");
            //C# linked list does not support random access
            //using LINQ can do this easier
            Console.WriteLine(myLList.First.Next.Value);

            birthdays.Add("Dan Pickles", "01/12");
            sBirthdays.Add("Dan Pickles", "01/12");
            birthdays.Add("John Doe", "12/20");
            sBirthdays.Add("John Doe", "12/20");
            birthdays.Add("Adam Smith", "06/07");
            sBirthdays.Add("Adam Smith", "06/07");
            //Dictionaries do not allow duplicate keys
            //birthdays.Add("Dan Pickles", "02/04");
            //sBirthdays.Add("Dan Pickles", "02/04");

            Console.WriteLine("Unsorted dictionary");
            foreach (var entry in birthdays) {
                Console.WriteLine($"Key: {entry.Key}, Value: {entry.Value}");
            }

            //sorted based on the key
            Console.WriteLine("sorted dictionary");
            foreach (var entry in sBirthdays) {
                Console.WriteLine($"Key: {entry.Key}, Value: {entry.Value}");
            }

            Queue<string> line = new Queue<string>();
            line.Enqueue("John");
            line.Enqueue("Jane");
            line.Enqueue("Mike");

            //both loops do the same thing
            while (line.Count > 0) {
                Console.WriteLine(line.Dequeue());
            }
            //for (int i = 0; i < 3; i++) {
            //    Console.WriteLine(line.Dequeue());
            //}

            //custom linked list implementation
            //adds items to the front of the list
            Day3<string> myLL = new Day3<string>();
            Day3<int> myLL2 = new Day3<int>();
            Day3<Day1> myLL3 = new Day3<Day1>();
            //instantiate a nested class
            //Day3<int>.Node myNode = new Day3<int>.Node(3);

            myLL2.AddHead(1);
            myLL2.AddHead(2);
            myLL2.AddHead(3);

            myLL3.AddHead(new Day1(1, "Dan"));
            myLL3.AddHead(new Day1(2, "Joe"));
            myLL3.AddHead(new Day1(3, "Mike"));

            myLL.AddHead("One");
            myLL.AddHead("Two");
            myLL.AddHead("Three");

            myLL.Print();
            myLL2.Print();
            myLL3.Print();

            Console.WriteLine("The second element: {0}", myLL.Get(1));
            Console.WriteLine("The second element: {0}", myLL2.Get(1));
            Console.WriteLine("The second element: {0}", myLL3.Get(1));

            //user input
            //you would want to loop user input or check user input to try and filter out 
            //bad input, so you don't get cases of users entering a string when you expect
            //an int, or a double when you expect an int, etc.
            Console.Write("Enter a name: ");
            string input = Console.ReadLine();
            Console.WriteLine($"You entered: {input}");

            Console.Write("Enter a number: ");
            try {
                int numInput = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"You entered: {numInput}");
            } catch (Exception e) {
                Console.WriteLine("Wrong input!");
            }

            //file reading example
            Day3FileReader reader = new Day3FileReader();
            reader.ReadFile();
            reader.WriteLines();
            var csv = reader.ReadCSV();

            Console.WriteLine("CSV contents");
            foreach (var entry in csv) {
                Console.WriteLine(entry);
            }

            //singleton example. Not a threadsafe implementation
            //the idea is to only ever have one instance of this class
            Console.WriteLine("Singleton: " + MySingleton.Instance.GetHashCode());
            Console.WriteLine("Singleton: " + MySingleton.Instance.GetHashCode());
            Console.WriteLine("Singleton: " + MySingleton.Instance.GetHashCode());

            //reading from a config file that would have keys of some kind
            string myKey = ConfigurationManager.AppSettings.Get("MyKey");
            Console.WriteLine("The value of MyKey: {0}", myKey);
            string user = ConfigurationManager.AppSettings.Get("User");
            Console.WriteLine("The value of User: {0}", user);

            //different uses of IComparable vs IComparer interfaces
            //very similar but IComparable would be used to have an object compare
            //itself to another object
            //IComparer would be used to have a class who's purpose is to compare them
            //Both can allow for sorting on special criteria
            List<Dog> dogList = new List<Dog>();
            dogList.Add(new Dog("Princess", "Orange", true));
            dogList.Add(new Dog("Bob", "Blue", true));
            dogList.Add(new Dog("Mark", "Black", true));

            List<Dog> dogList2 = new List<Dog>(dogList);

            Console.WriteLine($"{string.Join(", ", dogList)}");
            Console.WriteLine($"{string.Join(", ", dogList2)}");
            dogList.Sort();
            dogList2.Sort(new DogComparer());
            Console.WriteLine($"{string.Join(", ", dogList)}");
            Console.WriteLine($"{string.Join(", ", dogList2)}");

            //Basic factory method. Takes in a user parameter to help
            //decouple the implementation from the use
            //a user just calls the factory to make an object for them instead
            //of doing that setup themselves
            RemoteFactory factory = null;
            Console.Write("WHat type of controller do you want?: ");
            string request = Console.ReadLine();

            switch (request.ToLower()) {
                case "playstation":
                    factory = new PlaystationFactory(false, false, "Sony");
                    break;
                case "xbox":
                    factory = new XboxFactory(false, true, "Microsoft");
                    break;
                default:
                    break;
            }

            Remote remote = factory.GetRemote();
            Console.WriteLine("Remote information: ");
            Console.WriteLine($"Remote type: {remote.RemoteType}, Wired: {remote.Wire}, Batteries: {remote.Batteries}, Company: {remote.Company}");
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