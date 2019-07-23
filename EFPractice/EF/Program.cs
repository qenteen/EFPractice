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
            var guestLoader = new GuestDataLoader();
            guestLoader.DataPackSaved += LogProgress;
            guestLoader.LoadDataToServer(@"E:\people.xml", 500);

            Console.WriteLine("Work complete. Press anykey to exit");
            Console.ReadKey();
        }
    }
}
