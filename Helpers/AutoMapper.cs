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

            CreateMap<ColdstorageRequest, ColdStorage>();

            CreateMap<ColdStorage, ColdStorageResponse>();

            CreateMap<PalletRequest, Pallet>()
                .ForMember(d => d.Occupied, o => o.Ignore())
                .ForMember(d => d.Active, o => o.Ignore())
                .ForMember(d => d.Removed, o => o.Ignore())
                .ForMember(d => d.Created_on, o => o.Ignore())
                .ForMember(d => d.Updated_on, o => o.Ignore());

            CreateMap<Pallet, PalletResponse>();

            CreateMap<PositionRequest, PalletPosition>();

            CreateMap<PalletPosition, PositionResponse>();

            CreateMap<ProductRequest, Product>() 
                .ForMember(d => d.Active, o => o.Ignore())
                .ForMember(d => d.Created_on, o => o.Ignore())
                .ForMember(d => d.Updated_on, o => o.Ignore());

            CreateMap<Product, ProductResponse>()
                .ForMember(d => d.Company, o => o.MapFrom(s => s.Company));

            CreateMap<Product, ProductCodeResponse>();

            CreateMap<ReceivingRequest, Receiving>()
                .ForMember(d => d.Document_id, o => o.Ignore())
                .ForMember(d => d.Pending, o => o.Ignore())
                .ForMember(d => d.Receiving_detail, o => o.MapFrom(s => s.Receiving_detail));

            CreateMap<Receiving, ReceivingResponse>();

            CreateMap<ReceivingDetailRequest, ReceivingDetail>();

            CreateMap<ReceivingDetail, ReceivingDetailResponse>();

            CreateMap<UserRequest, User>()
                .ForMember(d => d.Password, o => o.Ignore())
                .ForMember(d => d.Role, o => o.Ignore());

            CreateMap<User, UserResponse>()
                .ForMember(d => d.Business_unit, o => o.MapFrom(s => s.BusinessUnit.Business_unit))
                .ForMember(d => d.BusinessUnit_location, o => o.MapFrom(s => s.BusinessUnit.BusinessUnit_location));
        }
    }
}
