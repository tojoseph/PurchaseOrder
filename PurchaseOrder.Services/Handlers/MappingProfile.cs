using AutoMapper;
using PurchaseOrder.Core.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<TblProductDetails, ProductDetailsModel>()
        //.ForMember(item => item.StatusName, item => item.MapFrom(s => s.IsActive == true ? "Active" : "In Active"));
        .ReverseMap();
        CreateMap<TblOrders, OrderViewModel>().ReverseMap();
        CreateMap<TblOrders, UpdateOrderViewModel>().ReverseMap();
        //.ForMember(dest => dest.OrderItems, );
        CreateMap<TblOrderItems, OrderItemsModel>().ReverseMap();
        CreateMap<TblSubscriptions, SubscriptionsModel>().ReverseMap();
        CreateMap<TblCustomerScubscription, CustomerScubscriptionModel>().ReverseMap();
    }
}