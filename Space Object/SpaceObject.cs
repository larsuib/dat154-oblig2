using System;
using System.Drawing;

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

    public class SpaceObject
    {

        protected String name;
        protected float OrbitalRadius { get; set; }
        protected float OrbitalPeriod { get; set; }
        protected float ObjectRadius { get; set; }
        protected float RotationalPeriod { get; set; }
        protected Color ObjectColor { get; set; }


        public SpaceObject
            (String _name, float _orbitalRadius, float _orbitalPeriod, float _objectRadius, float _rotationalPeriod, Color _objectColor)
        {
            name = _name;
            OrbitalRadius = _orbitalRadius;
            OrbitalPeriod = _orbitalPeriod;
            ObjectRadius = _objectRadius;
            RotationalPeriod = _rotationalPeriod;
            ObjectColor = _objectColor;
        }
        public virtual void Draw()
        {
            Console.WriteLine(name);
        }

        public Position2D GetPosition(float time)
        {
            time %= OrbitalPeriod;

            float radians = ((time / OrbitalPeriod) * (2f * (float) Math.PI)); // Tall mellom 0 og 1

            float X = OrbitalRadius + (OrbitalRadius * (float) Math.Cos(radians));
            float Y = OrbitalRadius + (OrbitalRadius * (float) Math.Sin(radians));

            return new Position2D(X, Y);
        }
    }

    public class Star : SpaceObject
    {
        public Star(String _name, float _orbitalRadius, float _orbitalPeriod, float _objectRadius, float _rotationalPeriod, Color _objectColor)
            : base(_name, _orbitalRadius, _orbitalPeriod, _objectRadius, _rotationalPeriod, _objectColor) { }
        public override void Draw()
        {
            Console.Write("Star  : ");
            base.Draw();
        }
    }

    public class Planet : SpaceObject
    {
        public Moon[] Moons;

        public Planet(String _name, float _orbitalRadius, float _orbitalPeriod, float _objectRadius, float _rotationalPeriod, Moon[] _moons, Color _objectColor)
            : base(_name, _orbitalRadius, _orbitalPeriod, _objectRadius, _rotationalPeriod, _objectColor)
        {
            Moons = _moons;
        }
        public override void Draw()
        {
            Console.Write("Planet : ");
            base.Draw();

            foreach (var moon in Moons)
                moon.Draw();
        }
    }

    public class Moon : SpaceObject
    {
        public Moon(String _name, float _orbitalRadius, float _orbitalPeriod, float _objectRadius, float _rotationalPeriod, Color _objectColor)
            : base(_name, _orbitalRadius, _orbitalPeriod, _objectRadius, _rotationalPeriod, _objectColor) { }

        public override void Draw()
        {
            Console.Write("Moon  : ");
            base.Draw();
        }
    }

    public class Comet : SpaceObject
    {
        public Comet(String _name, float _orbitalRadius, float _orbitalPeriod, float _objectRadius, float _rotationalPeriod, Color _objectColor)
            : base(_name, _orbitalRadius, _orbitalPeriod, _objectRadius, _rotationalPeriod, _objectColor) { }

        public override void Draw()
        {
            Console.Write("Comet : ");
            base.Draw();
        }
    }

    public class Asteroid : SpaceObject
    {
        public Asteroid(String _name, float _orbitalRadius, float _orbitalPeriod, float _objectRadius, float _rotationalPeriod, Color _objectColor)
            : base(_name, _orbitalRadius, _orbitalPeriod, _objectRadius, _rotationalPeriod, _objectColor) { }

        public override void Draw()
        {
            Console.Write("Asteroid : ");
            base.Draw();
        }
    }

    public class AsteroidBelt : SpaceObject
    {
        public Asteroid[] Asteroids { get; set; }

        public AsteroidBelt(String _name, float _orbitalRadius, float _orbitalPeriod, float _objectRadius, float _rotationalPeriod, Color _objectColor, Asteroid[] _asteroids)
            : base(_name, _orbitalRadius, _orbitalPeriod, _objectRadius, _rotationalPeriod, _objectColor)
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
        public DwarfPlanet(String _name, float _orbitalRadius, float _orbitalPeriod, float _objectRadius, float _rotationalPeriod, Moon[] _moons, Color _objectColor)
            : base(_name, _orbitalRadius, _orbitalPeriod, _objectRadius, _rotationalPeriod, _objectColor)
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

