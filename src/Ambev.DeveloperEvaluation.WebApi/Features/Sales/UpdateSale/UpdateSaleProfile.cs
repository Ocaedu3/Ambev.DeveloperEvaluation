using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

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
        CreateMap<UpdateSaleRequest, UpdateSaleCommand>();
        CreateMap<SalesProductUpdate, SalesProduct>();
        CreateMap<UpdateSaleCommand, Sale>();
        CreateMap<SalesProduct, SalesProductUpdate>();
        CreateMap<Sale, UpdateSaleResult>();
        CreateMap<UpdateSaleResult, UpdateSaleResponse>();
    }
}
