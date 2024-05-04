using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Repositories {
    public class RecordingRepository : Repository<Recording> {
        public RecordingRepository() : base(new ZvonkoModel()) {

        }
        public async Task<IQueryable<Recording>> Get() {
            var query = from e in Entities
                        select e;
            return (IQueryable<Recording>)await query.ToListAsync();
        }

        /*
        public override int Add(Recording newRecording, bool saveChanges = true)
        {
            var recording = new Recording
            {
                name = newRecording.name,
                duration = newRecording.duration,
                storedFile = newRecording.storedFile,
                timeCreated = newRecording.timeCreated,
                description = newRecording.description,
                Account = newRecording.Account
            };

            Entities.Add(recording);
            if (saveChanges)
            {
                return SaveChanges();
            } else return 0;
        }
        */
    }
}
