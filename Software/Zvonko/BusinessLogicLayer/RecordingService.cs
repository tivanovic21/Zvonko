using DatabaseLayer;
using DatabaseLayer.Repositories;
using DatabaseLayer.TestRepositories;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer {
    public class RecordingService
    {
        private readonly IRecordingRepository _recordingRepository;
        private bool isPlaying = false;

        public RecordingService(IRecordingRepository recordingRepository)
        {
            _recordingRepository = recordingRepository;
        }

        public IEnumerable<Recording> GetAllRecordings() {
            return _recordingRepository.Get().ToList();
        }


        public IEnumerable<Recording> GetEmergencyRecordings() {
            return _recordingRepository.GetEmergencyRecordings().ToList();
        }

        public bool AddRecording(Recording newRecording) {
            if (newRecording == null) return false;
            int affectedRows = _recordingRepository.Add(newRecording, true);
            if (affectedRows > 0) {
                return true;
            } else return false;
        }

        public bool UpdateRecording(Recording selectedRecording) {
            if (selectedRecording == null) return false;
            int affectedRows = _recordingRepository.Update(selectedRecording, true);
            if (affectedRows > 0) {
                return true;
            } else return false;
        }

        public bool RemoveRecording(Recording selectedRecording) {
            if (selectedRecording == null) return false;
            int affectedRows = _recordingRepository.Remove(selectedRecording, true);
            if (affectedRows > 0) {
                return true;
            } else return false;
        }

        public void PlayRecording(Recording recording) {
            if (recording == null) return;
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


