using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using BusinessLogicLayer;
using DatabaseLayer.Repositories;
using DatabaseLayer;
using System.Security.Policy;

namespace IntegrationTests
{
    public class RecordingService_Tests {
        [Fact]
        public void GetAllRecordings_UcitavanjeSvihZvucnihZapisa_ReturnsAllRecordings() {
            // Arrange
            var recordingService = new RecordingService();

            // Act
            var result = recordingService.GetAllRecordings();

            // Assert
            Assert.NotNull(result); 
            Assert.IsAssignableFrom<IEnumerable<Recording>>(result); 
        }

        [Fact]
        public void GetEmergencyRecordings_DohvacanjeZvucnihZapisaHitneEvakuacije_ReturnsAllRecordings() {
            // Arrange
            var recordingService = new RecordingService();

            // Act
            var result = recordingService.GetEmergencyRecordings();

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<Recording>>(result);
        }

        [Fact]
        public void AddRecording_UvozZvucnogZapisaOdgovarajucegFormata_DodajeNoviZapis() {
            // Arrange
            var recordingService = new RecordingService();
            var newRecording = new Recording {
                name = "Recording Add New Test",
                duration = TimeSpan.FromMinutes(5),
                description = "Test description",
                storedFile = "test_file.mp3",
                AccountId = 1,
                timeCreated = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };

            // Act
            var result = recordingService.AddRecording(newRecording);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void RemoveRecording_BrisanjeOdabranogZvucnogZapisa_RemovedRecording() {
            // Arrange
            var recordingService = new RecordingService();

            var existingRecordingId = 1053;

            // Act
            var existingRecording = GetRecordingById(existingRecordingId);
            if (existingRecording != null) {
                var result = recordingService.RemoveRecording(existingRecording);

                // Assert
                Assert.True(result);
            } else {
                Assert.True(false, $"Recording with ID : {existingRecordingId} not found.");
            }
        }

        [Fact]
        public void UpdateRecording_AzuriranjePodatakaZvucnogZapisa_UpdatedRecording() {
            // Arrange
            var recordingService = new RecordingService();
            var existingRecordingId = 1052;
            var updatedRecording = new Recording {
                id = existingRecordingId,
                name = "Updated Recording Name",
                duration = TimeSpan.FromMinutes(10),
                description = "Updated description",
                storedFile = "updated_file.mp3",
                AccountId = 1,
                timeCreated = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };

            // Act
            var result = recordingService.UpdateRecording(updatedRecording);

            // Assert
            var retrievedRecording = GetRecordingById(existingRecordingId);
            Assert.True(result);
            
            Assert.NotNull(retrievedRecording);
            Assert.Equal(updatedRecording.name, retrievedRecording.name);
            Assert.Equal(updatedRecording.duration, retrievedRecording.duration);
            Assert.Equal(updatedRecording.description, retrievedRecording.description);
            Assert.Equal(updatedRecording.storedFile, retrievedRecording.storedFile);
            Assert.Equal(updatedRecording.AccountId, retrievedRecording.AccountId);
        }

        [Fact]
        public void PlayRecording_PokretanjeZvucnogZapisaZvona_StartsPlayingRecording() {
            // Arrange
            var recordingService = new RecordingService();
            string relativePath = @"..\..\..\TestSounds\Cool Ringtone.mp3";
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string absolutePath = Path.GetFullPath(Path.Combine(basePath, relativePath));

            // Assert
            Assert.True(File.Exists(absolutePath), $"File '{absolutePath}' does not exist.");

            var recording = new Recording {
                storedFile = absolutePath
            };

            // Act
            recordingService.PlayRecording(recording);

            // Assert
            Assert.True(recordingService.IsPlaying(), "Recording should be playing.");
        }

        private Recording GetRecordingById(int id) {
            using (var dbContext = new ZvonkoModel9()) {
                return dbContext.Recordings.FirstOrDefault(r => r.id == id);
            }
        }
    }
}
