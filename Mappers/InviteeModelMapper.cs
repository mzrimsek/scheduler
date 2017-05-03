using scheduler.Models;
using scheduler.Models.DatabaseModels;

namespace scheduler.Mappers
{
    public static class InviteeModelMapper
    {
        public static Invitee MapFrom(Event invitedEvent, ApplicationUser inviteeUser)
        {
            return new Invitee
            {
                EventId = invitedEvent.Id,
                UserId = inviteeUser.Id,
                Accepted = false
            };
        }
    }
}
