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
    }
}
