using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSSD.Api.Admin.Profiles
{
    public class AdminProfile : AutoMapper.Profile
    {
        public AdminProfile()
        {
            CreateMap<DB.Feedback, Models.Feedback>();
            CreateMap<Models.Feedback, DB.Feedback>();
            CreateMap<DB.Schedule, Models.Schedule>();
            CreateMap<Models.Schedule, DB.Schedule>();
            CreateMap<DB.TestPortal, Models.TestPortal>();
            CreateMap<Models.TestPortal, DB.TestPortal>();
            CreateMap<DB.ClickEvent, Models.ClickEvent>();
            CreateMap<Models.ClickEvent, DB.ClickEvent>();
        }
    }
}
