using System.Collections.Generic;
using System.Linq;
using scheduler.Data;
using scheduler.Models.DatabaseModels;

namespace scheduler.Repositories 
{
    public class EventRepository
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

        public List<Event> GetByCreatedId(int createdId) 
        {
            return _context.Events.Where(x => x.CreatedById == createdId).ToList();
        }

        public void Create(Event newEvent)
        {
            _context.Add(newEvent);
            _context.SaveChanges();
        }

        public void Update(Event eventToUpdate)
        {
            var existingEvent = GetById(eventToUpdate.Id);
            existingEvent.Title = eventToUpdate.Title;
            existingEvent.Description = eventToUpdate.Description;
            existingEvent.StartTime = eventToUpdate.StartTime;
            existingEvent.EndTime = eventToUpdate.EndTime;
            _context.SaveChanges();
        }
    }
}