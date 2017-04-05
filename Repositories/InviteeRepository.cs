using System.Collections.Generic;
using System.Linq;
using scheduler.Data;
using scheduler.Models.DatabaseModels;

namespace scheduler.Repositories 
{
    public class InviteeRepository
    {
        private readonly ApplicationDbContext _context;

        public InviteeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Invitee GetById(int id)
        {
            return _context.Invitees.SingleOrDefault(x => x.Id == id);
        }

        public List<Invitee> GetByEventId(int eventId)
        {
            return _context.Invitees.Where(x => x.EventId == eventId).ToList();
        }

        public void Create(Invitee newInvitee)
        {
            _context.Add(newInvitee);
            _context.SaveChanges();
        }

        public void Update(Invitee inviteeToUpdate)
        {
            var existingInvitee = GetById(inviteeToUpdate.Id);
            existingInvitee = inviteeToUpdate;
            _context.SaveChanges();
        }
    }
}