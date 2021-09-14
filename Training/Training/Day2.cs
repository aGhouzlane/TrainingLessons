using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Data;

namespace Training {
    public class Day2 {
        private List<Day1> items;

        public Day2() {

        }

        public void ObjectPassed(Day1 item) {
            //would have to clone to spot changes from happening
            Day1 temp = new Day1();
            temp.Id = item.Id;
            temp.Name = item.Name;
        }

        //ref keyword indivates a pointer
        public void PrimitivePassed(ref int i) {
            i = 75;
        }

        public void Save(Day1 newItem) {
            //saves it
        }

        public void Remove(Day1 item) {
            try {
                if (item.Id == 75) {
                    throw new WrongItemException("Wrong item");
                } 
            } catch (WrongItemException e) {
                Console.WriteLine(e.Message);
            }
        }

        public void Get(int index) {
            //gets it
        }
    }
}
