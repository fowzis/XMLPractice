using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLPractice
{
    public class Customer
    {
        public string CustomerID { get; set; }      // <CustomerID>ALFKI</CustomerID>
        public string CompanyName { get; set; }     // <CompanyName>Alfreds Futterkiste</CompanyName>
        public string ContactName { get; set; }     // <ContactName>Maria Anders</ContactName>
        public string ContactTitle { get; set; }    // <ContactTitle>Sales Representative</ContactTitle>
        public string Address { get; set; }         // <Address>Obere Str. 57</Address>
        public string City { get; set; }            // <City>Berlin</City>
        public string PostalCode { get; set; }      // <PostalCode>12209</PostalCode>
        public string Country { get; set; }         // <Country>Germany</Country>
        public string Phone { get; set; }           // <Phone>030-0074321</Phone>
        public string Fax { get; set; }             // <Fax>030-0076545</Fax>
        public List<Order> Orders { get; set; }
    }
}
