using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSale;

/// <summary>
/// Profile for mapping GetUser feature requests to commands
/// </summary>
public class DeleteSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetUser feature
    /// </summary>
    public DeleteSaleProfile()
    {
        CreateMap<long, Application.Sales.DeleteSale.DeleteSaleCommand>()
            .ConstructUsing(id => new Application.Sales.DeleteSale.DeleteSaleCommand(id));
    }
}
