using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EF
{
    class GuestDataLoader : DataLoader
    {
        protected override void Insert(HotelEntities db, XElement element)
        {
            db.guest.Add(GuestFromElement(element));
        }

        protected guest GuestFromElement(XElement element)
        {
            return new guest()
            {
                id = int.Parse(element.Attribute("id").Value),
                name = element.Element("name").Value,
                sex = element.Element("sex").Value,
                birth = DateTime.Parse(element.Element("birth").Value),
                country = element.Element("country").Value,
                address = element.Element("address").Value
            };
        }
    }
}
