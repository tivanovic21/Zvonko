using DatabaseLayer;
using DatabaseLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer {
    public class RecordingService {

        public async Task<List<Recording>> GetAllRecordings() {
            using (var repo = new RecordingRepository()) {
                var queryResult = repo.Get();
                return (List<Recording>) await queryResult;
            }
        }


        /*
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
        */
    }
}
