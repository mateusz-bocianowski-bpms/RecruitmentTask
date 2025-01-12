using Microsoft.AspNetCore.Mvc;

using Common.Validation;

using CardProcessing.Application.Contract;
using CardProcessing.Service.Contract;

namespace CardProcessing.Service.Controllers;

[ApiController]
[Route(Routes.AllowedCardActions)]
public class AllowedCardActionsController : ControllerBase
{
    private readonly IValidator<AllowedCardActionsRequest> allowedCardActionsRequestValidator;
    private readonly IActionService actionService;

    public AllowedCardActionsController(IValidator<AllowedCardActionsRequest> allowedCardActionsRequestValidator,
                                        IActionService actionService)
    {
        this.allowedCardActionsRequestValidator = allowedCardActionsRequestValidator;
        this.actionService = actionService;
    }

    [HttpPost]
    public async Task<ActionResult<AllowedCardActionsResponse>> PostAsync(AllowedCardActionsRequest request)
    {
        allowedCardActionsRequestValidator.Validate(request);

        var allowedCardActions = await actionService.GenerateAllowedCardActionsAsync(request.UserId, request.CardNumber);

        var result = new AllowedCardActionsResponse { AllowedActions = allowedCardActions };

        return Ok(result);
    }
}