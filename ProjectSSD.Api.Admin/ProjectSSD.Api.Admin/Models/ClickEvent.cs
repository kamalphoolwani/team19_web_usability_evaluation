using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSSD.Api.Admin.Models
{
    public class ClickEvent
    {
        public int Id { get; set; }
        public int PortalId { get; set; }
        public int XPos { get; set; }
        public int YPos { get; set; }
        public int Intensity { get; set; }
    }
}
