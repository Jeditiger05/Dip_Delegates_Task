using System;
using System.Collections.Generic;
using System.IO;
using FileParser;

namespace Delegate_Exercise
{
    class Delegate_Exercise
    {
        static void Main(string[] args)
        {
            string projectPath = Path.GetFullPath(@"..\..\..\..\");
            string readFile = $"{projectPath}TempFiles\\data.csv";
            string writeFile = $"{projectPath}TempFiles\\processed_data.csv";

            FileHandler fh = new FileHandler();
            DataParser dp = new DataParser();
            CsvHandler ch = new CsvHandler();
            string choice = "";

            while (!choice.Equals("3"))
            {
                Console.WriteLine("Select from the Following Options" +
                "\n1. Process CSV\n2. Process CSV using Parser \n3. Exit" +
                "\nNote Only Option 1 is formmated correctly to Pass all Tests");

                Console.Write("Enter Choice:  ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1"://Process CSV
                        Func<List<List<string>>, List<List<string>>> dataHandler = dp.StripWhiteSpace;
                        dataHandler += dp.StripQuotes;
                        dataHandler += RemoveHashes;
                        ch.ProcessCsv(readFile, writeFile, dataHandler);
                        Console.WriteLine($"\n{writeFile} file created\n");
                        break;
                    case "2"://Process CSV and Capitalise all Data using Parser
                        Parser parsee = dp.StripWhiteSpace;
                        parsee += dp.StripQuotes;
                        parsee += RemoveHashes;
                        parsee += CapData;
                        ch.ProcessCsv(readFile, writeFile, parsee);
                        Console.WriteLine($"\n{writeFile} file created using Parser Type\n");
                        break;
                    case "3"://Exits Program
                        break;
                    default:
                        Console.WriteLine("\nInvalid Option\n");
                        break;
                }
            }

            Console.WriteLine("\nGood Bye");
        }

        public static List<List<string>> RemoveHashes(List<List<string>> data)
        {
            foreach (var row in data)
            {
                for (var index = 0; index < row.Count; index++)
                {
                    if (row[index][0] == '#')
                        row[index] = row[index].Remove(0, 1);

                }
            }

            return data;
        }

        public static List<List<string>> CapData(List<List<string>> data)
        {
            foreach (List<string> row in data)
            {
                for (int i = 0; i < row.Count; i++)
                {
                    row[i] = row[i].ToUpper();
                }
            }

            return data;
        }
    }
}
