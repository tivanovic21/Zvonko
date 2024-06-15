using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class StreamService_Tests
    {
        [Fact]
        public void OnStartStreaming_InitializesRecorderAndPlayer()
        {
            // Arrange
            var streamService = new StreamService(TimeSpan.FromSeconds(5));

            // Act
            streamService.OnStartStreaming();
            var recorderStatus = streamService.RecorderStatus();
            var playerStatus = streamService.PlayerStatus();

            // Assert
            Assert.True(recorderStatus && playerStatus);
        }

        [Fact]
        public void OnStopStreaming_DisposesRecorderAndPlayer()
        {
            // Arrange
            var streamService = new StreamService(TimeSpan.FromSeconds(5));
            streamService.OnStartStreaming();

            // Act
            streamService.OnStopStreaming();
            var recorderStatus = streamService.RecorderStatus();
            var playerStatus = streamService.PlayerStatus();

            // Assert
            Assert.False(recorderStatus && playerStatus);
        }

        [Fact]
        public void RecorderStatus_ReturnsTrueIfRecorderIsNotNull()
        {
            // Arrange
            var streamService = new StreamService(TimeSpan.FromSeconds(5));
            streamService.OnStartStreaming();

            // Act
            var recorderStatus = streamService.RecorderStatus();

            // Assert
            Assert.True(recorderStatus);
        }

        [Fact]
        public void PlayerStatus_ReturnsTrueIfPlayerIsNotNull()
        {
            // Arrange
            var streamService = new StreamService(TimeSpan.FromSeconds(5));
            streamService.OnStartStreaming();

            // Act
            var playerStatus = streamService.PlayerStatus();

            // Assert
            Assert.True(playerStatus);
        }

        [Fact]
        public void Dispose_DisposesRecorderAndPlayer()
        {
            // Arrange
            var streamService = new StreamService(TimeSpan.FromSeconds(5));
            streamService.OnStartStreaming();

            // Act
            streamService.Dispose();
            var recorderStatus = streamService.RecorderStatus();
            var playerStatus = streamService.PlayerStatus();

            // Assert
            Assert.False(recorderStatus && playerStatus);
        }
    }
}
