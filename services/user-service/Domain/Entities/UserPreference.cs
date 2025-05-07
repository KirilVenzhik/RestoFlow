namespace Domain.Entities;

public class UserPreference
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Language { get; set; } = string.Empty;
    public string Theme { get; set; } = string.Empty;
    public bool MarketingOptIn { get; set; }

    public UserProfile? UserProfile { get; set; }
}
