using AutoMapper;
using Library.Services.ViewModels.Books;
using Library.Services.ViewModels.BookCopies;
using Library.Services.ViewModels.Customers;
using Library.Services.ViewModels.Withdrawals;
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
            CreateMap<Customer, CustomerViewModel>()
                .ForMember(
                    dest => dest.Withdrawals,
                    opt => opt.MapFrom(src => src.Withdrawals))
                .ReverseMap();

            CreateMap<Customer, CustomerListViewModel>().ReverseMap();

            CreateMap<Customer, CustomerCreateViewModel>().ReverseMap();

            CreateMap<CustomerViewModel, CustomerCreateViewModel>().ReverseMap();

            CreateMap<Book, BookViewModel>()
                .ForMember(
                    dest => dest.BookCopies,
                    opt => opt.MapFrom(src => src.BookCopies))
                .ReverseMap();

            CreateMap<BookCopy, BookCopyViewModel>().ReverseMap();

            CreateMap<BookCopy, BookCopySearchViewModel>()
                 .ForMember(
                    dest => dest.Author,
                    opt => opt.MapFrom(src => src.Book.Author))
                .ForMember(
                    dest => dest.Title,
                    opt => opt.MapFrom(src => src.Book.Title))
                .ReverseMap();

            CreateMap<Withdrawal, WithdrawalViewModel>().ReverseMap();

            CreateMap<Withdrawal, WithdrawalCreateViewModel>().ReverseMap();

            CreateMap<Withdrawal, WithdrawalDetailViewModel>()
                .ForMember(
                    dest => dest.BookCopyViewModel,
                    opt => opt.MapFrom(src => src.BookCopy))
                .ForMember(
                    dest => dest.CustomerViewModel,
                    opt => opt.MapFrom(src => src.Customer))
                .ReverseMap();

            CreateMap<Withdrawal, WithdrawalListViewModel>()
                .ForMember(
                    dest => dest.BookTitle,
                    opt => opt.MapFrom(src => src.BookCopy.Book.Title))
                .ForMember(
                    dest => dest.CustomerId,
                    opt => opt.MapFrom(src => src.Customer.Id))
                .ReverseMap();
            CreateMap<BookCopy, BookCopyCreateViewModel>().ReverseMap();
           
        }
    }
}
