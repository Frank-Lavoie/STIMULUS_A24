using STIMULUS_V2.Shared.Models.Authentication;
using STIMULUS_V2.Shared.Models.DTOs;

namespace STIMULUS_V2.Client.Services.AuthenticationService
{
    public interface IAuthenticationService
    {
        // Public Interfaces
        Task<object> RegisterAccountAsync(InscriptionVerification model);
        Task<APIResponse<SessionUtilisateur>> LoginAsync(ConnexionVerification model);

        //Protected Interfaces
        Task<int> GetUserCount();
        Task<string> GetMyInfo(string email);
    }
}
