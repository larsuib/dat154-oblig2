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
        Planet earth = new Planet("Earth", 149600, 365, 6357, 1, Color.Green);
        //Planet merucry = new Planet("Mercury", )

        a.Add(star);
        a.Add(earth);
        //a.Add(new Planet("Mercury"));
        //a.Add(new Planet("Venus"));
        //a.Add(new Planet("Terra"));
        //a.Add(new Moon("The Moon"));

        //Mercury
        //Venus
        //Earth
        //Mars
        //Jupiter
        //Saturn
        //Uranus
        //Neptune
        //Pluto

        Console.WriteLine(earth.GetPosition(150));

        Console.ReadLine();
    }
}

