using System;
using System.Threading.Tasks;
using System.Windows;

namespace Zvonko
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //StartPeriodicTask();
        }

        public void StartPeriodicTask() {
            Task.Run(async () => {
                while (true) {
                    await Task.Delay(600);
                    // Ensure the MessageBox is shown on the UI thread
                    Application.Current.Dispatcher.Invoke(() => {
                        MessageBox.Show("Second has passed");
                        //PlayEvent();
                    });
                }
            });
        }
    }
}
