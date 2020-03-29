using System.Threading.Tasks;

namespace RingIntegration.Authentication
{
    public interface IAuthenticator
    {
        string AccessToken { get; }
        Task<bool> Authenticate(bool twofactor = false);
        Task<bool> TwoFactorAuthentication(string code);
    }
}