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

    }
}
