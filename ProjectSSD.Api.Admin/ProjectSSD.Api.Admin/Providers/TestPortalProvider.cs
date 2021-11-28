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
    public class TestPortalProvider : ITestPortalProvider
    {
        private readonly AdminDbContext dbContext;
        private readonly ILogger<TestPortalProvider> logger;
        private readonly IMapper mapper;

        public TestPortalProvider(AdminDbContext dbContext, ILogger<TestPortalProvider> logger, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<(bool isSuccess, Models.TestPortal portalDetails, string ErrorMessage)> AddTestPortalAsync(Models.TestPortal portalDetails)
        {
            if(portalDetails != null)
            {
                try
                {
                    var mappedData = mapper.Map<Models.TestPortal, DB.TestPortal>(portalDetails);
                    await this.dbContext.TestPortal.AddAsync(mappedData);
                    this.dbContext.SaveChanges();
                    return (true, portalDetails, null);
                }
                catch(Exception ex)
                {
                    logger?.LogError(ex.ToString());
                    return (false, null, ex.Message);
                }
            }
            return (false, portalDetails, "adding failed");
        }

        public async Task<(bool isSuccess, IEnumerable<Models.TestPortal> portals, string ErrorMessage)> GetTestPortalsAsync()
        {
            try
            {
                var testProtals = await this.dbContext.TestPortal.ToListAsync();
                if (testProtals != null && testProtals.Any())
                {
                    var result = mapper.Map<IEnumerable<DB.TestPortal>, IEnumerable<Models.TestPortal>>(testProtals);
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
