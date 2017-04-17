using System;
using scheduler.Models;
using scheduler.Models.DatabaseModels;
using scheduler.Models.SchedulerViewModels;

namespace scheduler.Mappers
{
    public static class EventModelMapper
    {
        public static Event MapFrom(ApplicationUser currentUser, EventViewModel viewModel)
        {
            return new Event
            {
                Title = viewModel.EventTitle,
                Description = viewModel.EventDescription,
                CreatedById = currentUser.Id,
                CreatedOn = DateTime.UtcNow,
                StartTime = GetFullDateTime(viewModel.StartDate, viewModel.StartTime),
                EndTime = GetFullDateTime(viewModel.EndDate, viewModel.EndTime)
            };
            
        }

        private static DateTime GetFullDateTime(string date, string time)
        {
            var parsedDate = Convert.ToDateTime(date);

            TimeSpan parsedTime;
            TimeSpan.TryParse(time, out parsedTime);

            return parsedDate.Add(parsedTime);
        }
    }
}