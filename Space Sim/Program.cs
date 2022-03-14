using SpaceObjects;
using System;
using System.Collections.Generic;
using System.Drawing;

class Astronomy
{
    public static void Main()
    {
        List<SpaceObject> a = new List<SpaceObject>();

        SpaceObject star = new SpaceObject("Sun", 0, 0, 695000, 1, Color.Yellow);
        SpaceObject earth = new SpaceObject("Earth", 149600, 365, 6357, 1, Color.Green);


        a.Add(star);
        a.Add(earth);
        //a.Add(new Planet("Mercury"));
        //a.Add(new Planet("Venus"));
        //a.Add(new Planet("Terra"));
        //a.Add(new Moon("The Moon"));

        foreach (SpaceObject s in a)
        {
            s.Draw();
        }

        Console.ReadLine();
    }
}

