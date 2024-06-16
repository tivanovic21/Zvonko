using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.TestRepositories
{
    public interface IEventRepository
    {
        IQueryable<Event> Get();
        IQueryable<Event> GetRecordingsAndEvents();
        int Add(Event newEvent, bool saveChanges = true);
        int Remove(Event eventToRemove, bool saveChanges = true);
        int Update(Event entity, bool saveChanges = true);
        IEnumerable<Event> GetEvent(Event selectedEvent);
    }
}
