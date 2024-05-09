using DatabaseLayer;
using DatabaseLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer {
    public class RecordingService {

        public /*async  Task<*/IEnumerable<Recording> GetAllRecordings() {
            using (var repo = new RecordingRepository()) {
                return /*await*/ repo.Get().ToList();
            }
        }

        public IEnumerable<Recording> GetEmergencyRecordings()
        {
            using (var repo = new RecordingRepository())
            {
                return repo.GetEmergencyRecordings().ToList();
            }
        }
        
        public bool AddRecording(Recording newRecording)
        {
            using (var repo = new RecordingRepository())
            {
                int affectedRows = repo.Add(newRecording, true);
                if (affectedRows > 0)
                {
                    return true;
                } else return false;
            }
        }

        public bool UpdateRecording(Recording selectedRecording)
        {
            using (var repo = new RecordingRepository())
            {
                int affectedRows = repo.Update(selectedRecording, true);
                if (affectedRows > 0)
                {
                    return true;
                } else return false;
            }
        }

        public bool RemoveRecording(Recording selectedRecording)
        {
            using (var repo = new RecordingRepository())
            {
                int affectedRows = repo.Remove(selectedRecording, true);
                if (affectedRows > 0)
                {
                    return true;
                } else return false;
            }
        }
        
    }
}
