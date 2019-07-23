using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EF
{
    class HostingDataLoader : DataLoader
    {
        protected override void Insert(HotelEntities db, XElement element)
        {
            db.hosting.Add(HostingFromElement(element));
        }

        hosting HostingFromElement(XElement element)
        {
            return new hosting()
            {
                guest_id = int.Parse(element.Element("guestId").Value),
                arrival = DateTime.Parse(element.Element("arrival").Value),
                departure = DateTime.Parse(element.Element("departure").Value),
                room = int.Parse(element.Element("room").Value),
                price = int.Parse(element.Element("price").Value)
            };
        }
    }
}
