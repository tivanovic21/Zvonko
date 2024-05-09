﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Repositories {
    public class RecordingRepository : Repository<Recording> {
        public RecordingRepository() : base(new ZvonkoModel()) {

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

        public override int Update(Recording selectedRecording, bool saveChanges = true)
        {
            var recording = Entities.SingleOrDefault(s => s.id == selectedRecording.id);
            recording.name = selectedRecording.name;
            recording.duration = selectedRecording.duration;
            recording.storedFile = selectedRecording.storedFile;
            recording.timeCreated = selectedRecording.timeCreated;
            recording.description = selectedRecording.description;
            recording.Account = selectedRecording.Account;
            if (saveChanges)
            {
                return SaveChanges();
            } else return 0;
        }
        
    }
}
