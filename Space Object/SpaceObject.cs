using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace SpaceObjects
{

    public class Position2D
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Position2D(float _x, float _y)
        {
            X = _x;
            Y = _y;
        }
        public override string ToString()
        {
            return "("+X+", "+Y+")";
        }
    }

    public class SpaceObject : INotifyPropertyChanged
    {

        protected String name;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string memberName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }

        private float _x { get; set; }
        public float X
        {
            get => _x / 1000;
            set
            {
                _x = value;
                OnPropertyChanged();
            }
        }

        private float _y { get; set; }
        public float Y
        {
            get => _y / 1000;
            set
            {
                _y = value;
                OnPropertyChanged();
            }
        }
        protected float OrbitalRadius { get; set; }
        protected float OrbitalPeriod { get; set; }
        protected float ObjectRadius { get; set; }
        protected float RotationalPeriod { get; set; }

        public SpaceObject
            (String _name, float _orbitalRadius, float _orbitalPeriod, float _objectRadius, float _rotationalPeriod)
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

        public void UpdatePosition(float time)
        {
            Position2D currentPosition = GetPosition(time);
            X = currentPosition.X;
            Y = currentPosition.Y;
        }

        public Position2D GetPosition(float time)
        {
            if (OrbitalRadius == 0)
                return new Position2D(0f, 0f);  // 0 in radius -> Origo of the simulation

            time %= OrbitalPeriod;

            float radians = (time / OrbitalPeriod) * (2f * (float) Math.PI); // Tall mellom 0 og 1

            X = OrbitalRadius * (float) Math.Cos(radians);
            Y = OrbitalRadius * (float) Math.Sin(radians);

            return new Position2D(X, Y);
        }
    }

    public class Star : SpaceObject
    {
        public Star(String _name, float _orbitalRadius, float _orbitalPeriod, float _objectRadius, float _rotationalPeriod)
            : base(_name, _orbitalRadius, _orbitalPeriod, _objectRadius, _rotationalPeriod) { }
        public override void Draw()
        {
            Console.Write("Star  : ");
            base.Draw();
        }
    }

    public class Planet : SpaceObject
    {
        public Moon[] Moons;

        public Planet(String _name, float _orbitalRadius, float _orbitalPeriod, float _objectRadius, float _rotationalPeriod, Moon[] _moons)
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
        public Moon(String _name, float _orbitalRadius, float _orbitalPeriod, float _objectRadius, float _rotationalPeriod)
            : base(_name, _orbitalRadius, _orbitalPeriod, _objectRadius, _rotationalPeriod) { }

        public override void Draw()
        {
            Console.Write("Moon : ");
            base.Draw();
        }
    }

    public class Comet : SpaceObject
    {
        public Comet(String _name, float _orbitalRadius, float _orbitalPeriod, float _objectRadius, float _rotationalPeriod)
            : base(_name, _orbitalRadius, _orbitalPeriod, _objectRadius, _rotationalPeriod) { }

        public override void Draw()
        {
            Console.Write("Comet : ");
            base.Draw();
        }
    }

    public class Asteroid : SpaceObject
    {
        public Asteroid(String _name, float _orbitalRadius, float _orbitalPeriod, float _objectRadius, float _rotationalPeriod)
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

        public AsteroidBelt(String _name, float _orbitalRadius, float _orbitalPeriod, float _objectRadius, float _rotationalPeriod, Asteroid[] _asteroids)
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
        public DwarfPlanet(String _name, float _orbitalRadius, float _orbitalPeriod, float _objectRadius, float _rotationalPeriod, Moon[] _moons)
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

