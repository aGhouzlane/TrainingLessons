using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Data;

namespace Training.Testing {
    public class SedanTests {
        Sedan testCar = null;

        [OneTimeSetUp]
        public void Init() {
            //cannot console.writeline ehre. it wont print
            //this is for debugging demo purposes
            Console.WriteLine("Wont print");
            //would be used to create a database schema
            //anything you need a single instance of
        }

        [SetUp]
        public void SetUp() {
            Console.WriteLine("Inside the setup method");
            testCar = new Sedan("1998", "Toyota", "Corolla");
        }

        //test driven development
        //write the tests first
        //then write the code that makes the tests pass
        [Test]
        public void EngineStarts() {
            //Sedan testCar = new Sedan();

            Assert.AreEqual("Vroom", testCar.StartEngine());
            //multiple asserts can be used, but may not be useful
            Assert.IsTrue(3 > 1);
            Assert.IsTrue(4 < 5);
            Assert.IsTrue(0 > 5);
        }

        [Test]
        [Ignore("This is deprecated")]
        public void StartEngineTestLegacy() {
            Assert.AreEqual(3, testCar.StartEngine());
        }

        [TestCase(19, ExpectedResult = "Full License")]
        [TestCase(18, ExpectedResult = "Full License")]
        [TestCase(17, ExpectedResult = "Learner's")]
        [TestCase(16, ExpectedResult = "Learner's")]
        [TestCase(15, ExpectedResult = "No Driving")]
        public string LicenseTest(int age) {
            return testCar.CanDrive(age);
        }

        //want to test multiple inputs
        [TestCase("2010", "Ford", "Mustang", ExpectedResult = "I am a 2010 Ford Mustang")]
        [TestCase("2019", "Nissan", "GTR", ExpectedResult = "I am a 2019 Nissan GTR")]
        [TestCase("2008", "Honda", "Civic", ExpectedResult = "I am a 2008 Honda Civic")]
        public string GetInfoTest(string year, string make, string model) {
            Sedan temp = new Sedan(year, make, model);

            return temp.GetInfo();
        }

        [Test]
        public void GetMileageThrows() {
            Assert.Throws<InvalidOperationException>(() => testCar.GetMileage());
        }

        [TearDown]
        public void TearDown() {
            Console.WriteLine("Inside the teardown method");
            testCar = null;
        }

        [OneTimeTearDown]
        public void CleanUp() {
            //same as the onetime setup but runs at the end
            //would get rid of anything you setup
            //also wont print
            Console.WriteLine("Wont print either");
        }
    }
}
