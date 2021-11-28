using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectSSD.Api.Admin.DB;
using ProjectSSD.Api.Admin.Interfaces;
using ProjectSSD.Api.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSSD.Api.Admin.Providers
{
    public class FeedbackProvider : IFeedbackProvider
    {
        private readonly AdminDbContext dbContext;
        private readonly ILogger<FeedbackProvider> logger;
        private readonly IMapper mapper;

        public FeedbackProvider(AdminDbContext dbContext, ILogger<FeedbackProvider> logger, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<(bool isSuccess, Models.Feedback feedback, string ErrorMessage)> AddFeedback(Models.Feedback feedback)
        {
            if (feedback != null)
            {
                var mappedData = mapper.Map<Models.Feedback, DB.Feedback>(feedback);
                await this.dbContext.Feedback.AddAsync(mappedData);
                this.dbContext.SaveChanges();
                return (true, feedback, null);
            }
            return (false, feedback, "adding failed");
        }

        public async Task<(bool isSuccess, IEnumerable<Models.Feedback> feedbacks, string ErrorMessage)> GetAllFeedbacks()
        {
            try
            {
                var feedbacks = await this.dbContext.Feedback.ToListAsync();
                if (feedbacks != null && feedbacks.Any())
                {
                    var result = mapper.Map<IEnumerable<DB.Feedback>, IEnumerable<Models.Feedback>>(feedbacks);
                    return (true, result, null);
                }

                return (false, null, "not found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}
