using System;
using System.Collections.Generic;
using System.Text;

namespace BiblioGonza.DAL.Model
{
    public class Copy : BaseEntity
    {
        public bool Disponible { get; set; }

        public Book Book { get; set; }
    }
}
