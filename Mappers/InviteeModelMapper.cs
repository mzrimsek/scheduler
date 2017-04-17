using scheduler.Models.DatabaseModels;

namespace scheduler.Mappers
{
    public static class InviteeModelMapper
    {
        public static Invitee MapFrom(Event invitedEvent, string userId)
        {
            return new Invitee
            {
                EventId = invitedEvent.Id,
                UserId = userId,
                Accepted = false
            };
        }
    }
}