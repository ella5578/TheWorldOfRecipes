using ServiceLibrary.DTOs;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace ServiceLibrary.Contracts
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        Task<UserDTO> LoginAsync(string username, string password);

        [OperationContract]
        Task<UserDTO> RegisterUserAsync(UserDTO user);

        [OperationContract]
        Task<UserDTO> GetUserByIdAsync(int userId);

        [OperationContract]
        Task<List<UserDTO>> GetAllUsersAsync();

        [OperationContract]
        Task<bool> UpdateUserAsync(UserDTO user);

        [OperationContract]
        Task<bool> DeleteUserAsync(int userId);

        [OperationContract]
        Task<bool> ResetPasswordAsync(int userId, string newPassword);
        
        [OperationContract]
        UserDTO GetUserByUsername(string userName);

    }
}
