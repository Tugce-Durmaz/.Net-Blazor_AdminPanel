

using MİntiDateAssistant.Shared.DTO;

namespace MİntiDateAssistant.Server.Services.Infastruce
{
    public interface IUserService
  {
       public Task<UserDTO> GetUserById(int UserId);

        public Task<List<UserDTO>> GetUsers();

        public Task<UserDTO> CreateUser(UserDTO User);

       public Task<UserDTO> UpdateUser(UserDTO User);

       public Task<bool> DeleteUserById(int UserId);

       



    }
}
