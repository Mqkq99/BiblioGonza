using AutoMapper;
using Library.Services.Interfaces;
using Library.Services.ViewModels;
using LibraryApp.DAL;
using LibraryApp.DAL.Model;

namespace Library.Services.Services
{
    public class BookService : IBookService
    {
        private LibraryDbContext _context { get; set; }
        private IMapper _mapper;

        public BookService(LibraryDbContext context,
            IMapper mapper)
        {
            _context = context != null ? context : throw new ArgumentNullException(nameof(context));
            _mapper = mapper != null ? mapper : throw new ArgumentNullException(nameof(mapper));
        }

        public BookViewModel GetBookById(string id)
        {
            var book = _context.Books.Where(x => x.Id == id).FirstOrDefault();

            var viewModel = book != null ? _mapper.Map<Book, BookViewModel>(book) : null;

            return viewModel;
        }

        public string CreateBook(BookViewModel viewModel)
        {
            try
            {
                //var model = _mapper.Map<BookViewModel, Book>(viewModel);

                Book model = new Book() { Title = viewModel.Title, Author = viewModel.Author };

                _context.Books.Add(model);

                _context.SaveChanges();

                return viewModel.Id;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
