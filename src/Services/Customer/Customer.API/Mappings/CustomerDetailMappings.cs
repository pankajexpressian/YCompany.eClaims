using AutoMapper;
using Customer.API.Domain.Entities;
using Customer.API.Application.Dto;
using System.Collections.Generic;

namespace Customer.API.Mappings
{
    public class CustomerDetailMappings:Profile
    {
        public CustomerDetailMappings()
        {
            CreateMap<CustomerDetailDto, CustomerDetail>().ReverseMap();
            //CreateMap<IEnumerable<CustomerDetailDto>, IEnumerable<CustomerDetail>>().ReverseMap();
        }
    }
}
