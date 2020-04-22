using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Delegate_Exercise;
using ObjectLibrary;

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
        }

        /// <summary>
        /// Gets oldest people
        /// </summary>
        /// <returns></returns>
        public List<Person> GetOldest()
        {
            List<Person> ordered = People.OrderBy(p => p.Dob).ToList();
            List<Person> oldest = new List<Person>();

            foreach (Person person in ordered)
            {
                if (ordered[0].Dob.Equals(person.Dob))
                {
                    oldest.Add(person);
                }
            }

            return oldest; //-- return result here
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

            foreach (Person person in People)
            {
                //caseSesitive parameter will ignore case if true
                if (person.Surname.StartsWith(searchTerm, !caseSensitive, null))
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

            var groupedResult = People.OrderBy(p => p.Dob).ToList().GroupBy(p => p.Dob);

            foreach (var person in groupedResult)
            {
                //Question for Anh -- Values are only seperated by space in Test not by Tab
                result.Add($"{person.Key:dd/MM/yyyy} {person.Count()}");
            }

            return result;  //-- return result here
        }
    }
}