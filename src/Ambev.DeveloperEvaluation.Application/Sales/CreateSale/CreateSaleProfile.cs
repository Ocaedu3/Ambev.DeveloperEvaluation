using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Profile for mapping between User entity and CreateUserResponse
/// </summary>
public class CreateSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateUser operation
    /// </summary>
    public CreateSaleProfile()
    {
        CreateMap<SalesProductDTO, SalesProduct>();//.ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId));
        CreateMap<CreateSaleCommand, Sale>();//.ForMember(dest => dest.SalesProducts, opt => opt.MapFrom(src => src.SalesProducts));
        CreateMap<SalesProduct, SalesProductDTO>();
        CreateMap<Sale, CreateSaleResult>();


    }
}
