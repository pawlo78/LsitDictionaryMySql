using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LsitDictionaryMySql
{
    public class Persons
    {
        public int person_id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string location { get; set; }

        public Persons()
        { }

        public Persons(int id, string name, string surname, string location)
        {
            this.person_id = id;
            this.name = name;
            this.surname = surname;
            this.location = location;
        }
    }
}
