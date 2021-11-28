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
    [Route("api/clickevent")]
    public class ClickEventController : ControllerBase
    {
        private readonly IClickEventProvider clickEventProvider;

        public ClickEventController(IClickEventProvider clickEventProvider)
        {
            this.clickEventProvider = clickEventProvider;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllClickEvents()
        {
            var result = await this.clickEventProvider.GetClickEventsAsync();
            if (result.isSuccess && result.clickEvents.Any())
            {
                return Ok(result.clickEvents);
            }

            return NotFound("No data to fetch");
        }

        [HttpPost("addclickevent")]
        public async Task<IActionResult> AddClickEvent(ClickEvent clickevent)
        {
            var result = await this.clickEventProvider.AddClickEventsAsync(clickevent);
            if (result.isSuccess)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}
