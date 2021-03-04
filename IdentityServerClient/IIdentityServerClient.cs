using System.Threading.Tasks;

namespace IdentityServerClient
{
    public interface IIdentityServerClient
    {
        Task<string> RequestSierraTokenAsync();
        Task<string> RequestRiksTokenAsync();
        Task<string> RequestUrramTokenAsync();
        string GetSierraAccessToken();
        string GetRiksAccessToken();
        string GetUrramAccessToken();
    }
}