using SpaceObjects;
using System;
using System.Collections.Generic;
using System.Drawing;

class Astronomy
{
    public static void Main()
    {
        List<SpaceObject> a = new List<SpaceObject>();

        Moon[] mercuryMoon = { };
        Moon[] venusMoon = { };
        Moon[] earthMoon = { new Moon("Moon", 384, 27, 1738, 1, Color.White) };
        Moon[] marsMoons = { new Moon("Phobos", 9, 0.3f, 11267, 1, Color.DarkGray), 
                             new Moon("Deimos", 23, 46023, 6.2f, 1, Color.DarkGray)};
        Moon[] jupiterMoons = { new Moon("Ganymede", 1070, 42189, 2634, 1, Color.DarkGray) };
        Moon[] saturnMoons = { new Moon("Prometheus", 139, 0.61f, 43, 1, Color.DarkGray), 
                               new Moon("Titan", 1222, 16, 2547, 1, Color.DarkGray)};
        Moon[] uranusMoons = { new Moon("Miranda", 130, 14977, 235, 1, Color.DarkGray),
                               new Moon("Ariel", 191, 19025, 579, 1, Color.DarkGray),
                               new Moon("Umbriel", 266, 41730, 585, 1, Color.DarkGray)};
        Moon[] neptuneMoons = { new Moon("Nereid", 5513, 360, 170, 1, Color.DarkGray)};
        Moon[] plutoMoons = { new Moon("Charon", 20, 14397, 606, 1, Color.Purple),
                              new Moon("Nix", 49, 25, 49.8f, 1, Color.RebeccaPurple)};

        Star star = new Star("Sun", 0, 0, 695000, 1, Color.Yellow);
        Planet mercury = new Planet("Mercury", 57910, 88, 2440, 1, mercuryMoon, Color.Orange);
        Planet venus = new Planet("Venus", 108200, 225, 6052, 1, venusMoon, Color.Brown);
        Planet earth = new Planet("Earth", 149600, 365, 6357, 1, earthMoon, Color.Green);
        Planet mars = new Planet("Mars", 227940, 687, 3389, 1, marsMoons, Color.Red);
        Planet jupiter = new Planet("Jupiter", 778330, 4333, 69911, 1, jupiterMoons, Color.SaddleBrown);
        Planet saturn = new Planet("Saturn", 1429400, 10760, 58232, 1, saturnMoons, Color.Peru);
        Planet uranus = new Planet("Uranus", 2870990, 30685, 25362, 1, uranusMoons, Color.DarkGray);
        Planet neptune = new Planet("Neptune", 4505300, 60190, 24622, 1, neptuneMoons, Color.Blue);
        DwarfPlanet pluto = new DwarfPlanet("Pluto", 593520, 90550, 1188, 1, plutoMoons, Color.BlueViolet);

        Console.WriteLine("Number of days elapsed:");
        float numberOfDaysElapsed = int.Parse(Console.ReadLine());

        Console.WriteLine("Name of the spaceobject:");
        string spaceObject = Console.ReadLine();
    }
}

