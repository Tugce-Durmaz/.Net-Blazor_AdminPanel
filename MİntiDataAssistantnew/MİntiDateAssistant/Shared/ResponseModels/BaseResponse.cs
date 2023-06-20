using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MİntiDateAssistant.Shared.ResponseModels
{
    public class BaseResponse
    {

        public BaseResponse()
        {
            Success = true;


        }
        public bool Success { get; set; }   
        public String Message { get; set; }

        public void SetException(Exception Exception)
        {
            Success = false;

            Message = Exception.Message;

        }


    }
}
