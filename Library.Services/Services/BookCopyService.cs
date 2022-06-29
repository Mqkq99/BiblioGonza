using AutoMapper;
using Library.Services.Interfaces;
using Library.Services.ViewModels;
using LibraryApp.DAL;
using LibraryApp.DAL.Model;
namespace Library.Services.Services
{
    public class BookCopyService : IBookCopyService
    {
        private LibraryDbContext _context { get; set; }
        private IMapper _mapper;

        public BookCopyService(LibraryDbContext context,
            IMapper mapper)
        {
            _context = context != null ? context : throw new ArgumentNullException(nameof(context));
            _mapper = mapper != null ? mapper : throw new ArgumentNullException(nameof(mapper));
        }
        public string CreateBookCopy(BookCopyViewModel viewModel)
        {

            Guid guid = Guid.NewGuid();

            viewModel.Id = guid.ToString();

            BookCopy model = _mapper.Map<BookCopy>(viewModel);

            _context.BookCopies.Add(model);

            _context.SaveChanges();

            return viewModel.Id;

        }

        public BookCopyViewModel GetCopyBookById(string id)
        {
            var bookCopy = _context.BookCopies.Where(x => x.Id == id).FirstOrDefault();

            BookCopyViewModel viewModel = _mapper.Map<BookCopyViewModel>(bookCopy);

            return viewModel;
        }

        public BookViewModel GetBookById(string id)
        {
            var book = _context.Books.Where(x => x.Id == id).FirstOrDefault();

            BookViewModel viewModel = _mapper.Map<BookViewModel>(book);

            return viewModel;
        }
    }
}
