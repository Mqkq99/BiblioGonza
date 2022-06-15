using System;
using System.Collections.Generic;
using System.Text;

namespace BiblioGonza.DAL.Model
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Dni { get; set; }
        public string PhoneNumber { get; set; }
    }
}
