using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSSD.Api.Admin.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ScheduleId { get; set; }
        public int TestPortalId { get; set; }
        public string Description { get; set; }
    }
}
