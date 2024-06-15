using BusinessLogicLayer;
using DatabaseLayer;
using DatabaseLayer.TestRepositories;
using FakeItEasy;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using Xunit;
using System.IO;

namespace UnitTests
{
    public class RecordingService_Tests
    {
        private IRecordingRepository _fakeRepo;
        private RecordingService _recordingService;

        public RecordingService_Tests()
        {
            _fakeRepo = A.Fake<IRecordingRepository>();
            _recordingService = new RecordingService(_fakeRepo);
        }

        [Fact]
        public void GetAllRecordings_RecordingsAvailable_ReturnsAllRecordings()
        {
            var recordings = new List<Recording>
            {
                new Recording
                {
                    id = 1,
                    name = "Recording 1",
                    duration = TimeSpan.FromMinutes(5),
                    description = "Test description",
                    storedFile = "file1.mp3",
                    AccountId = 1,
                    timeCreated = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                },
                new Recording
                {
                    id = 2,
                    name = "Recording 2",
                    duration = TimeSpan.FromMinutes(10),
                    description = "Test description",
                    storedFile = "file2.mp3",
                    AccountId = 1,
                    timeCreated = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                }
            };
            A.CallTo(() => _fakeRepo.Get()).Returns(recordings);

            var result = _recordingService.GetAllRecordings();

            Assert.Equal(recordings, result);
        }

        [Fact]
        public void GetAllRecordings_NoRecordingsAvailable_ReturnsEmptyList()
        {
            var emptyRecordings = new List<Recording> { };
            A.CallTo(() => _fakeRepo.Get()).Returns(emptyRecordings);

            var result = _recordingService.GetAllRecordings();

            Assert.Equal(emptyRecordings, result);
            Assert.Empty(result);

        }

        [Fact]
        public void GetEmergencyRecordings_RecordingsAvailable_ReturnsRecordings()
        {
            var emergencyRecordings = new List<Recording>
            {
                new Recording
                {
                    id = 1,
                    name = "Recording emergency 1",
                    duration = TimeSpan.FromMinutes(5),
                    description = "emergency",
                    storedFile = "file1.mp3",
                    AccountId = 1,
                    timeCreated = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                },
                new Recording
                {
                    id = 2,
                    name = "Recording emergency 2",
                    duration = TimeSpan.FromMinutes(10),
                    description = "emergency",
                    storedFile = "file2.mp3",
                    AccountId = 1,
                    timeCreated = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                }
            };
            A.CallTo(() => _fakeRepo.GetEmergencyRecordings()).Returns(emergencyRecordings.AsQueryable());

            var result = _recordingService.GetEmergencyRecordings();

            Assert.Equal(emergencyRecordings, result);
        }

        [Fact]
        public void GetEmergencyRecordings_NoRecordingsAvailable_ReturnsEmptyList()
        {
            var emptyEmergencyRecordings = new List<Recording> { };
            A.CallTo(() => _fakeRepo.GetEmergencyRecordings()).Returns(emptyEmergencyRecordings.AsQueryable());

            var result = _recordingService.GetEmergencyRecordings();

            Assert.Equal(emptyEmergencyRecordings, result);
            Assert.Empty(result);
        }

        [Fact]
        public void AddRecording_NullRecording_ReturnsFalse()
        {
            var result = _recordingService.AddRecording(null);
            Assert.False(result);
        }

        [Fact]
        public void AddRecording_ValidRecording_ReturnsTrue()
        {
            var newRecording = new Recording
            {
                id = 1,
                name = "Recording Add New Test",
                duration = TimeSpan.FromMinutes(5),
                description = "Test description",
                storedFile = "test_file.mp3",
                AccountId = 1,
                timeCreated = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };
            A.CallTo(() => _fakeRepo.Add(newRecording, true)).Returns(1);

            var result = _recordingService.AddRecording(newRecording);

            Assert.True(result);
        }

        [Fact]
        public void AddRecording_InvalidRecording_ReturnsFalse()
        {
            var newInvalidRecording = new Recording
            {
                name = "Recording Add New Test",
                duration = TimeSpan.FromMinutes(5),
                description = "Test description",
                timeCreated = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };
            A.CallTo(() => _fakeRepo.Add(newInvalidRecording, true)).Returns(0);

            var result = _recordingService.AddRecording(newInvalidRecording);

            Assert.False(result);
        }

        [Fact]
        public void UpdateRecording_NullRecording_ReturnsFalse()
        {
            var result = _recordingService.UpdateRecording(null);
            Assert.False(result);
        }

        [Fact]
        public void UpdateRecording_ValidRecording_ReturnsTrue()
        {
            var selectedRecording = new Recording
            {
                id = 1,
                name = "Recording Update Test",
                duration = TimeSpan.FromMinutes(5),
                description = "Test description",
                storedFile = "test_file.mp3",
                AccountId = 1,
                timeCreated = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };
            A.CallTo(() => _fakeRepo.Update(selectedRecording, true)).Returns(1);

            var result = _recordingService.UpdateRecording(selectedRecording);

            Assert.True(result);
        }

