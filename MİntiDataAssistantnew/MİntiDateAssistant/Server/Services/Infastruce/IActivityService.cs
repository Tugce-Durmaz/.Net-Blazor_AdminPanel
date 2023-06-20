using MİntiDateAssistant.Shared.DTO;

namespace MİntiDateAssistant.Server.Services.Infastruce
{
    public interface IActivityService
    {
        public Task<ActivityDTO> GetActivityById(int ActivityId);

        public Task<List<ActivityDTO>> GetActivities();

        public Task<ActivityDTO> CreateActivity(ActivityDTO Activity);

        public Task<ActivityDTO> UpdateActivity(ActivityDTO Activity);

        public Task<bool> DeleteActivityById(int ActivityId);
    }
}
