using AutoMapper;
using Library.Services.Interfaces;
using Library.Services.ResultDTOs;
using Library.Services.ViewModels;
using Library.Services.ViewModels.BookCopies;
using Library.Services.ViewModels.Books;
using LibraryApp.DAL;
using LibraryApp.DAL.Model;
using Microsoft.EntityFrameworkCore;

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

        public ValueResult<string> Create(BookCopyCreateViewModel viewModel, string bookId)
        {
            var book = GetBookById(bookId);

            Guid guid = Guid.NewGuid();

            viewModel.Id = guid.ToString();

            BookCopy model = _mapper.Map<BookCopy>(viewModel);

            model.Book = book;

            book.BookCopies.Add(model);

            model.AvailableQuantity = model.TotalQuantity; 

            _context.BookCopies.Add(model);

            _context.SaveChanges();

            return ValueResult<string>.Ok(viewModel.Id);
        }

        public ValueResult<BookCopyCreateViewModel> GetById(string id)
        {
            var bookCopy = _context.BookCopies
                .Include(x=> x.Book)
                .Where(x => x.Id == id).FirstOrDefault();

            BookCopyCreateViewModel viewModel = _mapper.Map<BookCopyCreateViewModel>(bookCopy);


            return ValueResult<BookCopyCreateViewModel>.Ok(viewModel);
        }
       
        private BookViewModel GetBookViewModelById(string id)
        {
            var book = _context.Books.Where(x => x.Id == id).FirstOrDefault();

            BookViewModel viewModel = _mapper.Map<BookViewModel>(book);

            return viewModel;
        }

        public ValueResult<BookCopyCreateViewModel> CreateInizialization(string id)
        {
            var book = GetBookViewModelById(id);
            var copy = new BookCopyCreateViewModel()
            {
                Book = book
            };
            return ValueResult<BookCopyCreateViewModel>.Ok(copy);

        }

        private Book GetBookById(string id)
        {
            var book = _context.Books
                .Include(x => x.BookCopies)
                .Where(x => x.Id == id)
                .FirstOrDefault();


            return book;
        }

        public ValueResult<List<BookCopySearchViewModel>> Search(string title)
        {
            try
            {
                var copies = _context.BookCopies
                    .Include(x => x.Book)
                    .Where(x => x.Book.Title.Contains(title) && !x.Disabled && x.AvailableQuantity > 0);

                List<BookCopySearchViewModel> copiesList = _mapper.Map<List<BookCopySearchViewModel>>(copies);

                return ValueResult<List<BookCopySearchViewModel>>.Ok(copiesList);
            }
            catch (Exception ex)
            {
                return ValueResult<List<BookCopySearchViewModel>>.Error(ex.Message);
            }
        }

        public ValueResult<BookCopyCreateViewModel> Update(BookCopyCreateViewModel viewModel)
        {
            try
            {
                BookCopy copy = _context.BookCopies.Where(x => x.Id == viewModel.Id).FirstOrDefault();

                if(copy != null)
                {
                    copy.TotalQuantity = viewModel.TotalQuantity;

                    _context.Update(copy);
                    _context.SaveChanges();

                    return ValueResult<BookCopyCreateViewModel>.Ok(viewModel); 
                }
                else
                    return ValueResult<BookCopyCreateViewModel>.NotFound();

            }
            catch (Exception ex)
            {
                return ValueResult<BookCopyCreateViewModel>.Error(ex.Message);
            }
        }

        public ValueResult<bool> Delete(string id)
        {
            try
            {
                var bookCopy = _context.BookCopies.Where(x => x.Id == id).FirstOrDefault();

                if (bookCopy != null)
                {
                    bookCopy.Disabled = true;
                    _context.Update(bookCopy);
                    _context.SaveChanges();

                    return ValueResult<bool>.Ok(true);
                }
                else
                {
                    return ValueResult<bool>.NotFound();
                }
            }
            catch (Exception ex)
            {
                return ValueResult<bool>.Error(ex.Message);
            }
        }
    }
}
