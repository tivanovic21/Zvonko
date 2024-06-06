using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Repositories {
    public class RecordingRepository : Repository<Recording> {
        public RecordingRepository() : base(new ZvonkoModel9()) {

        }
        public /*async Task<*/IEnumerable<Recording> Get() {
            var query = from e in Entities
                        select e;
            return /*await*/ query/*.ToListAsync()*/;
        }

        
        public IQueryable<Recording> GetEmergencyRecordings()
        {
            var query = from e in Entities
                        where e.description == "emergency"
                        select e;
            return query;
        }
        
        public override int Add(Recording newRecording, bool saveChanges = true)
        {
            var recording = new Recording {
                id = newRecording.id,
                name = newRecording.name,
                duration = newRecording.duration,
                storedFile = newRecording.storedFile,
                timeCreated = newRecording.timeCreated,
                description = newRecording.description,
                Account = newRecording.Account
                //accountId = null//newRecording.Account
            };

            Entities.Add(recording);
            if (saveChanges)
            {
                return SaveChanges();
            } else return 0;
        }


        public override int Remove(Recording recordingToRemove, bool saveChanges = true) {
            var foreignKeyEvents = Context.Events.Where(e => e.recordingId == recordingToRemove.id);
            foreach(var foreignKeyEvent in foreignKeyEvents) {
                foreignKeyEvent.recordingId = null;
            }
            Entities.Attach(recordingToRemove);
            Entities.Remove(recordingToRemove);
            if (saveChanges) {
                return SaveChanges();
            } else {
                return 0;
            }
        }

        public override int Update(Recording selectedRecording, bool saveChanges = true)
        {
            var recording = Entities.SingleOrDefault(s => s.id == selectedRecording.id);
            recording.name = selectedRecording.name;
            recording.duration = selectedRecording.duration;
            recording.storedFile = selectedRecording.storedFile;
            recording.timeCreated = selectedRecording.timeCreated;
            recording.description = selectedRecording.description;

            if (saveChanges)
            {
                return SaveChanges();
            } else return 0;
        }
        
    }
}
