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
                StartDate = eventModel.StartTime.ToString("d"),
                EndDate = eventModel.EndTime.ToString("d"),
                StartTime = eventModel.StartTime.ToString("t"),
                EndTime = eventModel.EndTime.ToString("t")
            };
        }
    }
}