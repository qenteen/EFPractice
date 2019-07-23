using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;

namespace EF
{
    class Program
    {
        static void LogProgress(object sender, DataPackSavedEventArgs e)
        {
            Console.Write($"{e.RecordAfterLastSaved}\r");
            using (var writer = new StreamWriter(@"E:\progress.txt"))
            {
                writer.Write(e.RecordAfterLastSaved.ToString());
            }
        }

        static void Main(string[] args)
        {
            var loader = new DataLoader();
            loader.DataPackSaved += LogProgress;
            loader.LoadDataToServer(@"E:\hosting.xml", 500, 35001);

            //var hotel = new HotelEntities();
            //var host = new hosting()
            //{
            //    //id = 1,
            //    guest_id = 6,
            //    arrival = new DateTime(2000, 1, 1),
            //    departure = new DateTime(2000, 1, 5),
            //    room = 2001,
            //    price = 500
            //};
            //hotel.hosting.Add(host);
            //hotel.SaveChanges();

            Console.WriteLine("Work complete. Press anykey to exit");
            Console.ReadKey();
        }
    }
}
