using System.Threading.Tasks;

namespace RingIntegration.Authentication
{
    public interface IAuthenticator
    {
        Task<bool> Authenticate(string username, string password);
        Task<bool> TwoFactorAuthentication(string code);
        string AccessToken { get; }
    }
}