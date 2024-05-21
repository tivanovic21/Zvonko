using System;
using System.Data.Entity;
using System.Linq;

namespace DatabaseLayer.Repositories {
    public class EventRepository : Repository<Event> {
        public EventRepository() : base(new ZvonkoModel()) {

        }

        public IQueryable<Event> Get() {
            var query = from e in Entities
                        select e;
            return query.OrderBy(sorted => sorted.starting_time);
        }

        public IQueryable<Event> GetRecordingsAndEvents() {
            var query = from e in Entities.Include("Recording")
                        select e;
            return query.OrderBy(sorted => sorted.starting_time);
        }
        
        public int Remove(Event eventToRemove, bool saveChanges = true) {
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
            throw new NotImplementedException();
        }
    }
}
