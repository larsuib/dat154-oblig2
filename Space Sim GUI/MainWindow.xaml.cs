using SpaceObjects;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Windows.Input;

namespace Space_Sim_GUI
{
    public partial class MainWindow : Window
    {
        private const int NANOS_IN_HUNDREDS_PER_TICK = 10000;  // 10000 = 1 ms
        private const double SIMULATION_SPEED = 0.5d;

        private double _timeElapsedInDays = 0;
        private DispatcherTimer _dispatchTimer;
        private event Action<double> UpdatePosition;

        private int TextBlockToggle = 0;

        #region SpaceObjects
        private Star sun;
        private Planet earth, saturn, mercury, venus, mars, jupiter, uranus, neptune;
        private DwarfPlanet pluto;
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            
            #region SpaceObject Init
            sun = new Star("Sun", 0, 0, 695000, 2332800);
            Moon[] earthMoons = { new Moon("Moon", 384, 27, 1738, 2332800) };
            earth = new Planet("Earth", 149600, 365, 6357, 86400, earthMoons);
            saturn = new Planet("Saturn", 1429400, 10760, 58232, 38520, new Moon[] {});
            mercury = new Planet("Mercury", 57910, 88, 2440, 5067000, new Moon[] {});
            venus = new Planet("Venus", 108200, 225, 6052, 10087200, new Moon[] { });
            mars = new Planet("Mars", 227940, 687, 3389, 88620, new Moon[] { });
            jupiter = new Planet("Jupiter", 778330, 4333, 69911, 35760, new Moon[] { });
            uranus = new Planet("Uranus", 2870990, 30685, 25362, 62040, new Moon[] { });
            neptune = new Planet("Neptune", 4505300, 60190, 24622, 57960, new Moon[] { });
            pluto = new DwarfPlanet("Pluto", 593520, 90550, 1188, 550800, new Moon[] { });
            #endregion

            #region SpaceObject UpdatePositionEvent
            UpdatePosition += sun.UpdatePositionWithScaling;
            UpdatePosition += earth.UpdatePositionWithScaling;
            UpdatePosition += saturn.UpdatePositionWithScaling;
            UpdatePosition += mercury.UpdatePositionWithScaling;
            UpdatePosition += venus.UpdatePositionWithScaling;
            UpdatePosition += mars.UpdatePositionWithScaling;
            UpdatePosition += jupiter.UpdatePositionWithScaling;
            UpdatePosition += uranus.UpdatePositionWithScaling;
            UpdatePosition += neptune.UpdatePositionWithScaling;
            UpdatePosition += saturn.UpdatePositionWithScaling;
            UpdatePosition += pluto.UpdatePositionWithScaling;
            #endregion

            // Add simulation-loop
            _dispatchTimer = new DispatcherTimer
            {
                Interval = new TimeSpan(NANOS_IN_HUNDREDS_PER_TICK),
            };
            _dispatchTimer.Tick += tick;
            _dispatchTimer.Start();

            this.KeyDown += ToggleTextBlocks;
            
        }

        private void tick(object sender, EventArgs eventArgs)
        {
            _timeElapsedInDays += SIMULATION_SPEED;

            DaysPassedLabel.Content =  $"Days passed: {_timeElapsedInDays}";
            TimeSpeed.Content =        $"Speed:  {SIMULATION_SPEED} day(s)/tick";
            EarthCoordinates.Content = $"Earth:  ({Math.Round(earth.X, 0)}, {Math.Round(earth.Y, 0)})";

            UpdatePosition(_timeElapsedInDays);
            RedrawPlanets();
        }

        private void RedrawPlanets()
        {
            var centerX = (double) Space.RenderSize.Width / 2;
            var centerY = (double) Space.RenderSize.Height / 2;

            SetGridPositionFromObject(Ellipse_Sun, sun, centerX, centerY);
            SetGridPositionFromObject(Ellipse_Earth, earth, centerX, centerY);
            SetGridPositionFromObject(Ellipse_Saturn, saturn, centerX, centerY);
            SetGridPositionFromObject(Ellipse_Mercury, mercury, centerX, centerY);
            SetGridPositionFromObject(Ellipse_Venus, venus, centerX, centerY);
            SetGridPositionFromObject(Ellipse_Mars, mars, centerX, centerY);
            SetGridPositionFromObject(Ellipse_Jupiter, jupiter, centerX, centerY);
            SetGridPositionFromObject(Ellipse_Uranus, uranus, centerX, centerY);
            SetGridPositionFromObject(Ellipse_Neptune, neptune, centerX, centerY);
            SetGridPositionFromObject(Ellipse_Pluto, pluto, centerX, centerY);
        }

        private void SetGridPositionFromObject(Grid ellipseObject, SpaceObject spaceObject, double centerX, double centerY)
        {
            // Size scaling
            ellipseObject.Width = SizeScaling(spaceObject);
            ellipseObject.Height = SizeScaling(spaceObject);

            Canvas.SetLeft(ellipseObject, centerX - ellipseObject.Width / 2 + spaceObject.X);
            Canvas.SetTop(ellipseObject, centerY - ellipseObject.Height / 2 + spaceObject.Y);
        }
        private double SizeScaling(SpaceObject spaceObject)
        {
            if (spaceObject.ObjectRadius == 0)
                return 0;
            return (double) Math.Log(spaceObject.ObjectRadius, 1.22);
        }

        private void ToggleTextBlocks(Object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {

                if (TextBlockToggle == 0)
                {
                    SunTb.Visibility = Visibility.Visible;
                    VenusTb.Visibility = Visibility.Visible;
                    MercuryTb.Visibility = Visibility.Visible;
                    EarthTb.Visibility = Visibility.Visible;
                    MarsTb.Visibility = Visibility.Visible;
                    JupiterTb.Visibility = Visibility.Visible;
                    SaturnTb.Visibility = Visibility.Visible;
                    NeptuneTb.Visibility = Visibility.Visible;
                    UranusTb.Visibility = Visibility.Visible;
                    PlutoTb.Visibility = Visibility.Visible;
                    TextBlockToggle = 1;
                }
                else
                {
                    SunTb.Visibility = Visibility.Hidden;
                    VenusTb.Visibility = Visibility.Hidden;
                    MercuryTb.Visibility = Visibility.Hidden;
                    EarthTb.Visibility = Visibility.Hidden;
                    MarsTb.Visibility = Visibility.Hidden;
                    JupiterTb.Visibility = Visibility.Hidden;
                    SaturnTb.Visibility = Visibility.Hidden;
                    NeptuneTb.Visibility = Visibility.Hidden;
                    UranusTb.Visibility = Visibility.Hidden;
                    PlutoTb.Visibility = Visibility.Hidden;
                    TextBlockToggle = 0;
                }

            }
        }
    }
}
