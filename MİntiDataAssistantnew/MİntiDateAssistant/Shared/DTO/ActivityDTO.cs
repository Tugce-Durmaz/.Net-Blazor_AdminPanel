using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MİntiDateAssistant.Shared.DTO
{
    public class ActivityDTO
    {
        public int ActivityId { get; set; }

        public string? ActivityName { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string? Location { get; set; }

        public bool IsActive { get; set; }

        public string? Name { get; set; }

        public int? Age { get; set; }

        public string? NickName { get; set; }
    }


}

