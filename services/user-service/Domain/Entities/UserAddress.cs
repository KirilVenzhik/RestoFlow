namespace Domain.Entities;

public class UserAddress
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string City { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string Building { get; set; } = string.Empty;
    public string Apartment { get; set; } = string.Empty;
    public bool IsDefault { get; set; }
    public DateTime CreatedAt { get; set; }

    public UserProfile? UserProfile { get; set; }
}