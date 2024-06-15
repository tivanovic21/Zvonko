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
    }
}
