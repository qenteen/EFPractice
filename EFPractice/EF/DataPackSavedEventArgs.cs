using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
    class DataPackSavedEventArgs : EventArgs
    {
        public int RecordAfterLastSaved { get; set; }
    }
}
