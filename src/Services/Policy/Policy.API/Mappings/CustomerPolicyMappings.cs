using AutoMapper;
using Policy.API.Application.Dto;
using Policy.API.Domain.Entities;

namespace Policy.API.Mappings
{
    public class CustomerPolicyMappings : Profile
    {
        public CustomerPolicyMappings()
        {
            CreateMap<CustomerPolicy, CustomerPolicyDto>().ReverseMap();
        }
    }
}
