using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace Zvonko {
    public partial class App : Application {
        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);
            StartPeriodicTask();
        }

        public void StartPeriodicTask() {
            Task.Run(async () => {
                while (true) {
                    await Task.Delay(100);
                    Application.Current.Dispatcher.Invoke(() => {
                        PlayEvent();
                    });
                }
            });
        }

        private void PlayEvent() {
            var dayOfTheWeek = DateTime.Now.DayOfWeek;
            var startingTime = DateTime.Now.TimeOfDay;
            var date = DateTime.Now.Date;

            EventService eventService = new EventService();
            RecordingService recordingService = new RecordingService();

            var allEvents = eventService.GetAllEventsAndRecordings();
            List<String> days = new List<String>();

            foreach (var events in allEvents) {
                days.Clear();
                if ((bool)events.monday) days.Add(DayOfWeek.Monday.ToString());
                if ((bool)events.tuesday) days.Add(DayOfWeek.Tuesday.ToString());
                if ((bool)events.wednesday) days.Add(DayOfWeek.Wednesday.ToString());
                if ((bool)events.thursday) days.Add(DayOfWeek.Thursday.ToString());
                if ((bool)events.friday) days.Add(DayOfWeek.Friday.ToString());
                if ((bool)events.saturday) days.Add(DayOfWeek.Saturday.ToString());
                foreach (var day in days) {
                    if (events.typeOfEventId == 1 && day.Contains(dayOfTheWeek.ToString()) && CompareTimeSpan(events.starting_time, startingTime)) {
                        recordingService.PlayRecording(events.Recording);
                    }
                }


                if (events.typeOfEventId == 2 && events.date == date && events.starting_time == startingTime) {
                    recordingService.PlayRecording(events.Recording);
                }
            }
        }

        private bool CompareTimeSpan(TimeSpan? timespan1, TimeSpan timespan2) {
            return timespan1?.Hours == timespan2.Hours && timespan1?.Minutes == timespan2.Minutes && timespan1?.Seconds == timespan2.Seconds;
        }

    }
}