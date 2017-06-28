using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MartinFerreiraOutsuranceTest
{
    public class LineItem
    {
        public string FirstName { get; set; }
        public string LastName { get;set;}
        public string Address { get;set;}
        public string PhoneNumber { get;set;}

        public string SortedAddress => Regex.Replace(Address, @"[^A-Za-z]+", "");

        public LineItem(string line) : this(line.Split(Constants.Seperator))
        {

        }

        public LineItem(string[] line) : this(line[0], line[1], line[2], line[3])
        {

        }

        public LineItem(string firstName, string lastName, string address, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            PhoneNumber = phoneNumber;
        }

    }
}
