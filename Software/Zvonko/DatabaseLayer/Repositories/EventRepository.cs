using DatabaseLayer.TestRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DatabaseLayer.Repositories {
    public class EventRepository : Repository<Event>, IEventRepository {
        public EventRepository() : base(new ZvonkoModel9()) {

        }

        public IQueryable<Event> Get() {
            var query = from e in Entities
                        select e;
            return query.OrderBy(sorted => sorted.starting_time);
        }

        public IQueryable<Event> GetEvent(Event selectedEvent) {
            var query = from e in Entities
                        where e.id == selectedEvent.id
                        select e;
            return query;
        }

        public IQueryable<Event> GetRecordingsAndEvents() {
            var query = from e in Entities.Include("Recording")
                        select e;
            return query.OrderBy(sorted => sorted.starting_time);
        }

        public override int Add(Event newEvent, bool saveChanges = true)
        {
            Entities.Add(newEvent);
            if (saveChanges)
            {
                return SaveChanges();
            } else return 0;
        }
        
        public override int Remove(Event eventToRemove, bool saveChanges = true) {
            Entities.Attach(eventToRemove);
            Entities.Remove(eventToRemove);
            if (saveChanges) {
                return SaveChanges();
            } else {
                return 0;
            }
        }

        public override int Update(Event entity, bool saveChanges = true)
        {
            var selectedEvent = Entities.SingleOrDefault(s => s.id == entity.id);
            selectedEvent.name = entity.name;
            selectedEvent.description = entity.description;
            selectedEvent.starting_time = entity.starting_time;
            selectedEvent.recordingId = entity.recordingId;

            if (saveChanges) {
                return SaveChanges();
            } else {
                return 0;
            }
        }

        IEnumerable<Event> IEventRepository.GetEvent(Event selectedEvent) {
            throw new NotImplementedException();
        }
    }
}
