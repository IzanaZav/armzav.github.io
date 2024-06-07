using Gradebook.Application.Common.Models;
using Gradebook.Application.Interfaces;
using Gradebook.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Gradebook.Infrastructure.Identity;

public class IdentityService : IIdentityService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public IdentityService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<string?> GetUserNameAsync(string userId)
    {
        var user = await _userManager.Users.FirstAsync(u => u.Id == userId);
        return user.UserName;
    }

    public async Task<bool> IsInRoleAsync(string userId, string role)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        return user != null && await _userManager.IsInRoleAsync(user, role);
    }

    public async Task<bool> PasswordSignInAsync(string email, string password)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.NormalizedEmail == email.ToUpper());
        
        if (user == null)
        {
            return false;
        }

        var result = await _signInManager.PasswordSignInAsync(user, password, false, false);
        
        return result.Succeeded;
    }

    public async Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password)
    {
        var user = new AppUser()
        {
            UserName = userName,
            Email = userName
        };

        var result = await _userManager.CreateAsync(user, password);

        return (result.ToApplicationResult(), user.Id);
    }

    public async Task<Result> DeleteUserAsync(string userId)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        return user != null ? await DeleteUserAsync(user) : Result.Success();
    }

    public async Task<bool> CheckUserExistence(string userName)
    {
        var result = await _userManager.FindByNameAsync(userName);

        return result != null;
    }

    public async Task<string> GetUserId(string userName)
    {
        
        var result = await _userManager.FindByNameAsync(userName);

        return result != null ? result.Id : String.Empty;
    }

    public string GetUserName(string id)
    {
        return _userManager.Users.SingleOrDefault(a => a.Id == id).UserName;
    }

    public async Task SignOutAsync()
    {
        await _signInManager.SignOutAsync();
    }

    public async Task<IdentityResult> AssignRoles(string email, string[] roles)
    {
        var user = await _userManager.FindByEmailAsync(email);
        return await _userManager.AddToRolesAsync(user, roles);
    }

    public async Task<Result> DeleteUserAsync(AppUser user)
    {
        var result = await _userManager.DeleteAsync(user);

        return result.ToApplicationResult();
    }
}