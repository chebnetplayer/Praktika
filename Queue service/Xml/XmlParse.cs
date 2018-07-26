using System.Xml.Linq;
using Queueservice.DataBase.Model;
using Queueservice.Model;

namespace Queueservice.Xml
{
    public static class XmlParse
    {
       public static Homework GetHomework(string xmlString)
       {
            var xdoc = XDocument.Parse(xmlString);
            return new Homework(xdoc.Element("name").Value, xdoc.Element("description").Value, bool.Parse(xdoc.Element("isdone").Value));
       }

        public static Equal GetEqual(string xmlString)
        {
            var xdoc = XDocument.Parse(xmlString);
            return new Equal(xdoc.Element(xdoc.Element("name").Value, "description").Value, bool.Parse(xdoc.Element("isdone").Value));
        }

        public static Walking GetWalking(string xmlString)
        {
            var xdoc = XDocument.Parse(xmlString);
            return new Walking(xdoc.Element(xdoc.Element("name").Value, "description").Value, bool.Parse(xdoc.Element("isdone").Value));
        }
    }
}
