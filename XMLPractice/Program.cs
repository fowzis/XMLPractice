using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace XMLPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            // check args
            if (args.Length < 1)
            {
                throw new ArgumentNullException("args[0]", "No XML File provided");
            }

            // check if file is found.
            string xmlFileName = args[0].ToString();
            if (!File.Exists(xmlFileName))
            {
                throw new FileNotFoundException("Error: File Not Found!", xmlFileName);
            }
            Console.WriteLine("File Name: {0}", xmlFileName);

            // Instaciate Settings Attributes Handler class.
            XMLSettingsHandler xmlSettings = new XMLSettingsHandler(@"d:\temp\eurofxref-daily.xml");

            Console.WriteLine("Setting:");
            xmlSettings.PrintSettings();

            XmlNode xmlNode = xmlSettings.FindNodeByAttributeValue("currency", "USD");
            XmlAttribute xmlAttrib = (XmlAttribute)xmlNode.Attributes.GetNamedItem("rate");
            if (xmlAttrib != null)
            {
                Console.WriteLine("Currency: USD, Rate: {0}", xmlAttrib.Value.ToString());
            }
            else
            {
                Console.WriteLine("Rate not found");
            }

            if (xmlSettings.SetAttributeValue(xmlNode, "rate", "123456789"))
            {
                Console.WriteLine("Rate changes Successfully");
            }
            
            Console.WriteLine("Press Any Key to exit.");
            Console.ReadLine();
        }
    }
}
