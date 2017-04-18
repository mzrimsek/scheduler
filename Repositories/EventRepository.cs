using System.Collections.Generic;
using System.Linq;
using scheduler.Data;
using scheduler.Interfaces;
using scheduler.Models.DatabaseModels;

namespace scheduler.Repositories 
{
    public class EventRepository : IEventRepository
    {
        private readonly ApplicationDbContext _context;

        public EventRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Event GetById(int id)
        {
            return _context.Events.SingleOrDefault(x => x.Id == id);
        }

        public List<Event> GetByCreatedId(string createdId) 
        {
            return _context.Events.Where(x => x.CreatedById == createdId).ToList();
        }

        public Event Create(Event newEvent)
        {
            _context.Add(newEvent);
            _context.SaveChanges();

            return newEvent;
        }

        public Event Update(Event eventToUpdate)
        {
            var existingEvent = GetById(eventToUpdate.Id);
            existingEvent = eventToUpdate;
            _context.SaveChanges();

            return existingEvent;
        }
    }
}