using BusinessLogicLayer;
using DatabaseLayer;
using DatabaseLayer.TestRepositories;
using FakeItEasy;
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
        private IEventRepository _fakeRepo;
        private EventService _eventService;

        public EventService_Tests()
        {
            _fakeRepo = A.Fake<IEventRepository>();
            _eventService = new EventService(_fakeRepo);
        }

        [Fact]
        public void AddEvent_NullEvent_ReturnsFalse()
        {
            var result = _eventService.AddEvent(null);
            Assert.False(result);
        }

        [Fact]
        public void AddEvent_ValidEvent_ReturnsTrue()
        {
            var newEvent = new Event
            {
                id = 1,
                name = "testEvent",
                description = "testEvent",
                starting_time = DateTime.Now.TimeOfDay,
                date = DateTime.Now,
                typeOfEventId = 1,
                monday = true
            };
            A.CallTo(() => _fakeRepo.Add(newEvent, true)).Returns(1);

            var result = _eventService.AddEvent(newEvent);

            Assert.True(result);
        }

        [Fact]
        public void AddEvent_InvalidEvent_ReturnsFalse()
        {
            var newInvalidEvent = new Event
            {
                id = 1,
                name = "invalidEvent",
                description = "invalidEvent",
                starting_time = DateTime.Now.TimeOfDay,
                date = DateTime.Now,
            };
            A.CallTo(() => _fakeRepo.Add(newInvalidEvent, true)).Returns(0);

            var result = _eventService.AddEvent(newInvalidEvent);

            Assert.False(result);
        }

        [Fact]
        public void GetAllEvents_HasValidEvents_ReturnsListOfEvents()
        {
            var returnEvents = new List<Event>
            {
                new Event { id = 1, name = "event1", description = "event1", date = DateTime.Now, starting_time = DateTime.Now.TimeOfDay, typeOfEventId = 1, monday = true },
                new Event { id = 2, name = "event2", description = "event2", date = DateTime.Now, starting_time = DateTime.Now.TimeOfDay, typeOfEventId = 1, tuesday = true },
                new Event { id = 3, name = "event3", description = "event3", date = DateTime.Now, starting_time = DateTime.Now.TimeOfDay, typeOfEventId = 1, friday = true }
            };
            A.CallTo(() => _fakeRepo.Get()).Returns(returnEvents.AsQueryable());

            var result = _eventService.GetAllEvents();

            Assert.Equal(returnEvents, result);
        }

        [Fact]
        public void GetAllEvents_HasNoEvents_ReturnsEmptyList()
        {
            var returnEvents = new List<Event>
            {
            };
            A.CallTo(() => _fakeRepo.Get()).Returns(returnEvents.AsQueryable());

            var result = _eventService.GetAllEvents();

            Assert.Equal(returnEvents, result);
            Assert.Empty(result);
        }

        [Fact]
        public void GetAllEventsAndRecordings_HasValidEvents_ReturnsListOfEvents()
        {
            var returnEvents = new List<Event>
            {
                new Event { id = 1, name = "event1", description = "event1", date = DateTime.Now, starting_time = DateTime.Now.TimeOfDay, typeOfEventId = 1, monday = true },
                new Event { id = 2, name = "event2", description = "event2", date = DateTime.Now, starting_time = DateTime.Now.TimeOfDay, typeOfEventId = 1, tuesday = true },
                new Event { id = 3, name = "event3", description = "event3", date = DateTime.Now, starting_time = DateTime.Now.TimeOfDay, typeOfEventId = 1, friday = true }
            };
            A.CallTo(() => _fakeRepo.GetRecordingsAndEvents()).Returns(returnEvents.AsQueryable());

            var result = _eventService.GetAllEventsAndRecordings();

            Assert.Equal(returnEvents, result);
        }

        [Fact]
        public void GetAllEventsAndRecordings_HasNoEvents_ReturnsEmptyList()
        {
            var returnEvents = new List<Event>
            {
            };
            A.CallTo(() => _fakeRepo.GetRecordingsAndEvents()).Returns(returnEvents.AsQueryable());

            var result = _eventService.GetAllEventsAndRecordings();

            Assert.Equal(returnEvents, result);
            Assert.Empty(result);
        }

        [Fact]
        public void RemoveEvent_ValidEvent_ReturnsTrue()
        {
            var eventToRemove = new Event
            {
                id = 1,
                name = "testEvent",
                description = "testEvent",
                starting_time = DateTime.Now.TimeOfDay,
                date = DateTime.Now,
                typeOfEventId = 1,
                monday = true
            };
            A.CallTo(() => _fakeRepo.Remove(eventToRemove, true)).Returns(1);

            var result = _eventService.RemoveEvent(eventToRemove);

            Assert.True(result);
        }

        [Fact]
        public void RemoveEvent_InvalidEvent_ReturnsFalse()
        {
            var eventToRemove = new Event
            {
                name = "invalidEvent",
                description = "invalidEvent",
                starting_time = DateTime.Now.TimeOfDay,
                date = DateTime.Now,
            };
            A.CallTo(() => _fakeRepo.Remove(eventToRemove, true)).Returns(0);

            var result = _eventService.RemoveEvent(eventToRemove);

            Assert.False(result);
        }

        [Fact]
        public void RemoveEvent_NullEvent_ReturnsFalse()
        {
            var result = _eventService.RemoveEvent(null);
            Assert.False(result);
        }
    }
}
