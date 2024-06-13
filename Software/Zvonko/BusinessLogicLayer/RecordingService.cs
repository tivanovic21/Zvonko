using DatabaseLayer;
using DatabaseLayer.Repositories;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer {
    public class RecordingService {
        private bool isPlaying = false;

        public IEnumerable<Recording> GetAllRecordings() {
            using (var repo = new RecordingRepository()) {
                return repo.Get().ToList();
            }
        }


        public IEnumerable<Recording> GetEmergencyRecordings() {
            using (var repo = new RecordingRepository()) {
                return repo.GetEmergencyRecordings().ToList();
            }
        }

        public bool AddRecording(Recording newRecording) {
            using (var repo = new RecordingRepository()) {
                int affectedRows = repo.Add(newRecording, true);
                if (affectedRows > 0) {
                    return true;
                } else return false;
            }
        }

        public bool UpdateRecording(Recording selectedRecording) {
            using (var repo = new RecordingRepository()) {
                int affectedRows = repo.Update(selectedRecording, true);
                if (affectedRows > 0) {
                    return true;
                } else return false;
            }
        }

        public bool RemoveRecording(Recording selectedRecording) {
            using (var repo = new RecordingRepository()) {
                int affectedRows = repo.Remove(selectedRecording, true);
                if (affectedRows > 0) {
                    return true;
                } else return false;
            }
        }

        public void PlayRecording(Recording recording) {
            var _waveOut = new WaveOutEvent();
            if (_waveOut != null) {
                StopRecording();
            }
            var audioFileReader = new AudioFileReader(recording.storedFile);
            _waveOut.Init(audioFileReader);
            _waveOut.Play();
            isPlaying = true;
        }

        private void StopRecording() {
            var _waveOut = new WaveOutEvent();
            if (_waveOut != null && _waveOut.PlaybackState == PlaybackState.Playing) {
                _waveOut.Stop();
                _waveOut.Dispose();
                _waveOut = null;
                isPlaying = false;
            }
        }

        public bool IsPlaying() {
            return isPlaying;
        }
    }
}


