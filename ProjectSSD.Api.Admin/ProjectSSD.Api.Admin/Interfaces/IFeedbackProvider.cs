using ProjectSSD.Api.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSSD.Api.Admin.Interfaces
{
    public interface IFeedbackProvider
    {
        Task<(bool isSuccess, IEnumerable<Feedback> feedbacks, string ErrorMessage)> GetAllFeedbacks();
        Task<(bool isSuccess, Models.Feedback feedback, string ErrorMessage)> AddFeedback(Models.Feedback schedule);
    }
}
