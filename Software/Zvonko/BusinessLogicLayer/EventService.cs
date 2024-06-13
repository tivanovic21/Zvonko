using DatabaseLayer;
using DatabaseLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer {
    public class EventService {
        
    public bool AddEvent(Event newEvent)
    {
        if (newEvent == null) return false;
        using (var repo = new EventRepository())
        {
            int affectedRows = repo.Add(newEvent, true);
            if (affectedRows > 0)
            {
                return true;
            } else return false;
        }
    }
    public IEnumerable<Event> GetAllEvents() {
            using (var repo = new EventRepository()) {
                return repo.Get().ToList();
            }
    }

        public IEnumerable<Event> GetAllEventsAndRecordings() {
            using (var repo = new EventRepository()) {
                return repo.GetRecordingsAndEvents().ToList();
            }
        }
        public bool RemoveEvent(Event eventToRemove) {
            if (eventToRemove == null) return false;
            using (var repo = new EventRepository()) {
                int affectedRows = repo.Remove(eventToRemove, true);
                return affectedRows > 0;
            }
        }

    }
}
