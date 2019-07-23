using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EF
{
    class Pack
    {

    }

    abstract class DataLoader
    {
        IEnumerable<XElement> _data;

        public event EventHandler<DataPackSavedEventArgs> DataPackSaved = delegate { };

        public void LoadDataToServer(string path, int dataPackSize, int from = 1)
        {
            LoadDataFromXml(path);
            IEnumerable<XElement> pack = GetDataPack(from, dataPackSize);
            while(pack.Count() != 0)
            {
                SaveDataPack(pack);
                from += dataPackSize;
                OnDataPackSaved(new DataPackSavedEventArgs() { RecordAfterLastSaved = from });
                pack = GetDataPack(from, dataPackSize);
            }
        }

        protected void LoadDataFromXml(string path)
        {
            _data = GetContentFromRoot(XDocument.Load(path));
        }

        protected IEnumerable<XElement> GetContentFromRoot(XDocument doc)
        {
            return doc.Elements().Elements();
        }

        protected IEnumerable<XElement> GetDataPack(int from, int size)
        {
            return _data.Where(d => int.Parse(d.Attribute("id").Value) >= from
                                 && int.Parse(d.Attribute("id").Value) < from + size);
        }

        protected void SaveDataPack(IEnumerable<XElement> pack)
        {
            HotelEntities hotel = new HotelEntities();
            foreach (var elem in pack)
            {
                Insert(hotel, elem);
            }
            hotel.SaveChanges();
        }

        abstract protected void Insert(HotelEntities db, XElement element);

        protected void OnDataPackSaved(DataPackSavedEventArgs e)
        {
            DataPackSaved?.Invoke(this, e);
        }
    }
}
