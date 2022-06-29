using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers
{
    public class BookCopyController : Controller
    {
      
        public IActionResult Create()
        {
            
            return View("Create");
        }
    }
}
