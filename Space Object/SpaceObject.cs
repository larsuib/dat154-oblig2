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
    }
    
    public class SpaceObject
    {

        protected String name;
        protected float OrbitalRadius { get; set; }
        protected float OrbitalPeriod { get; set; }
        protected float ObjectRadius { get; set; }
        protected float RotationalPeriod { get; set; }
        protected Color ObjectColor { get; set; }


        public SpaceObject(String _name)
        {
            name = _name;
        }
        public virtual void Draw()
        {
            Console.WriteLine(name);
        }

        public Position2D GetPosition(float time)
        {
            throw new NotImplementedException();
        }
    }

    public class Star : SpaceObject
    {
        public Star(String _name) : base(_name) { }
        public override void Draw()
        {
            Console.Write("Star  : ");
            base.Draw();
        }
    }

    public class Planet : SpaceObject
    {
        public Planet(String _name) : base(_name) { }
        public override void Draw()
        {
            Console.Write("Planet : ");
            base.Draw();
        }
    }

    public class Moon : SpaceObject
    {
        public Moon(String _name) : base(_name) { }

        public override void Draw()
        {
            Console.Write("Moon  : ");
            base.Draw();
        }
    }

    // omets, asteroids, asteroid belts, and dwarf 
    // planets.Make sure each of these new objects inherits correctly.
    public class Comet : SpaceObject
    {
        public Comet(String _name) : base(_name) { }

        public override void Draw()
        {
            Console.Write("Comet : ");
            base.Draw();
        }
    }

    public class Asteroid : SpaceObject
    {
        public Asteroid(String _name) : base(_name) { }

        public override void Draw()
        {
            Console.Write("Asteroid : ");
            base.Draw();
        }
    }

    public class AsteroidBelt : SpaceObject
    {
        public Asteroid[] Asteroids { get; set; }

        public AsteroidBelt(String _name) : base(_name) { }
        public AsteroidBelt(String _name, Asteroid[] _asteroids) : base(_name)
        {
            Asteroids = _asteroids;
        }

        public override void Draw()
        {
            Console.Write("AsteroidBelt : ");
            base.Draw();
        }
    }

    public class DwarfPlanet : Planet
    {
        public DwarfPlanet(String _name) : base(_name) { }

        public override void Draw()
        {
            Console.Write("DwarfPlanet : ");
            base.Draw();
        }
    }
}

