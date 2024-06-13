using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using BusinessLogicLayer;
using DatabaseLayer.Repositories;
using DatabaseLayer;

namespace UnitTests {
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

            var existingRecordingId = 1046;

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

        private Recording GetRecordingById(int id) {
            using (var dbContext = new ZvonkoModel9()) {
                return dbContext.Recordings.FirstOrDefault(r => r.id == id);
            }
        }
    }
}
