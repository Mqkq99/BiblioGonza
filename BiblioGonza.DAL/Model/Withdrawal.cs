using System;
using System.Collections.Generic;
using System.Text;

namespace BiblioGonza.DAL.Model
{
    public class Withdrawal : BaseEntity
    {
        public Copy Copy { get; set; }

        public Customer Customer { get; set; }
    }
}
