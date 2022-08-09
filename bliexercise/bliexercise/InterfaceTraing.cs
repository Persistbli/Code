using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bliexercise
{
    public class InterfaceTraing:IListable
    {
        public InterfaceTraing(string title ,string author, int year)
        {
            Title = title;
            Author = author;
            Year = year;
        }

        public string[] ColumnValues
        {
            get
            {
                return new string[]
                {
                    Title,
                    Author,
                    Year.ToString()
                };
            }
        }

        public string Title { get; private set; }
        public string Author { get; private set; }
        public int Year { get; private set; }
    }
    interface IListable
    {
        string[] ColumnValues
        {
            get;
        }
    }
    public abstract class pdaItem
    {
        public pdaItem(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
