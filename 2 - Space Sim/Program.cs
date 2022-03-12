using SpaceSim;
using System;
using System.Collections.Generic;

class Astronomy
{
    public static void Main()
    {
        List<SpaceObject> a = new List<SpaceObject>();

        a.Add(new Star("Sun"));
        a.Add(new Planet("Mercury"));
        a.Add(new Planet("Venus"));
        a.Add(new Planet("Terra"));
        a.Add(new Moon("The Moon"));

        foreach (SpaceObject s in a)
        {
            s.Draw();
        }

        Console.ReadLine();
    }
}

