using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training {
    //T is a type that tells the program the class is generic
    public class Day3<T> {
        private class Node {
            public Node Next { get; set; }
            public T Data { get; set; }

            public Node(T t) {
                Next = null;
                Data = t;
            }
        }

        private Node head;

        public Day3() {
            head = null;
        }

        public void AddHead(T t) {
            Node n = new Node(t);
            n.Next = head;
            head = n;
        }

        public void Print() {
            Node current = head;

            while (current != null) {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }

        public T Get(int i) {
            int count = 0;
            Node current = head;

            while (count < i) {
                current = current.Next;
                count++;
            }

            return current.Data;
        }
    }
}
