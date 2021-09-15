using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training {
    public class Day3FileReader {
        //private const string testFile1 = @"C:\Skillstorm\Net Lessons\Training\Training\TestFile.txt";
        private const string emptyFile = @"C:\Skillstorm\Net Lessons\Training\Training\TestFileEmpty.txt";
        //private const string testFile2 = @"C:\Skillstorm\Net Lessons\Training\Training\TestFile2.txt";
        private const string csvFile = @"C:\Skillstorm\Net Lessons\Training\Training\Test.csv";

        private string file = ConfigurationManager.AppSettings.Get("TestFile");

        public void ReadFile() {
            try {
                string allText = File.ReadAllText(file);

                Console.WriteLine("Everything as one string:\n{0}\n", allText);

                string[] allLines = File.ReadAllLines(file);

                Console.WriteLine("Every line: ");
                foreach (string line in allLines) {
                    Console.WriteLine(line);
                }

                Console.WriteLine("\nOne line at a time: ");
                using(StreamReader reader = new StreamReader(file)) {
                    while (reader.Peek() > -1) {
                        string line = reader.ReadLine();
                        Console.WriteLine(line);
                    }
                }
            } catch (FileNotFoundException ex) {
                Console.WriteLine("File could not be found");
            }
        }

        public void WriteLines() {
            if (File.Exists(file)) {
                Console.WriteLine("The file exists, appending to it");
            } else {
                Console.WriteLine("The file doesn't exist, creating it");
            }

            using (StreamWriter writer = File.AppendText(file)) {
                writer.Write("This is a test line. ");
                writer.WriteLine("This adds to the pervious sentence.");
                writer.WriteLine("writes another line.");
                writer.WriteLine("The last line.");
                writer.WriteLine("--------------");
            }
        }

        public IEnumerable<CSVData> ReadCSV() {
            List<CSVData> retList = new List<CSVData>();

            using(StreamReader reader = new StreamReader(csvFile)) {
                while(!reader.EndOfStream) {
                    string line = reader.ReadLine();
                    string[] vals = line.Split(',');

                    retList.Add(new CSVData(vals[0], Convert.ToInt32(vals[1].Trim()), vals[2]));
                }
            }

            return retList;
        }
    }
}
