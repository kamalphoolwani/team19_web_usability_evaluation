using ProjectSSD.Api.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSSD.Api.Admin.Interfaces
{
    public interface IScheduleProvider
    {
        Task<(bool isSuccess, IEnumerable<Schedule> schedules, string ErrorMessage)> GetAllSchedulesAsync();
        Task<(bool isSuccess, Models.Schedule schedule, string ErrorMessage)> AddScheduleAsync(Models.Schedule schedule);
    }
}
