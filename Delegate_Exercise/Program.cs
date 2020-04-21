using System;
using System.Collections.Generic;
using System.IO;
using FileParser;

public delegate List<List<string>> Parser(List<List<string>> data);

namespace Delegate_Exercise
{
    class Delegate_Exercise
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(System.IO.Path.GetFullPath(@"..\..\..\..\"));

            string readFile = Path.GetFullPath(@"..\..\..\..\") + "/TempFiles/data.csv";
            string writeFile = Path.GetFullPath(@"..\..\..\..\") + "/TempFiles/processed_data.csv";
            FileHandler fh = new FileHandler();
            DataParser dp = new DataParser();
            CsvHandler ch = new CsvHandler();
            int choice = 0;


            while (choice != 3)
            {
                Console.WriteLine("Select from the Following Options" +
                "\n1. Process CSV\n2. Process CSV using Parser \n3. Exit\n" +
                "\nNote the PersonHandler Tests will not pass with Option 2!");

                Console.Write("Enter Choice:  ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1://Process CSV
                        Func<List<List<string>>, List<List<string>>> dataHandler = dp.StripWhiteSpace;
                        dataHandler += dp.StripQuotes;
                        dataHandler += RemoveHashes;
                        ch.ProcessCsv(readFile, writeFile, dataHandler);
                        Console.WriteLine("TempFiles/processed_data.csv file created");
                        break;
                    case 2://Process CSV and Capitalise all Data using Parser
                        Parser parsee = dp.StripWhiteSpace;
                        parsee += dp.StripQuotes;
                        parsee += RemoveHashes;
                        parsee += CapData;
                        ch.ProcessCsvCap(readFile, writeFile, parsee.Invoke);
                        Console.WriteLine("TempFiles/processed_data.csv file created using Parser delegate");
                        break;
                    case 3:
                        break;
                }
            }
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
