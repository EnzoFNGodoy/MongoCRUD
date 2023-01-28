namespace MongoCRUD.Application.ViewModel;

public sealed record ResponseCustomerViewModel(string Name, string Email, DateTime CreatedAt, DateTime UpdatedAt, bool Status);