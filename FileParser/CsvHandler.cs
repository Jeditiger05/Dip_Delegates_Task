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

            //Read File
            List<List<string>> formatted = fh.ParseCsv(fh.ReadFile(readFile));

            //call in sequence added methods to format data
            //Strip White Spaces
            dataHandler(formatted);
            //Strip Quotes
            dataHandler(formatted);
            //Strip Hashes
            dataHandler(formatted);

            fh.WriteFile(writeFile, ',', formatted);
        }

        public void ProcessCsvCap(string readFile, string writeFile, Func<List<List<string>>, List<List<string>>> parsee)
        {
            FileHandler fh = new FileHandler();

            //Read File
            List<List<string>> formatted = fh.ParseCsv(fh.ReadFile(readFile));

            //Strip White Space
            parsee(formatted);
            //Strip Quotes
            parsee(formatted);
            //Strip Hashes
            parsee(formatted);
            //Capitalise all Data
            parsee(formatted);

            fh.WriteFile(writeFile, ',', formatted);
        }
    }
}