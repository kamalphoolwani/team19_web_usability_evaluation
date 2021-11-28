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
    public class ScheduleProvider : IScheduleProvider
    {
        private readonly AdminDbContext dbContext;
        private readonly ILogger<ScheduleProvider> logger;
        private readonly IMapper mapper;

        public ScheduleProvider(AdminDbContext dbContext, ILogger<ScheduleProvider> logger, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<(bool isSuccess, Models.Schedule schedule, string ErrorMessage)> AddScheduleAsync(Models.Schedule schedule)
        {
            if (schedule != null)
            {
                try
                {
                    var mappedData = mapper.Map<Models.Schedule, DB.Schedule>(schedule);
                    await this.dbContext.Schedule.AddAsync(mappedData);
                    this.dbContext.SaveChanges();
                    return (true, schedule, null);
                }
                catch (Exception ex)
                {
                    logger?.LogError(ex.ToString());
                    return (false, null, ex.Message);
                }
            }
            return (false, schedule, "adding failed");
        }

        public async Task<(bool isSuccess, IEnumerable<Models.Schedule> schedules, string ErrorMessage)> GetAllSchedulesAsync()
        {
            try
            {
                var schedules = await this.dbContext.Schedule.ToListAsync();
                if (schedules != null && schedules.Any())
                {
                    var result = mapper.Map<IEnumerable<DB.Schedule>, IEnumerable<Models.Schedule>>(schedules);
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
