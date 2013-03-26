using System;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace Mode13h.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer _timer = new DispatcherTimer();
        private readonly Thread _demoThread;
        private readonly MainViewModel _viewModel;
        
        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainViewModel();
            DataContext = _viewModel;

            _demoThread = new Thread(RunDemo);
            _demoThread.IsBackground = false;
            _demoThread.Name = "Demo Runner";

            _timer.Interval = TimeSpan.FromMilliseconds(40);
            _timer.Tick += _timer_Tick;
        }

        private void RunDemo(object state)
        {
            //new Demos.RotoZoomer(_viewModel).Run();
            new Demos.Plasma(_viewModel).Run();
        }

        private void _timer_Tick(object sender, System.EventArgs e)
        {
            _viewModel.Draw();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            _demoThread.Start();
            _timer.Start();
        }
        
        private void Window_Closed_1(object sender, EventArgs e)
        {
            _viewModel.Quit();
            _timer.Stop();
        }
    }
}
