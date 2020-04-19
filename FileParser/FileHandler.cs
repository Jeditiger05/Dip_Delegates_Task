using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace FileParser
{
    public class FileHandler
    {
        public FileHandler() { }

        /// <summary>
        /// Reads a file returning each line in a list.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public List<string> ReadFile(string filePath)
        {
            List<string> lines = new List<string>();

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    while (!sr.EndOfStream)
                    {
                        lines.Add(sr.ReadLine());
                    }
                }                    
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }

            return lines; //-- return result here
        }


        /// <summary>
        /// Takes a list of a list of data.  Writes to file, using delimeter to seperate data.  Always overwrites.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="delimeter"></param>
        /// <param name="rows"></param>
        public void WriteFile(string filePath, char delimeter, List<List<string>> rows)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    foreach (List<string> row in rows)
                    {
                        sw.WriteLine(string.Join(delimeter.ToString(), row));
                    }

                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }

        }

        /// <summary>
        /// Takes a list of strings and seperates based on delimeter.  Returns list of list of strings seperated by delimeter.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public List<List<string>> ParseData(List<string> data, char delimiter)
        {
            List<List<string>> result = new List<List<string>>();
            string[] split;

            foreach (string line in data)
            {
                result.Add(new List<string>());
                split = line.Split(delimiter);

                foreach (string str in split)
                {
                    result[result.Count - 1].Add(str);
                }
            }

            return result; //-- return result here
        }

        /// <summary>
        /// Takes a list of strings and seperates on comma.  Returns list of list of strings seperated by comma.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> ParseCsv(List<string> data)
        {
            List<List<string>> newList = new List<List<string>>();
            string[] split;

            foreach (string line in data)
            {
                newList.Add(new List<string>());
                split = line.Split(',');

                foreach (string str in split)
                {
                    newList[newList.Count - 1].Add(str);
                }
            }

            return newList;  //-- return result here
        }
    }
}