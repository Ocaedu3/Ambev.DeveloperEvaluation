using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;

/// <summary>
/// Handler for processing DeleteUserCommand requests
/// </summary>
public class DeleteSaleHandler : IRequestHandler<DeleteSaleCommand, DeleteSaleResponse>
{
    private readonly ISaleRepository _repository;

    /// <summary>
    /// Initializes a new instance of SaleSaleHandler
    /// </summary>
    /// <param name="userRepository">The sale repository</param>
    /// <param name="validator">The validator for SaleUserCommand</param>
    public DeleteSaleHandler(
        ISaleRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Handles the SaleUserCommand request
    /// </summary>
    /// <param name="request">The sale delete command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The result of the delete operation</returns>
    public async Task<DeleteSaleResponse> Handle(DeleteSaleCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteSaleValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var success = await _repository.DeleteAsync(request.Id, cancellationToken);
        if (!success)
            throw new KeyNotFoundException($"Sale with ID {request.Id} not found");

        return new DeleteSaleResponse { Success = true };
    }
}
