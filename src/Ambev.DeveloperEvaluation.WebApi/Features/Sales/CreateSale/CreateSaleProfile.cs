using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Profile for mapping between Application and API CreateUser responses
/// </summary>
public class CreateSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateUser feature
    /// </summary>
    public CreateSaleProfile()
    {
        CreateMap<CreateSaleRequest, CreateSaleCommand>();//.ForMember(dest => dest.SalesProducts, opt => opt.MapFrom(src => src.SalesProducts));
        CreateMap<SalesProductDTO, SalesProduct>();//.ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId));
        CreateMap<CreateSaleCommand, Sale>();//.ForMember(dest => dest.SalesProducts, opt => opt.MapFrom(src => src.SalesProducts));
        CreateMap<SalesProduct, SalesProductDTO>();
        CreateMap<Sale, CreateSaleResult>();
        CreateMap<CreateSaleResult, CreateSaleResponse>();


    }
}
