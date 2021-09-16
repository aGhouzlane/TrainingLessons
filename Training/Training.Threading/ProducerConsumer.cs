using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Training.Threading {
    public class ProducerConsumer {
        //hypothetically this is a supermarket,
        //producers are the farmers making food
        //consumers are consumers
        private readonly object mutex = new object();
        private int produce { get; set; }

        public ProducerConsumer() {
            produce = 0;
        }

        public void AddProduce(int amt) {
            lock(mutex) {
                Console.WriteLine($"Producer {Thread.CurrentThread.ManagedThreadId} is adding {amt} to produce");
                produce += amt;
                Console.WriteLine($"Producer {Thread.CurrentThread.ManagedThreadId} is pulsing other threads");

                Monitor.Pulse(mutex);
            }
        }

        public void ConsumeProduce(int amt) {
            lock(mutex) {
                Console.WriteLine($"Consumer {Thread.CurrentThread.ManagedThreadId} is trying to consume {amt}");
                while (produce < amt) {
                    Console.WriteLine($"Consumer {Thread.CurrentThread.ManagedThreadId} is waiting on {amt}");
                    Monitor.Wait(mutex);
                    Console.WriteLine($"Consumer {Thread.CurrentThread.ManagedThreadId} woke up");
                }
                Console.WriteLine($"Consumer {Thread.CurrentThread.ManagedThreadId} consumed {amt}");
                produce -= amt;
            }
        }
    }
}