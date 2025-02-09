using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSale;
using Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales;

/// <summary>
/// Controller for managing user operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class SalesController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of UsersController
    /// </summary>
    /// <param name="mediator">The mediator instance</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public SalesController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    /// <summary>
    /// Creates a new user
    /// </summary>
    /// <param name="request">The user creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created user details</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateSaleResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateSale([FromBody] CreateSaleRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateSaleRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CreateSaleCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<CreateSaleResponse>
        {
            Success = true,
            Message = "Sale created successfully",
            Data = _mapper.Map<CreateSaleResponse>(response)
        });
    }

    /// <summary>
    /// Retrieves a user by their ID
    /// </summary>
    /// <param name = "id" > The unique identifier of the user</param>
    /// <param name = "cancellationToken" > Cancellation token</param>
    /// <returns>The user details if found</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetSaleResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetSale([FromRoute] long id, CancellationToken cancellationToken)
    {
        var request = new GetSaleRequest { Id = id };
        var validator = new GetSaleRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<GetSaleCommand>(request.Id);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponseWithData<GetSaleResponse>
        {
            Success = true,
            Message = "Sale retrieved successfully",
            Data = _mapper.Map<GetSaleResponse>(response)
        });
    }

    [HttpPut]
    [ProducesResponseType(typeof(ApiResponseWithData<UpdateSaleResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateSale([FromBody] UpdateSaleRequest request, CancellationToken cancellationToken)
    {
        var validator = new UpdateSaleRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<UpdateSaleCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<UpdateSaleResponse>
        {
            Success = true,
            Message = "Sale updated successfully",
            Data = _mapper.Map<UpdateSaleResponse>(response)
        });
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetSaleResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteSale([FromRoute] long id, CancellationToken cancellationToken)
    {
        var request = new DeleteSaleRequest { Id = id };
        var validator = new DeleteSaleRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<DeleteSaleCommand>(request.Id);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponseWithData<DeleteSaleResponse>
        {
            Success = true,
            Message = "Sale deleted successfully",
            Data = _mapper.Map<DeleteSaleResponse>(response)
        });
    }

    ///// <summary>
    ///// Deletes a user by their ID
    ///// </summary>
    ///// <param name="id">The unique identifier of the user to delete</param>
    ///// <param name="cancellationToken">Cancellation token</param>
    ///// <returns>Success response if the user was deleted</returns>
    //[HttpDelete("{id}")]
    //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    //public async Task<IActionResult> DeleteUser([FromRoute] Guid id, CancellationToken cancellationToken)
    //{
    //    var request = new DeleteUserRequest { Id = id };
    //    var validator = new DeleteUserRequestValidator();
    //    var validationResult = await validator.ValidateAsync(request, cancellationToken);

    //    if (!validationResult.IsValid)
    //        return BadRequest(validationResult.Errors);

    //    var command = _mapper.Map<DeleteUserCommand>(request.Id);
    //    await _mediator.Send(command, cancellationToken);

    //    return Ok(new ApiResponse
    //    {
    //        Success = true,
    //        Message = "User deleted successfully"
    //    });
    //}
}
