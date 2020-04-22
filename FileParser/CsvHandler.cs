using System;
using System.Collections.Generic;

namespace FileParser
{
    public delegate List<List<string>> Parser(List<List<string>> data);

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
            char delimeter = ',';
            List<string> data = fh.ReadFile(readFile);
            fh.WriteFile(writeFile, delimeter, dataHandler(fh.ParseData(data, delimeter)));
        }

        /// <summary>
        /// Reads a csv file (readfile) and applies datahandling via Parser delegate and writes result as csv to writeFile.
        /// </summary>
        /// <param name="readFile"></param>
        /// <param name="writeFile"></param>
        /// <param name="parsee"></param>
        public void ProcessCsv(string readFile, string writeFile, Parser parsee)
        {
            FileHandler fh = new FileHandler();
            char delimeter = ',';
            List<string> data = fh.ReadFile(readFile);
            fh.WriteFile(writeFile, delimeter, parsee(fh.ParseData(data, delimeter)));
        }
    }
}