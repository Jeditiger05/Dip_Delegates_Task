using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Delegate_Exercise;
using ObjectLibrary;
using System.Globalization;

namespace FileParser
{

    //public class Person { }  // temp class delete this when Person is referenced from dll

    public class PersonHandler
    {
        public List<Person> People;

        /// <summary>
        /// Converts List of list of strings into Person objects for People attribute.
        /// </summary>
        /// <param name="people"></param>
        public PersonHandler(List<List<string>> people)
        {
            People = new List<Person>();

            for (int i = 1; i < people.Count; i++)
            {
                People.Add(new Person(Convert.ToInt32(people[i][0]), people[i][1].ToString(), people[i][2].ToString(), new DateTime(Convert.ToInt64(people[i][3]))));
            }

            //Console.WriteLine(People.Count);

            //People = People.OrderBy(p => p.Dob).ToList();

            ////var grouppedResult = People.GroupBy(x => x.Dob);

            ////foreach (var pers in grouppedResult)
            ////{
            ////    Console.WriteLine(pers.Key);
            ////    Console.WriteLine(pers.Count());
            ////}

            //foreach (Person person in People)
            //{
            //    //Console.WriteLine($"\nIndex Of: {People.IndexOf(person)}\nID: {person.Id}\nFirst Name: {person.FirstName}\nLast Name: {person.Surname}\nDOB: {person.Dob.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)}");
            //    //Console.WriteLine(person.Surname.FirstOrDefault());
            //    Console.WriteLine(person.ToString());
            //}
            //Console.ReadLine();
        }

        /// <summary>
        /// Gets oldest people
        /// </summary>
        /// <returns></returns>
        public List<Person> GetOldest()
        {
            List<Person> Ordered = new List<Person>();
            List<Person> Oldest = new List<Person>();

            Ordered = People.OrderBy(p => p.Dob).ToList();

            foreach (Person person in Ordered)
            {
                if (Ordered[0].Dob.Equals(person.Dob))
                {
                    Oldest.Add(person);
                }
            }

            return Oldest; //-- return result here
        }

        /// <summary>
        /// Gets string (from ToString) of Person from given Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetString(int id)
        {
            return People[id].ToString();  //-- return result here
        }

        public List<Person> GetOrderBySurname()
        {
            return People.OrderBy(p => p.Surname).ToList();   //-- return result here
        }

        /// <summary>
        /// Returns number of people with surname starting with a given string.  Allows case-sensitive and case-insensitive searches
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <param name="caseSensitive"></param>
        /// <returns></returns>
        public int GetNumSurnameBegins(string searchTerm, bool caseSensitive)
        {
            int count = 0;

            foreach(Person person in People)
            {
                //caseSesitive parameter will ignore case if true using System.Globalization.CultureInfo
                if (person.Surname.StartsWith(searchTerm, !caseSensitive, CultureInfo.InvariantCulture))
                {
                    count++;
                }
            }
            return count;  //-- return result here
        }

        /// <summary>
        /// Returns a string with date and number of people with that date of birth.  Two values seperated by a tab.  Results ordered by date.
        /// </summary>
        /// <returns></returns>
        public List<string> GetAmountBornOnEachDate()
        {
            List<string> result = new List<string>();

            var groupedResult = People.OrderBy(p => p.Dob).ToList().GroupBy(x => x.Dob);

            foreach (var person in groupedResult)
            {
                //Question for Anh -- Values are only seperated by space in Test not by Tab
                result.Add($"{person.Key.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)} {person.Count()}");
            }

            return result;  //-- return result here
        }
    }
}