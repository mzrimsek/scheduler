using System.Collections.Generic;
using scheduler.Models.DatabaseModels;

namespace scheduler.Interfaces
{
    public interface IInviteeRepository
    {
        Invitee GetById(int id);
        List<Invitee> GetByEventId(int eventId);
        void Create(Invitee newInvitee);
        void Update(Invitee inviteeToUpdate);
    }
}