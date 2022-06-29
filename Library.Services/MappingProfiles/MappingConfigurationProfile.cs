using AutoMapper;
using Library.Services.ViewModels.Customers;
using LibraryApp.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
