using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSSD.Api.Admin.Interfaces
{
    public interface IClickEventProvider
    {
        Task<(bool isSuccess, IEnumerable<Models.ClickEvent> clickEvents, string ErrorMessage)> GetClickEventsAsync();
        Task<(bool isSuccess, Models.ClickEvent clickEvent, string ErrorMessage)> AddClickEventsAsync(Models.ClickEvent clickEvent);
    }
}
