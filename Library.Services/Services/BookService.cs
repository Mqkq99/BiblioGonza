using AutoMapper;
using Library.Services.Interfaces;
using Library.Services.ResultDTOs;
using Library.Services.ViewModels.Books;
using LibraryApp.DAL;
using LibraryApp.DAL.Model;
using Microsoft.EntityFrameworkCore;

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

        public ValueResult<BookViewModel> GetById(string id)
        {
            try
            {
                var book = _context.Books
                    .Include(x => x.BookCopies)
                    .Where(x => x.Id == id && !x.Disabled).FirstOrDefault();

                if (book != null)
                {
                    var viewModel = _mapper.Map<Book, BookViewModel>(book);

                    return ValueResult<BookViewModel>.Ok(viewModel);
                }
                else
                {
                    return ValueResult<BookViewModel>.NotFound();
                }
            }
            catch (Exception ex)
            {
                return ValueResult<BookViewModel>.Error(ex.Message);
            }
        }

        public ValueResult<string> Create(BookViewModel viewModel)
        {
            try
            {
                var model = _mapper.Map<BookViewModel, Book>(viewModel);

                model.Id = Guid.NewGuid().ToString();

                _context.Books.Add(model);

                _context.SaveChanges();

                return ValueResult<string>.Ok(model.Id);
            }
            catch(Exception ex)
            {
                return ValueResult<string>.Error(ex.Message);
            }
        }

        public ValueResult<List<BookListViewModel>> GetAll()
        {
            try
            {
                List<BookListViewModel> customerList = _mapper.Map<List<BookListViewModel>>(_context.Books.Where(x => !x.Disabled));

                return ValueResult<List<BookListViewModel>>.Ok(customerList);
            }
            catch (Exception ex)
            {
                return ValueResult<List<BookListViewModel>>.Error(ex.Message);
            }
        }

        public ValueResult<BookViewModel> Update(BookViewModel viewModel)
        {
            try
            {
                Book book = _mapper.Map<Book>(viewModel);

                _context.Update(book);
                _context.SaveChanges();

                return ValueResult<BookViewModel>.Ok(viewModel); ;
            }
            catch (Exception ex)
            {
                return ValueResult<BookViewModel>.Error(ex.Message);
            }
        }

        public ValueResult<bool> Delete(string id)
        {
            try
            {
                var book = _context.Books.Where(x => x.Id == id).FirstOrDefault();

                if (book != null)
                {
                    book.Disabled = true;
                    _context.Update(book);
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

        public ValueResult<List<BookViewModel>> getAll()
        {
            try
            {
                List<BookViewModel> bookList = _mapper.Map<List<BookViewModel>>(_context.Books.Where(x => !x.Disabled));

                return ValueResult<List<BookViewModel>>.Ok(bookList);
            }
            catch (Exception ex)
            {
                return ValueResult<List<BookViewModel>>.Error(ex.Message);
            }
        }

     
    }
}
