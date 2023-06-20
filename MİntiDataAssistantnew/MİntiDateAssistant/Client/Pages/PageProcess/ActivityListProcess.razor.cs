using Microsoft.AspNetCore.Components;
using MİntiDateAssistant.Client.Utils;
using MİntiDateAssistant.Shared.ActivityExceptions;
using MİntiDateAssistant.Shared.DTO;
using MİntiDateAssistant.Shared.ResponseModels;
using System.Net.Http.Json;

namespace MİntiDateAssistant.Client.Pages.Activities
{
    public partial class ActivityListProcess : ComponentBase
    {

        [Inject]
        public HttpClient Client { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }

        protected List<ActivityDTO> ActivityList = new List<ActivityDTO>();

        protected async override Task OnInitializedAsync()
        {
            await LoadList();
        }


        protected void goCreateActivityPage()
        {
           NavigationManager.NavigateTo("/activities/add");
        }

        protected async Task LoadList()
        {
            var serviceResponse = await Client.GetFromJsonAsync<ServiceResponse<List<ActivityDTO>>>("api/Activity/Activities");

            if (serviceResponse.Success)
                ActivityList = serviceResponse.Value;


        }
    }
}


//using Microsoft.AspNetCore.Components;
//using MİntiDateAssistant.Client.Utils;
//using MİntiDateAssistant.Shared.ActivityExceptions;
//using MİntiDateAssistant.Shared.DTO;
//using MİntiDateAssistant.Shared.ResponseModels;
//using System.Net.Http.Json;

//namespace MİntiDateAssistant.Client.Pages.Activities
//{
//    public partial class ActivityListProcess : ComponentBase
//    {





//        [Inject]
//        public HttpClient Client { get; set; }

//        [Inject]
//        NavigationManager NavigationManager { get; set; }

//        protected List<ActivityDTO> ActivityList = new List<ActivityDTO>();

//        protected async override Task OnInitializedAsync()
//        {
//            await LoadList();
//        }


//        protected void goCreateActivityPage()
//        {
//            NavigationManager.NavigateTo("/activities/add");
//        }

//        protected async Task LoadList()
//        {
//            await Client.GetFromJsonAsync<ServiceResponse<List<ActivityDTO>>>("api/Activity/Activities");



//        }
//    }
//}