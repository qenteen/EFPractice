using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EF
{
    class DataLoader
    {
        IEnumerable<XElement> _data;

        public event EventHandler<DataPackSavedEventArgs> DataPackSaved = delegate { };

        public void LoadDataToServer(string path, int dataPackSize, int from = 1)
        {
            LoadDataFromXml(path);
            IEnumerable<XElement> pack;
            while((pack = GetDataPack(from, dataPackSize)) != null)
            {
                SaveDataPack(pack);
                from += dataPackSize;
                OnDataPackSaved(new DataPackSavedEventArgs() { RecordAfterLastSaved = from});
            }
        }

        private void LoadDataFromXml(string path)
        {
            _data = GetContentFromRoot(XDocument.Load(path));
        }

        private IEnumerable<XElement> GetContentFromRoot(XDocument doc)
        {
            return doc.Elements().Elements();
        }

        private IEnumerable<XElement> GetDataPack(int from, int size)
        {
            return _data.Where(d => int.Parse(d.Attribute("id").Value) >= from
                                 && int.Parse(d.Attribute("id").Value) < from + size);
        }

        private void SaveDataPack(IEnumerable<XElement> pack)
        {
            HotelEntities hotel = new HotelEntities();
            foreach (var elem in pack)
            {
                hotel.hosting.Add(HostingFromElement(elem));
            }
            hotel.SaveChanges();
        }

        private hosting HostingFromElement(XElement element)
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

        private void OnDataPackSaved(DataPackSavedEventArgs e)
        {
            DataPackSaved?.Invoke(this, e);
        }
    }
}
