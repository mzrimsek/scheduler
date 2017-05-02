using System.Collections.Generic;
using scheduler.Models.DatabaseModels;
using scheduler.Models.SchedulerViewModels;

namespace scheduler.Mappers
{
    public static class EventViewModelMapper
    {
        public static EventViewModel MapFrom(Event eventModel, List<string> inviteeEmails)
        {
            var inviteeEmailList = string.Join(", ", inviteeEmails.ToArray());

            return new EventViewModel
            {
                EventId = eventModel.Id,
                EventTitle = eventModel.Title,
                EventDescription = eventModel.Description,
                InviteeEmails = inviteeEmailList,
                StartDate = eventModel.StartTime.ToString("yyyy-MM-dd"),
                EndDate = eventModel.EndTime.ToString("yyyy-MM-dd"),
                StartTime = eventModel.StartTime.ToString("HH:mm"),
                EndTime = eventModel.EndTime.ToString("HH:mm")
            };
        }
    }
}