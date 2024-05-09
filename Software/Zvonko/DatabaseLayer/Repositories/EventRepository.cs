using System;
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

        public override int Add(Event newEvent, bool saveChanges = true) {
            var eventEntity = new Event {
                name = newEvent.name,
                description = newEvent.description,
                starting_time = newEvent.starting_time,
                day_of_the_week = newEvent.day_of_the_week,
                accountId = newEvent.accountId,
                recordingId = newEvent.recordingId,
                typeOfEventId = newEvent.typeOfEventId
            };

            Entities.Add(eventEntity);
            if (saveChanges) {
                return SaveChanges();
            } else {
                return 0;
            }
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
