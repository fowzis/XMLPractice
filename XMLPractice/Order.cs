using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLPractice
{
    public class Order
    {
        public int OrderID { get; set; }

        public string CustomerID { get; set; }

        public int EmployeeID { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime RequiredDate { get; set; }

        public DateTime ShippedDate { get; set; }

        public int ShipVia { get; set; }   // this will be change to a nullabel type as show in the commented example below.

        //[XmlIgnore]
        //public int? ShipVia { get; set; }

        //[XmlElement("ShipVia")]
        //public string ShipVia_Proxy
        //{
        //    get
        //    {
        //        return ShipVia.HasValue ? ShipVia.ToString() : string.Empty;
        //    }
        //    set
        //    { 
        //        if ( !string.IsNullOrEmpty(value))
        //        {
        //            ShipVia = Int32.Parse(value);
        //        }
        //    }
        //}

        public decimal Freight { get; set; }

        public string ShipName { get; set; }

        public string ShipAddress { get; set; }

        public string ShipCity { get; set; }

        public string ShipRegion { get; set; }

        public string ShipPostalCode { get; set; }

        public string ShipCountry { get; set; }

        //[XmlArray("Order_Details")]
        //public List<Product_Order_Detail> Product_Order_Details1 { get; set; }

    }
}
