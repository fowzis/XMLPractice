using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace XMLPractice
{
    class XMLSettingsHandler
    {
        //private static readonly string xmlFile = @"c:\temp\eurofxref-daily.xml";

        public string SettingsFile { get; private set; }
        XmlDocument xmlDoc = null;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="xmlSettngsFileName"></param>
        public XMLSettingsHandler(string xmlSettngsFileName)
        {
            SettingsFile = xmlSettngsFileName;
            ReadSettingsXMLFile();
        }

        /// <summary>
        /// Distructor
        /// </summary>
        ~XMLSettingsHandler()
        {
        }

        /// <summary>
        /// Read the settings form an XML File
        /// </summary>
        private void ReadSettingsXMLFile()
        {
            try
            {
                xmlDoc = new XmlDocument();
                xmlDoc.Load(SettingsFile);
            }
            catch (Exception ex)
            {
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine(ex.ToString());
                Console.WriteLine("--------------------------------------------------");

                throw;
            }
        }

        public void PrintSettings()
        {
            // Return all<Cube> elements in the document. Even with different attributes
            //XmlNodeList xmlNodeList = xmlDoc.SelectNodes("//Envelope/Cube/Cube/Cube");
            //XmlNodeList xmlNodeList = xmlDoc.SelectNodes("//Envelope");
            XmlNodeList xmlNodeList = xmlDoc.SelectNodes("//Cube/Cube/Cube");
            if (xmlNodeList.Count > 0)
            {
                // Loop the nodes
                foreach (XmlNode xmlNode in xmlNodeList)
                { 
                    Console.Write("Node: {0}, ", xmlNode.Name);

                    // If node has attributes
                    if (xmlNode.Attributes.Count > 0)
                    {
                        // Get Nde attributes collection
                        XmlAttributeCollection xmlAttribCollection = xmlNode.Attributes;

                        // Check if the node has specific attributes Currency and Rate
                        XmlNode xmlCurrency = (XmlAttribute)xmlAttribCollection.GetNamedItem("currency");
                        XmlNode xmlRate = (XmlAttribute)xmlAttribCollection.GetNamedItem("rate");

                        // If found
                        if (xmlCurrency != null && xmlRate != null)
                        {
                            // Get the attribute values and print them
                            string currency = xmlAttribCollection["currency"].Value;
                            float rate = float.Parse(xmlAttribCollection["rate"].Value);
                            Console.WriteLine("Currency: {0}, Rate: {1}", currency, rate);
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Find a node having a specific attribute name and value in a the XML 
        /// for instance Node have currency=USD, and return the rate
        /// </summary>
        /// <param name="attribName">The node attribute name 'currency'</param>
        /// <param name="attribValue">The attribute value (ex. USD)</param>
        /// <returns></returns>
        // public string GetAttributeVale(string attribName, string attribValue)
        public XmlNode FindNodeByAttributeValue(string attribName, string attribValue)
        {
            XmlNode xmlNode = null;
            //XmlNode xmlAttribVal = null;

            //XmlNodeList xmlNodeList = SelectNodes("//ElementName[@AttributeName='AttributeValue']")
            xmlNode = xmlDoc.SelectSingleNode("//Cube[@" + attribName + "='" + attribValue + "']");
            if (xmlNode == null)
                return null;
            
            //xmlAttribVal = (XmlAttribute)xmlNode.Attributes.GetNamedItem(attribValue);
            //if (xmlAttribVal == null)
            //    return null;
            
            return xmlNode;
        }

        /// <summary>
        /// Change the value of a certain attribute in a node in the XML Document
        /// </summary>
        /// <param name="xmlNode"></param>
        /// <param name="attribName"></param>
        /// <param name="attribValue"></param>
        /// <returns></returns>
        public bool SetAttributeValue(XmlNode xmlNode, string attribName, string attribValue)
        {
            if (xmlNode == null || 
                String.IsNullOrWhiteSpace(attribName) || 
                String.IsNullOrWhiteSpace(attribValue))
            {
                return false;
            }

            // Locate the node of the attribute to change
            XmlAttribute xmlAttrib = (XmlAttribute)xmlNode.Attributes.GetNamedItem(attribName);
            if (xmlAttrib == null)
            {
                return false;
            }

            // Set the new value
            xmlAttrib.Value = attribValue;

            //Save the xml
            xmlDoc.Save(SettingsFile);
            return true;
        }
    }
}
