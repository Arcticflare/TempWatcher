using System;
using System.Windows;
using System.Windows.Threading;
using MachineStatisticsOHM;


namespace TempWatcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer dtSecondTimer = new DispatcherTimer();
            dtSecondTimer.Interval = new TimeSpan(0,0,1);
            dtSecondTimer.Tick += new EventHandler(dtTicker);

            dtSecondTimer.Start();
        }

        
        private void dtTicker(object sender, EventArgs e)
        {
            ComputerStats cs = new ComputerStats();

            cs.GetComputerStats();

            lblCpuTemp.Content = $"{cs.CpuTemp}°C";
            lblCpuLoad.Content = $"{cs.CpuLoad}%";

            lblGpuTemp.Content = $"{cs.GpuTemp}°C";
            lblGpuLoad.Content = $"{cs.GpuLoad}%";
        }
    }
}
