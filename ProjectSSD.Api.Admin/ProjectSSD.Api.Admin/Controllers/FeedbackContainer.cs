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
    [Route("api/feedback")]
    public class FeedbackContainer : ControllerBase
    {
        private readonly IFeedbackProvider feedbackProvider;

        public FeedbackContainer(IFeedbackProvider feedbackProvider)
        {
            this.feedbackProvider = feedbackProvider;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllTestFeedbacks()
        {
            var result = await this.feedbackProvider.GetAllFeedbacks();
            if (result.isSuccess && result.feedbacks.Any())
            {
                return Ok(result.feedbacks);
            }

            return NotFound("no schedules");
        }

        [HttpPost("addfeedback")]
        public async Task<IActionResult> AddFeedback(Feedback feedback)
        {
            var result = await this.feedbackProvider.AddFeedback(feedback);
            if (result.isSuccess)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}
