using System.Collections.Generic;
using scheduler.Models.DatabaseModels;

namespace scheduler.Interfaces
{
    public interface IEventRepository
    {
        Event GetById(int id);
        List<Event> GetByCreatedId(string createdId);
        Event Create(Event newEvent);
        Event Update(Event eventToUpdate);
        void Delete(Event eventToDelete);
    }
}