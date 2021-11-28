using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSSD.Api.Admin.Models
{
    public class TestPortal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TestPortalUrl { get; set; }
        public string StakeHolderName { get; set; }
        public string StakeHolderEmail { get; set; }
        public string CheckList { get; set; }
    }
}
