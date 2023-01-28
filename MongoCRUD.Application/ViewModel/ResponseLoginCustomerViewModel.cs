namespace MongoCRUD.Application.ViewModel;

public sealed record ResponseLoginCustomerViewModel
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsActive { get; set; }
    public string Token { get; set; } = string.Empty;
}