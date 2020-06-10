using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LsitDictionaryMySql
{
    public class CompareItemsClass : IComparer<Persons>
    {
        public int Compare(Persons x, Persons y)
        {
            int compareSurname = x.surname.CompareTo(y.surname);
            if (compareSurname == 0)
            {
                return x.name.CompareTo(y.name);
            }
            return compareSurname;
        }
    }
}
