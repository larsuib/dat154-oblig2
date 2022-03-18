using SpaceObjects;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Threading;

namespace Space_Sim_GUI
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private const int NANOS_IN_HUNDREDS_PER_TICK = 10000;  // 10000 = 1 ms
        
        private float _timeElapsedInDays = 0;
        private DispatcherTimer _dispatchTimer;
        private event Action<float> UpdatePostition;

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string memberName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }

        #region SpaceObjects
        private Star _sun;
        public Star Sun
        {
            get => _sun;
            set { _sun = value; OnPropertyChanged(); }
        }

        private Planet _earth;
        public Planet Earth
        {
            get => _earth;
            set { _earth = value; OnPropertyChanged(); }
        }
        #endregion

        public MainWindow()
        {
            InitializeComponent();

            setupPlanets();
            UpdatePostition += Sun.UpdatePosition;
            UpdatePostition += Earth.UpdatePosition;

            _dispatchTimer = new DispatcherTimer
            {
                Interval = new TimeSpan(NANOS_IN_HUNDREDS_PER_TICK),
            };
            _dispatchTimer.Tick += Tick;
            _dispatchTimer.Start();
        }

        private void setupPlanets()
        {
            Sun = new Star("Sun", 0, 0, 695000, 1, Color.Yellow);
            Earth = new Planet("Earth", 149600, 365, 6357, 1, new Moon[] { }, Color.Green);
        }

        private void Tick(object sender, EventArgs eventArgs)
        {
            Trace.WriteLine(Earth.X);
            _timeElapsedInDays += 1;
            UpdatePostition(_timeElapsedInDays);
        }
    }
}
