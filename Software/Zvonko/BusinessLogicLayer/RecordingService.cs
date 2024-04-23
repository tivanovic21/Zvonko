using DatabaseLayer;
using DatabaseLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer {
    public class RecordingService {

        public List<Recording> GetAllRecordings() {
            using (var repo = new RecordingRepository()) {
                return repo.Get().ToList();
            }
        }
    }
}
