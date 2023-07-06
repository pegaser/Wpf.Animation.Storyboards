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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf.Animation.Storyboard.Playback
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            sldSpeed.ValueChanged += SldSpeed_ValueChanged;
            fadeStoryboard.CurrentTimeInvalidated += FadeStoryboard_CurrentTimeInvalidated;
        }

        private void FadeStoryboard_CurrentTimeInvalidated(object? sender, EventArgs e)
        {
            Clock storyboardClock = (Clock)sender;
            if(storyboardClock.CurrentProgress == null)
            {
                lblProgress.Text = "[[ stopped ]]";
                prgProgress.Value = 0;
            }
            else
            {
                lblProgress.Text = storyboardClock.CurrentTime.ToString();
                prgProgress.Value = storyboardClock.CurrentProgress.Value;
            }
        }

        private void SldSpeed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            fadeStoryboard.SetSpeedRatio(sldSpeed.Value);
        }
    }
}
