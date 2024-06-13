using BusinessLogicLayer;
using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class EventService_Tests
    {
        [Fact]
        public void AddEvent_GivenValidEvent_ReturnsTrue()
        {
            // Arrange
            var eventService = new EventService();
            var newEvent = new Event
            {
                name = "testEvent",
                description = "testEvent",
                starting_time = DateTime.Now.TimeOfDay,
                date = DateTime.Now,
                monday = true,
                accountId = 1,
                recordingId = 1048
            };

            // Act
            var result = eventService.AddEvent(newEvent);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void AddEvent_GivenNullEvent_ReturnsFalse()
        {
            // Arrange
            var eventService = new EventService();

            // Act
            var result = eventService.AddEvent(null);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GetAllEvents_ReturnsListOfEvents()
        {
            // Arrange
            var eventService = new EventService();

            // Act
            var result = eventService.GetAllEvents();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetAllEventsAndRecordings_ReturnsListOfEventsAndRecordings()
        {
            // Arrange
            var eventService = new EventService();

            // Act
            var result = eventService.GetAllEventsAndRecordings();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void RemoveEvent_GivenValidEvent_ReturnsTrue()
        {
            // Arrange
            var eventService = new EventService();
            var selectedEvent = new Event
            {
                id = 19, // must match existing id in db
                name = "testEvent",
                description = "testEvent",
                starting_time = DateTime.Now.TimeOfDay,
                date = DateTime.Now,
                monday = true,
                accountId = 1,
                recordingId = 1
            };

            // Act
            var result = eventService.RemoveEvent(selectedEvent);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void RemoveEvent_GivenNullEvent_ReturnsFalse()
        {
            // Arrange
            var eventService = new EventService();

            // Act
            var result = eventService.RemoveEvent(null);

            // Assert
            Assert.False(result);
        }   
    }
}
