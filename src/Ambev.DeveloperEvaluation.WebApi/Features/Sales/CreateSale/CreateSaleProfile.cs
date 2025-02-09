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
        CreateMap<CreateSaleRequest, CreateSaleCommand>();
        CreateMap<SalesProductDTO, SalesProduct>();
        CreateMap<CreateSaleCommand, Sale>();
        CreateMap<SalesProduct, SalesProductDTO>();
        CreateMap<Sale, CreateSaleResult>();
        CreateMap<CreateSaleResult, CreateSaleResponse>();


    }
}
