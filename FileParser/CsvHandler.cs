using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using FileParser;

namespace Delegate_Exercise
{
    public class CsvHandler
    {
        /// <summary>
        /// Reads a csv file (readfile) and applies datahandling via dataHandler delegate and writes result as csv to writeFile.
        /// </summary>
        /// <param name="readFile"></param>
        /// <param name="writeFile"></param>
        /// <param name="dataHandler"></param>
        public void ProcessCsv(string readFile, string writeFile, Func<List<List<string>>, List<List<string>>> dataHandler)
        {
            FileHandler fh = new FileHandler();

            List<List<string>> data = fh.ParseCsv(fh.ReadFile(readFile));

            dataHandler(data);

            fh.WriteFile(writeFile, ',', data);
        }

        public void ProcessCsvCap(string readFile, string writeFile, Func<List<List<string>>, List<List<string>>> parsee)
        {
            FileHandler fh = new FileHandler();

            List<List<string>> data = fh.ParseCsv(fh.ReadFile(readFile));

            parsee.Invoke(data);

            fh.WriteFile(writeFile, ',', data);
        }
    }
}