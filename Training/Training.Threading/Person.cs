using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Threading {
    public class Person {
        private BankAccount Account;

        public string Name { get; set; }

        public Person(string name, BankAccount account) {
            this.Name = name;
            this.Account = account;
        }

        public void View() {
            Console.WriteLine($"{this.Name} has ${this.Account.ViewAccount()}");
        }

        public void Add(double amount) {
            double newBalance = this.Account.AddMoney(amount);
            Console.WriteLine($"{this.Name} depositied {amount}, new balance is {newBalance}");
        }

        public void Withdraw(double amount) {
            double newBalance = this.Account.WithdrawMoney(amount);
            Console.WriteLine($"{this.Name} Withdrew {amount}, new balance is {newBalance}");
        }
    }
}
 