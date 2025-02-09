using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Profile for mapping between User entity and CreateUserResponse
/// </summary>
public class UpdateSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateUser operation
    /// </summary>
    public UpdateSaleProfile()
    {
        
        CreateMap<SalesProductUpdate, SalesProduct>();
        CreateMap<UpdateSaleCommand, Sale>();
        CreateMap<SalesProduct, SalesProductUpdate>();
        CreateMap<Sale, UpdateSaleResult>();


    }
}
