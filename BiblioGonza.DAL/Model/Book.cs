using System;
using System.Collections.Generic;
using System.Text;

namespace BiblioGonza.DAL.Model
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Editorial { get; set; }
        public List<Copy> Copies { get; set; }
    }
}
