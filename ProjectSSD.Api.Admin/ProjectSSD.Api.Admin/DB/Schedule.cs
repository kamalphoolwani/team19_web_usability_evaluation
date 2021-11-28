using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSSD.Api.Admin.DB
{
    public class Schedule
    {
        public int Id { get; set; }
        public string ViewerName { get; set; }
        public string ViewerEmail { get; set; }
        public DateTime StartDateTime { get; set; }
        public int TestPortalId { get; set; }
        public string Description { get; set; }
    }
}
