using Application.DTOs;
using AutoMapper;
using Domain.Entitites;
using Domain.ValueObjects;

namespace Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // CreateOrderDto → Order
        CreateMap<CreateOrderDto, Order>()
            .ForMember(dest => dest.DeliveryAdress, opt => opt.MapFrom(src => src.DeliveryAddress))
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items))
            .ForMember(dest => dest.TotalPrice, opt => opt.Ignore()) // Рассчитывается на сервере
            .ForMember(dest => dest.Status, opt => opt.Ignore())     // Устанавливается по умолчанию
            .ForMember(dest => dest.Id, opt => opt.Ignore())         // Генерируется
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())  // Устанавливается в сервисе
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());  // Устанавливается в сервисе;

        // CreateOrderItemDto → OrderItem
        CreateMap<CreateOrderItemDto, OrderItem>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.OrderId, opt => opt.Ignore());

        // AddressDto → Address (Value Object)
        CreateMap<AddressDto, Address>()
            .ConstructUsing(dto => new Address(dto.Street, dto.City, dto.State, dto.PostalCode, dto.Country));

        // Order → OrderDto
        CreateMap<Order, OrderDto>()
            .ForMember(dest => dest.DeliveryAdress, opt => opt.MapFrom(src => src.DeliveryAdress));

        // OrderItem → OrderItemDto
        CreateMap<OrderItem, OrderItemDto>();

        // Address → AddressDto (для ответа)
        CreateMap<Address, AddressDto>();
    }
}
