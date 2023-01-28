namespace MongoCRUD.Application.Core;

public sealed record ServicesResponse(bool IsSuccess, string Message, object? Response = null);
