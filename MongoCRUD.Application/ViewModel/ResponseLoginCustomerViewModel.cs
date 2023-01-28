namespace MongoCRUD.Application.ViewModel;

public sealed record ResponseLoginCustomerViewModel(string Name, string Email, DateTime CreatedAt, DateTime UpdatedAt, bool Status)
{
    public string Token { get; set; } = string.Empty;
}