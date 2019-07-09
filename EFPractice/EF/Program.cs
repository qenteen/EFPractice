using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new HotelEntities();
            var guest = new guest()
            {
                id = 2,
                name = "Алёшка",
                sex = "M",
                birth = new DateTime(1982, 4, 10),
                country = "Россия",
                address = "Не дом и не улица"
            };

            db.guest.Add(guest);
            db.SaveChanges();
        }
    }
}
