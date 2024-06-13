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
        public void GetAllRecordings_UpravljanjeDogadajima_ReturnsAllRecordings() {
            // Arrange
            var recordingService = new RecordingService();

            // Act
            var result = recordingService.GetAllRecordings();

            // Assert
            Assert.NotNull(result); 
            Assert.IsAssignableFrom<IEnumerable<Recording>>(result); 
        }

        [Fact]
        public void GetEmergencyRecordings_HitnaEvakuacija_ReturnsAllRecordings() {
            // Arrange
            var recordingService = new RecordingService();

            // Act
            var result = recordingService.GetEmergencyRecordings();

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<Recording>>(result);
        }

        [Fact]
        public void AddRecording_DodavanjeZvucnogZapisa_DodajeNoviZapis() {
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
    }
}
