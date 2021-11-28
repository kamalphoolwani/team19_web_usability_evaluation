using Microsoft.AspNetCore.Mvc;
using ProjectSSD.Api.Admin.Models;
using ProjectSSD.Api.Admin.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSSD.Api.Admin.Controllers
{
    [ApiController]
    [Route("api/testprovider")]
    public class TestPortalController : ControllerBase
    {
        private readonly ITestPortalProvider testPortalProvider;

        public TestPortalController(ITestPortalProvider testPortalProvider)
        {
            this.testPortalProvider = testPortalProvider;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTestPortals()
        {
            var result = await this.testPortalProvider.GetTestPortalsAsync();
            if(result.isSuccess && result.portals.Any())
            {
                return Ok(result.portals);
            }

            return NotFound();
        }

        [HttpPost("addtestportal")]
        public async Task<IActionResult> AddTestPortal(TestPortal portalDetails)
        {
            var result = await this.testPortalProvider.AddTestPortalAsync(portalDetails);
            if (result.isSuccess)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}
