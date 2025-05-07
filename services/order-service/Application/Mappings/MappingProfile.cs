using Application.DTOs;
using AutoMapper;
using Domain.Entitites;
using Domain.ValueObjects;

namespace Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateOrderDto, Order>()
            .ForMember(dest => dest.DeliveryAdress, opt => opt.MapFrom(src => src.DeliveryAddress))
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));

        CreateMap<CreateOrderItemDto, OrderItem>();

        CreateMap<AddressDto, Address>()
            .ConstructUsing(dto => new Address(dto.Street, dto.City, dto.State, dto.PostalCode, dto.Country));

        CreateMap<Order, OrderDto>()
            .ForMember(dest => dest.DeliveryAddress, opt => opt.MapFrom(src => src.DeliveryAdress));

        CreateMap<OrderItem, OrderItemDto>();
        CreateMap<Address, AddressDto>();
    }   
}
