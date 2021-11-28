using Microsoft.AspNetCore.Mvc;
using ProjectSSD.Api.Admin.Interfaces;
using ProjectSSD.Api.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSSD.Api.Admin.Controllers
{
    [ApiController]
    [Route("api/schedule")]
    public class ScheduleContainer : ControllerBase
    {
        private readonly IScheduleProvider scheduleProvider;

        public ScheduleContainer(IScheduleProvider scheduleProvider)
        {
            this.scheduleProvider = scheduleProvider;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllTestPortals()
        {
            var result = await this.scheduleProvider.GetAllSchedulesAsync();
            if (result.isSuccess && result.schedules.Any())
            {
                return Ok(result.schedules);
            }

            return NotFound("no schedules");
        }

        [HttpPost("addschedule")]
        public async Task<IActionResult> AddTestPortal(Schedule schedule)
        {
            var result = await this.scheduleProvider.AddScheduleAsync(schedule);
            if (result.isSuccess)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}
