using System.Collections.Generic;
using scheduler.Models.DatabaseModels;

namespace scheduler.Interfaces
{
    public interface IInviteeRepository
    {
        Invitee GetById(int id);
        Invitee GetByEventIdAndUserId(int eventId, string userId);
        List<Invitee> GetByUserId(string userId);
        List<Invitee> GetByEventId(int eventId);
        void Create(Invitee newInvitee);
        void Update(Invitee inviteeToUpdate);
        void Delete(Invitee inviteeToDelete);
    }
}