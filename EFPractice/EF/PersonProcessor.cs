using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EF
{
    class PersonProcessor
    {
        public IEnumerable<guest> GetPersonFromXml(string file)
        {
            var doc = XDocument.Load(file);
            var root = doc.Elements();

            foreach (var person in root.Elements())
            {
                var guest = new guest()
                {
                    id = int.Parse(person.Attribute("id").Value),
                    name = person.Element("name").Value,
                    birth = DateTime.Parse(person.Element("birth").Value),
                    sex = person.Element("sex").Value,
                    country = person.Element("country").Value,
                    address = person.Element("address").Value
                };

                yield return guest;
            }
        }
    }
}
