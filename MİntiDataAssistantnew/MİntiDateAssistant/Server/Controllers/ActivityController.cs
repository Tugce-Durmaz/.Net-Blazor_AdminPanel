using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MİntiDateAssistant.Server.Data.Models;
using MİntiDateAssistant.Server.Services.Infastruce;
using MİntiDateAssistant.Server.Services.Services;
using MİntiDateAssistant.Shared.DTO;
using MİntiDateAssistant.Shared.ResponseModels;

namespace MİntiDateAssistant.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase

    {
        private readonly IActivityService activityService;

        public ActivityController(IActivityService ActivityService)

        {

            activityService = ActivityService;

        }

        [HttpGet("Activities")]
        public async Task<ServiceResponse<List<ActivityDTO>>> GetActivities()
        {
            return new ServiceResponse<List<ActivityDTO>>()
            {
                Value = await activityService.GetActivities()
            };
        }

        [HttpPost("Create")]

        public async Task<ServiceResponse<ActivityDTO>> CreateActivity([FromBody] ActivityDTO Activity)
        {
            return new ServiceResponse<ActivityDTO>()
            {
                Value = await activityService.CreateActivity(Activity)
            };
        }

                


        [HttpPost("Update")]

        public async Task<ServiceResponse<ActivityDTO>> UpdateActivity([FromBody] ActivityDTO Activity)
        {
            return new ServiceResponse<ActivityDTO>()
            {
                Value = await activityService.UpdateActivity(Activity)
            };
        }

        [HttpGet("ActivityById/{Id}")]

        public async Task<ServiceResponse<ActivityDTO>> GetActivityById(int Id)
        {
            return new ServiceResponse<ActivityDTO>()
            {
                Value = await activityService.GetActivityById(Id)
            };
        }
    }
}