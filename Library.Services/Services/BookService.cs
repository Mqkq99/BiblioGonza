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

            BookViewModel viewModel = new BookViewModel() { Author = book.Author, Id = book.Id, Title = book.Title };

            return viewModel;
        }

        public string CreateBook(BookViewModel viewModel)
        {

            Guid guid = Guid.NewGuid();

            viewModel.Id = guid.ToString();

            Book model = new Book() { Title = viewModel.Title, Author = viewModel.Author, Id = viewModel.Id };

            _context.Books.Add(model);

            _context.SaveChanges();

            return viewModel.Id;

        }
    }
}
