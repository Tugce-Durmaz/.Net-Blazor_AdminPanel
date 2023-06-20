using AutoMapper;
using AutoMapper.QueryableExtensions;

using Microsoft.EntityFrameworkCore;
using MİntiDateAssistant.Server.Data.Models;
using MİntiDateAssistant.Server.Services.Infastruce;
using MİntiDateAssistant.Shared.DTO;

namespace MİntiDateAssistant.Server.Services.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IMapper mapper;
        private readonly MintiDateAssistantContext context;

        public ActivityService(IMapper Mapper, MintiDateAssistantContext Context)
        {
            mapper = Mapper;
            context = Context;
        }


        public async Task<ActivityDTO> CreateActivity(ActivityDTO Activity)
        {
            var dbActivity = await context.Activities.Where(i => i.ActivityId == Activity.ActivityId).FirstOrDefaultAsync();
            if (dbActivity != null)
                throw new Exception("İlgili Kayıt Zaten Mevcut");
            dbActivity = mapper.Map<Data.Models.Activity>(Activity);


            await context.Activities.AddAsync(dbActivity);
            int result = await context.SaveChangesAsync();
            return mapper.Map<ActivityDTO>(dbActivity);

        }

        public async Task<bool> DeleteActivityById(int ActivityId)
        {
            var dbActivity = await context.Activities.Where(i => i.ActivityId == ActivityId).FirstOrDefaultAsync();
            if (dbActivity == null)
                throw new Exception("Kullanıcı Bulunamadı");
            context.Activities.Remove(dbActivity);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<ActivityDTO> GetActivityById(int ActivityId)
        {
            return await context.Activities
               .Where(i => i.ActivityId == ActivityId)
               .ProjectTo<ActivityDTO>(mapper.ConfigurationProvider)
               .FirstOrDefaultAsync();
        }

        public async Task<List<ActivityDTO>> GetActivities()
        {
            return await context.Activities
                //.Where(i => (bool)i.IsActive)
                .ProjectTo<ActivityDTO>(mapper.ConfigurationProvider)
                .ToListAsync();

        }

        public async Task<ActivityDTO> UpdateActivity(ActivityDTO Activity)
        {
            var dbActivity = await context.Activities.Where(i => i.ActivityId == Activity.ActivityId).FirstOrDefaultAsync();
            if (dbActivity == null)
                throw new Exception("İlgili Kayıt Bulunamadı");
            dbActivity = mapper.Map<Data.Models.Activity>(Activity);

            mapper.Map(Activity, dbActivity);


            int result = await context.SaveChangesAsync();
            return mapper.Map<ActivityDTO>(dbActivity);

        }
    }
}
