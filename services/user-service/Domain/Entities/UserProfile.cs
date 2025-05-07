namespace Domain.Entities;

public class UserProfile
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string PhoneNumber {  get; set; } = string.Empty;
    public DateOnly DateOfBirth { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public UserPreference? UserPreference { get; set; }
    public ICollection<UserAddress> Addresses { get; set; } = new List<UserAddress>();
}
