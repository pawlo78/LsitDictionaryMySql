using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LsitDictionaryMySql
{
    class Program
    {
        static void Main(string[] args)
        {
            //create object myMySqlClass
            myMySqlClass mySql = new myMySqlClass();
            //clearing up database
            mySql.Delete("Delete from person");
            //adding records
            mySql.Insert("INSERT INTO person(name, surname, location) Value('Matt', 'Scott', 'Bielsko-Biała')");
            mySql.Insert("INSERT INTO person(name, surname, location) Value('Robert', 'Mirror', 'Szczyrk')");
            mySql.Insert("INSERT INTO person(name, surname, location) Value('Daniel', 'Rose', 'Wisła')");
            mySql.Insert("INSERT INTO person(name, surname, location) Value('Michael', 'Nielsen', 'Żywiec')");
            mySql.Insert("INSERT INTO person(name, surname, location) Value('Agnes', 'Jackson', 'Łodygowice')");
            //updating records
            mySql.Update("UPDATE person set name = 'Paul' where surname = 'Jackson'");
            //deleting records
            mySql.Delete("Delete from person where location = 'Bielsko-Biała'");

            //createing object List            
            List<Persons> listView = new List<Persons>();
            //query for records in the database
            listView = mySql.GetData("select * from person");

            //sorting rekords
            IComparer<Persons> comparer = new CompareItemsClass();
            listView.Sort(comparer);

            //variable: holds the key Dictionary
            int noKey = 0;

            //creating object Dictionary
            Dictionary<int, Persons> dictionaryView = new Dictionary<int, Persons>();

            //assign List to Dictionary
            foreach (var item in listView)
            {
                noKey++;
                dictionaryView.Add(noKey, new Persons(item.person_id, item.name, item.surname, item.location));
            }

            //displaing data
            foreach (var item in dictionaryView)
            {
                Console.WriteLine(item.Key + " | " + item.Value.person_id + " | " + item.Value.name + " | " + item.Value.surname + " | " + item.Value.location);
            }

            Console.ReadKey();
        }

    }
}
