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
        
        CreateMap<SalesProductDTO, SalesProduct>();
        CreateMap<CreateSaleCommand, Sale>();
        CreateMap<SalesProduct, SalesProductDTO>();
        CreateMap<Sale, CreateSaleResult>();


    }
}
