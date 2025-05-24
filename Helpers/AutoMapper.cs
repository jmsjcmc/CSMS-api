using AutoMapper;
using Csms_api.Models;

namespace Csms_api.Helpers
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<BusinessUnitRequest, BusinessUnit>();

            CreateMap<BusinessUnit, BusinessUnitResponse>();

            CreateMap<Company, CompanyResponse>();

            CreateMap<CompanyRequest, Company>()
                .ForMember(d => d.Created_on, o => o.Ignore())
                .ForMember(d => d.Updated_on, o => o.Ignore());

            CreateMap<UserRequest, User>()
                .ForMember(d => d.Password, o => o.Ignore())
                .ForMember(d => d.Role, o => o.Ignore());

            CreateMap<User, UserResponse>()
                .ForMember(d => d.Business_unit, o => o.MapFrom(s => s.BusinessUnit.Business_unit))
                .ForMember(d => d.BusinessUnit_location, o => o.MapFrom(s => s.BusinessUnit.BusinessUnit_location));
        }
    }
}
