using AutoMapper;
using Library.Services.ViewModels.Books;
using Library.Services.ViewModels.Customers;
using LibraryApp.DAL.Model;

namespace Library.Services.MappingProfiles
{
    public class MappingConfigurationProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "MappingConfigurationProfile";
            }
        }

        public MappingConfigurationProfile()
        {
            ConfigureMappings();
        }

        public void ConfigureMappings()
        {
            CreateMap<Customer, CustomerViewModel>().ReverseMap();
            CreateMap<Customer, CustomerListViewModel>().ReverseMap();
            CreateMap<Book, BookViewModel>().ReverseMap();
            CreateMap<BookCopy, BookCopyViewModel>().ReverseMap();
        }
    }
}
