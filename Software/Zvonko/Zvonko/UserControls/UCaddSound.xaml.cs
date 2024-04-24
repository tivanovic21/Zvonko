using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Zvonko.UserControls
{
    /// <summary>
    /// Interaction logic for UCaddSound.xaml
    /// </summary>
    public partial class UCaddSound : UserControl
    {
        public UCaddSound()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null && parentWindow is MainWindow)
            {
                MainWindow mainWindow = (MainWindow)parentWindow;
                mainWindow.LoadMainContent();
            }
        }
    }
}
