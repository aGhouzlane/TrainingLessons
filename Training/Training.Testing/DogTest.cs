using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Data;

namespace Training.Testing {
    //[TestFixture] optional attribute, it markes this file as a test file
    //is assumed as long as something in the file has the Test, TestCase, or TestCaseSource attribute
    public class DogTest {
        Dog myTestDog = new Dog("Ryan", "Blue", true); //usually you would not do this
        //you want fresh data to test with for every test

        //positive testing, tests that something succeeds
        [Test]
        public void DogMoves() {
            Dog testDog = new Dog("Test Dog", "Black", true);

            Assert.AreEqual("I run", testDog.Move());
        }

        [Test]
        public void DogSpeaks() {
            Dog testDog = new Dog("Test Dog", "Black", true);

            Assert.IsTrue(testDog.Speak().Equals("BARK!!!"));
        }

        [Test]
        public void DogCompareToFalseTest() {
            Dog testDog = new Dog("Adam", "Black", true);
            Dog testDog2 = new Dog("Mark", "Black", true);

            Assert.AreNotEqual(0, testDog.CompareTo(testDog2));
            Assert.IsTrue(testDog.CompareTo(testDog2) < 0);
        }
    }
}
