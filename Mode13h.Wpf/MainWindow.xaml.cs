using System;
using System.Windows;
using System.Windows.Threading;

namespace Mode13h.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer _timer = new DispatcherTimer();
        private MainViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainViewModel();
            DataContext = _viewModel;

            _timer.Interval = TimeSpan.FromMilliseconds(40);
            _timer.Tick += _timer_Tick;
        }

        private void _timer_Tick(object sender, System.EventArgs e)
        {
            _viewModel.Draw();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            _timer.Start();
        }

        private void Window_Unloaded_1(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
        }
    }
}
