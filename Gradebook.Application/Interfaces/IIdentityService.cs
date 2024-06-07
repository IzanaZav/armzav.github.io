using Gradebook.Application.Common.Models;
using Microsoft.AspNetCore.Identity;

namespace Gradebook.Application.Interfaces;

public interface IIdentityService
{
    Task<string?> GetUserNameAsync(string userId);
    Task<bool> IsInRoleAsync(string userId, string role);
    Task<bool> PasswordSignInAsync(string email, string password);
    Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);
    Task<Result> DeleteUserAsync(string userId);
    Task<bool> CheckUserExistence(string userName);
    Task<string> GetUserId(string userName);
    string GetUserName(string id);
    Task SignOutAsync();
    Task<IdentityResult> AssignRoles(string email, string[] roles);
}