using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.TestRepositories
{
    public interface IRecordingRepository
    {
        IEnumerable<Recording> Get();
        IQueryable<Recording> GetEmergencyRecordings();
        int Add(Recording newRecording, bool saveChanges = true);
        int Remove(Recording recordingToRemove, bool saveChanges = true);
        int Update(Recording entity, bool saveChanges = true);
    }
}
