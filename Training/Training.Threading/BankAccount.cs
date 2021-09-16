using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Threading {
    public class BankAccount {
        private readonly object mutex = new object();
        //you do not want two threads to change balance at the same time
        private double balance { get; set; }

        public BankAccount(double balance) {
            this.balance = balance;
        }

        //can happen at the same time
        public double ViewAccount() {
            return this.balance;
        }

        //do not want these to happen at the same time
        public double AddMoney(double amount) {
            lock(mutex) {
                balance += amount;
            }

            return balance;
        }

        public double WithdrawMoney(double amount) {
            lock(mutex) {
                if (amount <= balance) {
                    balance -= amount;
                }
            }

            return balance;
        }
    }
}
