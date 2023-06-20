using AutoMapper;
using AutoMapper.QueryableExtensions;

using Microsoft.EntityFrameworkCore;
using MİntiDateAssistant.Server.Data.Models;
using MİntiDateAssistant.Server.Services.Infastruce;
using MİntiDateAssistant.Shared.DTO;

namespace MİntiDateAssistant.Server.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private readonly MintiDateAssistantContext context;

        public UserService(IMapper Mapper , MintiDateAssistantContext Context)
        {
            mapper  = Mapper;
            context = Context; 
        }

            
        public async Task<UserDTO> CreateUser(UserDTO User)
        {
            var dbUser = await context.MinticityUsers.Where(i => i.UserId == User.UserId).FirstOrDefaultAsync();
            if (dbUser != null)
                throw new Exception("İlgili Kayıt Zaten Mevcut");
            dbUser = mapper.Map<Data.Models.MinticityUser>(User);


            await context.MinticityUsers.AddAsync(dbUser);
            int result = await context.SaveChangesAsync();
            return mapper.Map<UserDTO>(dbUser);

        }

        public async Task<bool> DeleteUserById(int UserId)
        {
            var dbUser = await context.MinticityUsers.Where(i => i.UserId == UserId).FirstOrDefaultAsync();
            if (dbUser == null)
                throw new Exception("Kullanıcı Bulunamadı");
            context.MinticityUsers.Remove(dbUser);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<UserDTO> GetUserById(int UserId)
        {
            return await context.MinticityUsers
               .Where(i => i.UserId == UserId)
               .ProjectTo<UserDTO>(mapper.ConfigurationProvider)
               .FirstOrDefaultAsync();
        }

        public async Task<List<UserDTO>> GetUsers()
        {
            return await context.MinticityUsers
                .Where(i => (bool)i.IsActive)
                .ProjectTo<UserDTO>(mapper.ConfigurationProvider)
                .ToListAsync();

        }

        public async Task<UserDTO> UpdateUser(UserDTO User)
        {
            var dbUser = await context.MinticityUsers.Where(i => i.UserId == User.UserId).FirstOrDefaultAsync();
            if (dbUser == null)
                throw new Exception("İlgili Kayıt Bulunamadı");
            dbUser = mapper.Map<Data.Models.MinticityUser>(User);

            mapper.Map(User, dbUser);


            int result = await context.SaveChangesAsync();
            return mapper.Map<UserDTO>(dbUser);

        }
    }   
}
