using MinhaApp1.Models;

namespace MinhaApp1.Interfaces
{
    public interface IAuthService
    {
        string? Login(LoginAuth login);
    }
}
