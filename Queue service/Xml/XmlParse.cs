using System.Xml.Linq;
using Queueservice.Model;

namespace Queueservice.Xml
{
    public class XmlParse
    {
       public Homework GetHomework(string xmlString)
       {
            var xdoc = XDocument.Parse(xmlString);
            return new Homework(xdoc.Element("description").Value, xdoc.Element("subject").Value, bool.Parse(xdoc.Element("isdone").Value));
       }

        public Equal GetEqual(string xmlString)
        {
            var xdoc = XDocument.Parse(xmlString);
            return new Equal(xdoc.Element("description").Value, xdoc.Element("eq").Value, bool.Parse(xdoc.Element("isdone").Value));
        }

        public Walking GetWalking(string xmlString)
        {
            var xdoc = XDocument.Parse(xmlString);
            return new Walking(xdoc.Element("description").Value, xdoc.Element("where").Value, bool.Parse(xdoc.Element("isdone").Value));
        }
    }
}
