using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

/// <summary>
/// Profile for mapping GetUser feature requests to commands
/// </summary>
public class GetSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetUser feature
    /// </summary>
    public GetSaleProfile()
    {
        CreateMap<long, Application.Sales.GetSale.GetSaleCommand>()
            .ConstructUsing(id => new Application.Sales.GetSale.GetSaleCommand(id));
    }
}
