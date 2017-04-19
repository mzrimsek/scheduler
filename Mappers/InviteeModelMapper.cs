using scheduler.Models;
using scheduler.Models.DatabaseModels;

namespace scheduler.Mappers
{
    public static class InviteeModelMapper
    {
        public static Invitee MapFrom(Event invitedEvent, ApplicationUser inivteeUser)
        {
            return new Invitee
            {
                EventId = invitedEvent.Id,
                UserId = inivteeUser.Id,
                Accepted = false
            };
        }
    }
}