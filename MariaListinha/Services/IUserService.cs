
using MariaListinha.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace MariaListinha.Services;

public interface IUserService
{
    Task<UserVM> GetLoggedUser();
    Task<SignInResult> Login(LoginVM login);
    Task Logout();
}