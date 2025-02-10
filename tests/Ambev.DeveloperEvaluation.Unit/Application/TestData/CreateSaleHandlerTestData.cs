using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class CreateSaleHandlerTestData
{

    public static CreateSaleResult CreateSaleResultFake()
    {
        var entityFake = new Faker<CreateSaleResult>("pt_BR")
            .RuleFor(c => c.ClientId, f => f.IndexFaker)
            .RuleFor(c => c.BranchId, f => f.IndexFaker)
            .RuleFor(c => c.SalesProducts, salesProductDTOFake);

        return entityFake;
    }

    public static CreateSaleCommand CreateSaleCommandFake()
    {
        var entityFake = new Faker<CreateSaleCommand>("pt_BR")
            .RuleFor(c => c.ClientId, f => f.IndexFaker)
            .RuleFor(c => c.BranchId, f => f.IndexFaker)
            .RuleFor(c => c.SalesProducts, salesProductDTOFake);

        return entityFake;
    }
    

    public static Sale salesFake()
    {
        var entityFake = new Faker<Sale>("pt_BR")
            .RuleFor(c => c.Id, f => f.IndexFaker)
            .RuleFor(c => c.Branch, branchFake)
            .RuleFor(c => c.Client, clientFake)
            .RuleFor(c => c.SalesFinalPrice, f => f.Random.Decimal(1, 500))
            .RuleFor(c => c.SalesProducts, salesProductFake);

        return entityFake;
    }

    public static List<SalesProductDTO> salesProductDTOFake()
    {
        var entityFake = new Faker<SalesProductDTO>("pt_BR")
            .RuleFor(c => c.ProductId, 1)
            .RuleFor(c => c.Quantity, f => f.Random.Int(1, 19));
        var result = entityFake.Generate(5);

        return result;
    }

    public static List<SalesProduct> salesProductFake()
    {
        var entityFake = new Faker<SalesProduct>("pt_BR")
            .RuleFor(c => c.Canceled, false)
            .RuleFor(c => c.ProductId, 1)
            .RuleFor(c => c.Product, productFake)
            .RuleFor(c => c.Id, 1)
            .RuleFor(c => c.Sales, new Sale())
            .RuleFor(c => c.Quantity, f => f.Random.Int(1, 20));

        var result = entityFake.Generate(5);

        return result;
    }

    public static Branch branchFake()
    {
        var entityFake = new Faker<Branch>("pt_BR")
            .RuleFor(c => c.Id, f => 1)
            .RuleFor(c => c.Name, f => f.Name.FullName(Bogus.DataSets.Name.Gender.Female));
        return entityFake;
    }

    public static Client clientFake()
    {
        var entityFake = new Faker<Client>("pt_BR")
            .RuleFor(c => c.Id, f => 1)
            .RuleFor(c => c.Name, f => f.Name.FullName(Bogus.DataSets.Name.Gender.Male));
        return entityFake;
    }

    public static Product productFake()
    {
        var entityFake = new Faker<Product>("pt_BR")
            .RuleFor(c => c.Id, f => 1)
            .RuleFor(c => c.Name, f => f.Name.FullName(Bogus.DataSets.Name.Gender.Male))
            .RuleFor(c => c.Price, f => f.Random.Decimal(1, 500));

        return entityFake;
    }
}
