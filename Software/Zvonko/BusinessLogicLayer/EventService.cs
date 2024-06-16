using DatabaseLayer;
using DatabaseLayer.Repositories;
using DatabaseLayer.TestRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer {
    public class EventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public bool AddEvent(Event newEvent)
        {
            if (newEvent == null) return false;
            int affectedRows = _eventRepository.Add(newEvent, true);
            return affectedRows > 0;
        }
        public IEnumerable<Event> GetAllEvents() {
            return _eventRepository.Get().ToList();
        }
        
        public IEnumerable<Event> GetSelectedEvent(Event selectedEvent) {
            return _eventRepository.GetEvent(selectedEvent).ToList();
        }

        public IEnumerable<Event> GetAllEventsAndRecordings() {
            return _eventRepository.GetRecordingsAndEvents().ToList();
        }
        public bool RemoveEvent(Event eventToRemove) {
            if (eventToRemove == null) return false;
            int affectedRows = _eventRepository.Remove(eventToRemove, true);
            return affectedRows > 0;
        }

        public bool UpdateEvent(Event selectedEvent) {
            if (selectedEvent == null) return false;
            int affectedRows = _eventRepository.Update(selectedEvent, true);
            return affectedRows > 0;
        }

    }
}
