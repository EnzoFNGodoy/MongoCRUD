using Flunt.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace MongoCRUD.WebApi.Controllers;

[ApiController]
[Route("api/v0")]
public abstract class ApiController : ControllerBase
{
    private readonly ICollection<string> _errors = new List<string>();

    protected ActionResult CustomResponse(object? result = null)
    {
        if (result!.GetType() == typeof(List<Notification>))
        {
            var notifications = result as List<Notification>;
            foreach (var error in notifications!)
            {
                AddError($"{error.Key} | {error.Message}");
            }
        }

        if (IsOperationValid())
            return Ok(result);

        return BadRequest(new Dictionary<string, string[]>
    {
        { $"Erros", _errors.ToArray() }
    });
    }

    protected bool IsOperationValid() => !_errors.Any();

    protected void AddError(string notification) => _errors.Add(notification);

    protected void ClearErrors() => _errors.Clear();
}
