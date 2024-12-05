using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

public class AuthService
{
    private readonly HttpContext _httpContext;
    private readonly IAuthenticationService _authenticationService;
    private Dictionary<string, string> credentials;

    public AuthService(
        IHttpContextAccessor httpContextAccessor,
        IAuthenticationService authenticationService)
    {
        _httpContext = httpContextAccessor.HttpContext;
        _authenticationService = authenticationService;
    }

    public async Task<bool> Login(string username, string password)
    {
        // Временное решение
        try
        {
            if (credentials == null)
            {
                throw new ArgumentNullException(nameof(credentials));
            }

            if (username == null)
            {
                throw new ArgumentNullException(nameof(username));
            }

            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            if (credentials.ContainsKey(username) && password == credentials[username])
            {
                return true;
            }
            return false;
        }
        catch (ArgumentNullException ex)
        {
            // null аргументы
            Console.WriteLine($"Null argument: {ex.ParamName}");
            return false;
        }
        catch (Exception ex)
        {
            // Другие ошибки
            Console.WriteLine($"An error occurred: {ex.Message}");
            return false;
        }
    }

    public async Task<bool> Register(string username, string password)
    {
        if (credentials == null)
        {
            credentials = new Dictionary<string, string>();
        }

        if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
        {
            if (!credentials.ContainsKey(username))
            {
                credentials[username] = password;
                return true;
            }
        }

        return false;

    }

    public async Task Logout()
    {

    }

    public bool IsLoggedIn()
    {
        return _httpContext.User.Identity?.IsAuthenticated ?? false;
    }
}