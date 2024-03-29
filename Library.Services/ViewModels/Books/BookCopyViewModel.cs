﻿using Library.Services.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.ViewModels.Books
{
    public class BookCopyViewModel : BaseViewModel
    {
        public string Title { get; set; }   
        public string Edition { get; set; }

        public int AvailableQuantity { get; set; }
    }
}
