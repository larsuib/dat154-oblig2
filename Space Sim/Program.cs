using SpaceObjects;
using System;
using System.Collections.Generic;
using System.Drawing;

class Astronomy
{
    public static void Main()
    {
        List<SpaceObject> a = new List<SpaceObject>();

        Star star = new Star("Sun", 0, 0, 695000, 1, Color.Yellow);
        Planet mercury = new Planet("Mercury", 57910, 88, 2440, 1, Color.Orange);
        Planet venus = new Planet("Venus", 108200, 225, 6052, 1, Color.Brown);
        Planet earth = new Planet("Earth", 149600, 365, 6357, 1, Color.Green);
        Planet mars = new Planet("Mars", 227940, 687, 3389, 1, Color.Red);
        Planet jupiter = new Planet("Jupiter", 778330, 4333, 69911, 1, Color.SaddleBrown);
        Planet saturn = new Planet("Saturn", 1429400, 10760, 58232, 1, Color.Peru);
        Planet uranus = new Planet("Uranus", 2870990, 30685, 25362, 1, Color.DarkGray);
        Planet neptune = new Planet("Neptune", 4505300, 60190, 24622, 1, Color.Blue);
        DwarfPlanet pluto = new DwarfPlanet("Pluto", 593520, 90550, 1188, 1, Color.BlueViolet);


        

        Console.ReadLine();
    }
}

