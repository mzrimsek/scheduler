using System.Collections.Generic;
using scheduler.Models.DatabaseModels;

namespace scheduler.Interfaces
{
    public interface IEventRepository
    {
        Event GetById(int id);
        List<Event> GetByCreatedId(string createdId);
        void Create(Event newEvent);
        void Update(Event eventToUpdate);
    }
}