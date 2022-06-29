using AutoMapper;
using Library.Services.ViewModels;
using LibraryApp.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.MappingProfiles
{
    public class CustomerViewModelProfile : Profile
    {
        public CustomerViewModelProfile()
        {
            CreateMap<Customer, CustomerViewModel>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id)
                    )
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.Name)
                    )
                .ForMember(
                    dest => dest.Address,
                    opt => opt.MapFrom(src => src.Address)
                    );


        }
    }
}