        [Fact]
        public void UpdateRecording_InvalidRecording_ReturnsFalse()
        {
            var selectedInvalidRecording = new Recording
            {
                name = "Recording Update Test",
                duration = TimeSpan.FromMinutes(5),
                description = "Test description",
                timeCreated = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };
            A.CallTo(() => _fakeRepo.Update(selectedInvalidRecording, true)).Returns(0);

            var result = _recordingService.UpdateRecording(selectedInvalidRecording);

            Assert.False(result);
        }

        [Fact]
        public void RemoveRecording_NullRecording_ReturnsFalse()
        {
            var result = _recordingService.RemoveRecording(null);
            Assert.False(result);
        }

        [Fact]
        public void RemoveRecording_ValidRecording_ReturnsTrue()
        {
            var selectedRecording = new Recording
            {
                id = 1,
                name = "Recording Remove Test",
                duration = TimeSpan.FromMinutes(5),
                description = "Test description",
                storedFile = "test_file.mp3",
                AccountId = 1,
                timeCreated = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };
            A.CallTo(() => _fakeRepo.Remove(selectedRecording, true)).Returns(1);

            var result = _recordingService.RemoveRecording(selectedRecording);

            Assert.True(result);
        }

        [Fact]
        public void RemoveRecording_InvalidRecording_ReturnsFalse()
        {
            var selectedInvalidRecording = new Recording
            {
                name = "Recording Remove Test",
                duration = TimeSpan.FromMinutes(5),
                description = "Test description",
                timeCreated = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };
            A.CallTo(() => _fakeRepo.Remove(selectedInvalidRecording, true)).Returns(0);

            var result = _recordingService.RemoveRecording(selectedInvalidRecording);

            Assert.False(result);
        }

        [Fact]
        public void PlayRecording_NullRecording_DoesNotStartPlayback()
        {
            Recording newRec = null;

            _recordingService.PlayRecording(newRec);

            Assert.False(_recordingService.IsPlaying());
        }

        [Fact]
        public void PlayRecording_ValidRecording_StartsPlayback()
        {
            string relativePath = @"..\..\..\TestSounds\Cool Ringtone.mp3";
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string absolutePath = Path.GetFullPath(Path.Combine(basePath, relativePath));
            var recording = new Recording { storedFile = absolutePath };

            _recordingService.PlayRecording(recording);

            Assert.True(_recordingService.IsPlaying());
        }

        [Fact]
        public void PlayRecording_ValidWavRecording_StartsPlayback()
        {
            string relativePath = @"..\..\..\TestSounds\Spongebob Ringtone.wav";
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string absolutePath = Path.GetFullPath(Path.Combine(basePath, relativePath));
            var recording = new Recording { storedFile = absolutePath };

            _recordingService.PlayRecording(recording);

            Assert.True(_recordingService.IsPlaying());
        }

        [Fact]
        public void StopRecording_WhilePlaying_StopsPlayback()
        {
            string relativePath = @"..\..\..\TestSounds\Cool Ringtone.mp3";
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string absolutePath = Path.GetFullPath(Path.Combine(basePath, relativePath));
            var recording = new Recording { storedFile = absolutePath };

            _recordingService.PlayRecording(recording);
            _recordingService.StopRecording();

            Assert.False(_recordingService.IsPlaying());
        }

        [Fact]
        public void PlayRecording_FailsToInitializeWaveOut_DoesNotStartPlayback()
        {
            var recording = new Recording { storedFile = "non_existing_file.mp3" };

            _recordingService.PlayRecording(recording);

            Assert.False(_recordingService.IsPlaying());
        }

        [Fact]
        public void PlayRecording_FailsToInitializeWaveOutForWav_DoesNotStartPlayback()
        {
            var recording = new Recording { storedFile = "non_existing_file.wav" };

            _recordingService.PlayRecording(recording);

            Assert.False(_recordingService.IsPlaying());
        }

        [Fact]
        public void PlayRecording_FailsToPlayRecording_DoesNotStartPlayback()
        {
            string relativePath = @"..\..\..\TestSounds\Invalid Ringtone.mp3";
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string absolutePath = Path.GetFullPath(Path.Combine(basePath, relativePath));
            var recording = new Recording { storedFile = absolutePath };

            _recordingService.PlayRecording(recording);

            Assert.False(_recordingService.IsPlaying());
        }

        [Fact]
        public void PlayRecording_PlayMultipleRecordings_StopsPlayback()
        {
            var recording1 = new Recording { storedFile = "file1.mp3" };
            var recording2 = new Recording { storedFile = "file2.mp3" };

            Task.Run(() => _recordingService.PlayRecording(recording1));
            Task.Run(() => _recordingService.PlayRecording(recording2));

            Task.Delay(1000).Wait();

            Assert.False(_recordingService.IsPlaying());
        }

        [Fact]
        public void StopRecording_SoundIsNotPlaying_ReturnsFalse()
        {
            _recordingService.StopRecording();

            Assert.False(_recordingService.IsPlaying());
        }

        [Fact]
        public void IsPlaying_NoSoundIsPlaying_ReturnsFalse()
        {
            var result = _recordingService.IsPlaying();

            Assert.False(result);
        }
    }
}
