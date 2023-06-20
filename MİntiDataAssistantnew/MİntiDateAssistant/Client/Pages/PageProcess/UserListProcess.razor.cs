using Microsoft.AspNetCore.Components;
using MİntiDateAssistant.Client.Utils;
using MİntiDateAssistant.Shared.DTO;
using MİntiDateAssistant.Shared.ResponseModels;
using System.Net.Http.Json;

namespace MİntiDateAssistant.Client.Pages.Users
{
    public partial class UserListProcess : ComponentBase
    {

        [Inject]
        public HttpClient Client { get; set; }

     

        protected List<UserDTO> UserList = new List<UserDTO>();

        protected async override Task OnInitializedAsync()
        {
            await LoadList();
        }


        protected async Task LoadList()
        {
           var serviceResponse = await Client.GetFromJsonAsync<ServiceResponse<List<UserDTO>>>("api/User/Users");

            if (serviceResponse.Success)
                UserList = serviceResponse.Value;


        }

    }
}
