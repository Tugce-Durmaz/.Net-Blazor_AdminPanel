using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MİntiDateAssistant.Shared.ActivityExceptions
{
    public class ApiException:Exception
    {
        




        public ApiException (String Message,Exception InnerException): base(Message,InnerException)

        {

        }




        public ApiException(String Message): base(Message)
        {

        }




    }
}
