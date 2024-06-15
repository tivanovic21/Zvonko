using BusinessLogicLayer;
using DatabaseLayer;
using DatabaseLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    public class EventService_Tests
    {
        [Fact]
        public void AddEvent_GivenValidEvent_ReturnsTrue()
        {
            // Arrange
            EventRepository eventRepository = new EventRepository();
            EventService eventService = new EventService(eventRepository);
            var newEvent = new Event
            {
                name = "testEvent",
                description = "testEvent",
                starting_time = DateTime.Now.TimeOfDay,
                date = DateTime.Now,
                monday = true,
                accountId = 1,
                recordingId = 1055
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
            EventRepository eventRepository = new EventRepository();
            EventService eventService = new EventService(eventRepository);

            // Act
            var result = eventService.AddEvent(null);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GetAllEvents_ReturnsListOfEvents()
        {
            // Arrange
            EventRepository eventRepository = new EventRepository();
            EventService eventService = new EventService(eventRepository);

            // Act
            var result = eventService.GetAllEvents();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetAllEventsAndRecordings_ReturnsListOfEventsAndRecordings()
        {
            // Arrange
            EventRepository eventRepository = new EventRepository();
            EventService eventService = new EventService(eventRepository);

            // Act
            var result = eventService.GetAllEventsAndRecordings();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void RemoveEvent_GivenValidEvent_ReturnsTrue()
        {
            // Arrange
            EventRepository eventRepository = new EventRepository();
            EventService eventService = new EventService(eventRepository);
            var selectedEvent = new Event
            {
                id = 32, // must match existing id in db
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
            EventRepository eventRepository = new EventRepository();
            EventService eventService = new EventService(eventRepository);

            // Act
            var result = eventService.RemoveEvent(null);

            // Assert
            Assert.False(result);
        }   
    }
}
