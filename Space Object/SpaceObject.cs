using System;
using System.Diagnostics;

namespace SpaceObjects
{

    public class Position2D
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Position2D(double _x, double _y)
        {
            X = _x;
            Y = _y;
        }
        public override string ToString()
        {
            return "("+X+", "+Y+")";
        }
    }

    public class SpaceObject
    {
        protected string name;
        public double X { get; set; }
        public double Y { get; set; }
        public double OrbitalRadius { get; set; }
        public double OrbitalPeriod { get; set; }
        public double ObjectRadius { get; set; }
        public double RotationalPeriod { get; set; }

        public SpaceObject
            (string _name, double _orbitalRadius, double _orbitalPeriod, double _objectRadius, double _rotationalPeriod)
        {
            name = _name;
            OrbitalRadius = _orbitalRadius;
            OrbitalPeriod = _orbitalPeriod;
            ObjectRadius = _objectRadius;
            RotationalPeriod = _rotationalPeriod;
        }
        public virtual void Draw()
        {
            Console.WriteLine(name);
        }

        public void UpdatePositionWithScaling(double time)
        {
            Position2D pos = GetPosition(time);

            if (name.Equals("Sun"))
            {
                X = pos.X;
                Y = pos.Y;
                return;
            }

            // Applying scaling
            // Procedure gathered from following link:
            // https://gamedev.stackexchange.com/a/104709
            // (Gathered 18.03.2022)

            // The conversion itself uses procedures found here:
            // https://www.mathsisfun.com/polar-cartesian-coordinates.html
            // (gathered 18.03.2022)
            (double, double) polarCoordinates = (
                Math.Sqrt(Math.Pow(pos.X, 2) + Math.Pow(pos.Y, 2)),
                Math.Atan(pos.Y / pos.X)
            );

            // Applying scaling
            ScaleDistance(ref polarCoordinates.Item1);

            // Converting back to cartesian
            (double, double) scaledCartesianCoordinates = (
                polarCoordinates.Item1 * Math.Cos(polarCoordinates.Item2),
                polarCoordinates.Item1 * Math.Sin(polarCoordinates.Item2)
            );

            X = scaledCartesianCoordinates.Item1;
            Y = scaledCartesianCoordinates.Item2;

            // Magic
            if (pos.X < 0)
            {
                X *= -1;
                Y *= -1;
            }
        }

        private void ScaleDistance(ref double polarDistance)
        {
            polarDistance = Math.Log(polarDistance, 1.04);
        }

        public Position2D GetPosition(double time)
        {
            if (OrbitalRadius == 0)
                return new Position2D(0f, 0f);  // 0 in radius -> Origo of the simulation

            time %= OrbitalPeriod;

            double normalizedAngle = time / OrbitalPeriod;
            double radians = normalizedAngle * (2*Math.PI); // Tall mellom 0 og 2*PI

            double x = OrbitalRadius * Math.Cos(radians);
            double y = OrbitalRadius * Math.Sin(radians);

            return new Position2D(x, y);
        }
    }

    public class Star : SpaceObject
    {
        public Star(string _name, double _orbitalRadius, double _orbitalPeriod, double _objectRadius, double _rotationalPeriod)
            : base(_name, _orbitalRadius, _orbitalPeriod, _objectRadius, _rotationalPeriod) { }
        public override void Draw()
        {
            Console.Write("Star  : ");
            base.Draw();
        }
    }

    public class Planet : SpaceObject
    {
        public Moon[] Moons { get; set; }

        public Planet(string _name, double _orbitalRadius, double _orbitalPeriod, double _objectRadius, double _rotationalPeriod, Moon[] _moons)
            : base(_name, _orbitalRadius, _orbitalPeriod, _objectRadius, _rotationalPeriod)
        {
            Moons = _moons;
        }
        public override void Draw()
        {
            Console.Write("Planet : ");
            base.Draw();

            Console.WriteLine("Moons:");
            foreach (var moon in Moons)
                moon.Draw();
        }

        
    }

    public class Moon : SpaceObject
    {
        public Moon(string _name, double _orbitalRadius, double _orbitalPeriod, double _objectRadius, double _rotationalPeriod)
            : base(_name, _orbitalRadius, _orbitalPeriod, _objectRadius, _rotationalPeriod) { }

        public override void Draw()
        {
            Console.Write("Moon : ");
            base.Draw();
        }
    }

    public class Comet : SpaceObject
    {
        public Comet(string _name, double _orbitalRadius, double _orbitalPeriod, double _objectRadius, double _rotationalPeriod)
            : base(_name, _orbitalRadius, _orbitalPeriod, _objectRadius, _rotationalPeriod) { }

        public override void Draw()
        {
            Console.Write("Comet : ");
            base.Draw();
        }
    }

    public class Asteroid : SpaceObject
    {
        public Asteroid(string _name, double _orbitalRadius, double _orbitalPeriod, double _objectRadius, double _rotationalPeriod)
            : base(_name, _orbitalRadius, _orbitalPeriod, _objectRadius, _rotationalPeriod) { }

        public override void Draw()
        {
            Console.Write("Asteroid : ");
            base.Draw();
        }
    }

    public class AsteroidBelt : SpaceObject
    {
        public Asteroid[] Asteroids { get; set; }

        public AsteroidBelt(string _name, double _orbitalRadius, double _orbitalPeriod, double _objectRadius, double _rotationalPeriod, Asteroid[] _asteroids)
            : base(_name, _orbitalRadius, _orbitalPeriod, _objectRadius, _rotationalPeriod)
        {
            Asteroids = _asteroids;
        }


        public override void Draw()
        {
            Console.Write("AsteroidBelt : ");
            base.Draw();
        }
    }

    public class DwarfPlanet : SpaceObject
    {
        public Moon[] Moons;
        public DwarfPlanet(string _name, double _orbitalRadius, double _orbitalPeriod, double _objectRadius, double _rotationalPeriod, Moon[] _moons)
            : base(_name, _orbitalRadius, _orbitalPeriod, _objectRadius, _rotationalPeriod)
        {
            Moons = _moons;
        }

        public override void Draw()
        {
            Console.Write("DwarfPlanet : ");
            base.Draw();
        }
    }
}

