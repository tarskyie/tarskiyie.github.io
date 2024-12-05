using System.Runtime.CompilerServices;

public class LoginService
{
    public bool IsLogin { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public LoginService() {
        IsLogin = false;
    }
}