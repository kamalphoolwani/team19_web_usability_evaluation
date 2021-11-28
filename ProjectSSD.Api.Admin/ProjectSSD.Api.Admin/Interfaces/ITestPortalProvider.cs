using ProjectSSD.Api.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSSD.Api.Admin.Interfaces
{
    public interface ITestPortalProvider
    {
        Task<(bool isSuccess, IEnumerable<TestPortal> portals, string ErrorMessage)> GetTestPortalsAsync();
        Task<(bool isSuccess, Models.TestPortal portalDetails, string ErrorMessage)> AddTestPortalAsync(Models.TestPortal portalDetails);
    }
}
