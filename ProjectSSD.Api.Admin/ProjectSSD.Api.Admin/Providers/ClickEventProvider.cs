using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectSSD.Api.Admin.DB;
using ProjectSSD.Api.Admin.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSSD.Api.Admin.Providers
{
    public class ClickEventProvider : IClickEventProvider
    {
        private readonly AdminDbContext dbContext;
        private readonly ILogger<ClickEventProvider> logger;
        private readonly IMapper mapper;

        public ClickEventProvider(AdminDbContext dbContext, ILogger<ClickEventProvider> logger, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<(bool isSuccess, Models.ClickEvent clickEvent, string ErrorMessage)> AddClickEventsAsync(Models.ClickEvent clickEvent)
        {
            if (clickEvent != null)
            {
                var mappedData = mapper.Map<Models.ClickEvent, DB.ClickEvent>(clickEvent);
                await this.dbContext.ClickEvent.AddAsync(mappedData);
                this.dbContext.SaveChanges();
                return (true, clickEvent, null);
            }
            return (false, clickEvent, "adding failed");
        }

        public async Task<(bool isSuccess, IEnumerable<Models.ClickEvent> clickEvents, string ErrorMessage)> GetClickEventsAsync()
        {
            try
            {
                var clickEvents = await this.dbContext.ClickEvent.ToListAsync();
                if (clickEvents != null && clickEvents.Any())
                {
                    var result = mapper.Map<IEnumerable<DB.ClickEvent>, IEnumerable<Models.ClickEvent>>(clickEvents);
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
