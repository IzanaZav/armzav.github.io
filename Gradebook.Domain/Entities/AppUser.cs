using Microsoft.AspNetCore.Identity;

namespace Gradebook.Domain.Entities;

public class AppUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
}