//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class residence
    {
        public int id { get; set; }
        public int guest_id { get; set; }
        public System.DateTime arrival { get; set; }
        public System.DateTime departure { get; set; }
        public string status { get; set; }
        public int room_num { get; set; }
        public decimal price { get; set; }
    }
}