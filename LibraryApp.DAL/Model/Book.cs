﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.DAL.Model
{
    public class Book : EntityBase
    {
        public string Author { get; set; }

        public string Title { get; set; }

        public string Falopa { get; set; }

    }
}