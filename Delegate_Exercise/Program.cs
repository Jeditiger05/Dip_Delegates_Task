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
            string readFile = Directory.GetCurrentDirectory() + "/TempFiles/data.csv";
            string writeFile = Directory.GetCurrentDirectory() + "/TempFiles/processed_data.csv";
            FileHandler fh = new FileHandler();
            DataParser dp = new DataParser();
            CsvHandler ch = new CsvHandler();

            //Process CSV
            Func<List<List<string>>, List<List<string>>> dataHandler = dp.StripWhiteSpace;
            dataHandler += dp.StripQuotes;
            dataHandler += RemoveHashes;
            ch.ProcessCsv(readFile, writeFile, dataHandler);

            //Process CSV and Capitalise all Data using Parser
            //Parser parsee = dp.StripWhiteSpace;
            //parsee += dp.StripQuotes;
            //parsee += RemoveHashes;
            //parsee += CapData;
            //ch.ProcessCsvCap(readFile, writeFile, parsee.Invoke);

            List<string> data = fh.ReadFile(readFile);
            List<List<string>> parsedData = fh.ParseData(data, ',');
            //dp.StripWhiteSpace(parsedData);
            //dp.StripQuotes(parsedData);
            //RemoveHashes(parsedData);

            PersonHandler ph = new PersonHandler(parsedData);

        }

        public static List<List<string>> RemoveHashes(List<List<string>> data) {
            foreach(var row in data) {
                for (var index = 0; index < row.Count; index++) {
                    if(row[index][0] == '#')
                        row[index] = row[index].Remove(0,1);
 
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
