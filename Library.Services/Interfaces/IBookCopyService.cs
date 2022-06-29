using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Interfaces
{
    internal interface IBookCopyService
    {
        IBookCopyService GetBookById(string id);

    }
}
