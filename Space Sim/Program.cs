using SpaceObjects;
using System;
using System.Collections.Generic;
using System.Drawing;

class Astronomy
{
    public static void Main()
    {
        List<SpaceObject> a = new List<SpaceObject>();

        Moon[] mercuryMoons = {};
        Moon[] venusMoons = {};
        Moon[] earthMoon = { new Moon("Moon", 384, 27, 1738, 2332800, Color.White) };
        Moon[] marsMoons = { new Moon("Phobos", 9, 0.3f, 11267, 27540, Color.DarkGray), 
                             new Moon("Deimos", 23, 46023, 6.2f, 109080, Color.DarkGray)};
        Moon[] jupiterMoons = { new Moon("Ganymede", 1070, 42189, 2634, 617760, Color.DarkGray) };
        Moon[] saturnMoons = { new Moon("Prometheus", 139, 0.61f, 43, 0, Color.DarkGray), 
                               new Moon("Titan", 1222, 16, 2547, 1382400, Color.DarkGray)};
        Moon[] uranusMoons = { new Moon("Miranda", 130, 14977, 235, 122083, Color.DarkGray),
                               new Moon("Ariel", 191, 19025, 579, 217728, Color.DarkGray),
                               new Moon("Umbriel", 266, 41730, 585, 358041, Color.DarkGray)};
        Moon[] neptuneMoons = { new Moon("Nereid", 5513, 360, 170, 48960, Color.DarkGray)};
        Moon[] plutoMoons = { new Moon("Charon", 20, 14397, 606, 551820, Color.Purple),
                              new Moon("Nix", 49, 25, 49.8f, 158025, Color.RebeccaPurple)};

        Star sun = new Star("Sun", 0, 0, 695000, 2332800, Color.Yellow);

        Planet mercury = new Planet("Mercury", 57910, 88, 2440, 5067000, mercuryMoons, Color.Orange);
        Planet venus = new Planet("Venus", 108200, 225, 6052, 10087200, venusMoons, Color.Brown);
        Planet earth = new Planet("Earth", 149600, 365, 6357, 86400, earthMoon, Color.Green);
        Planet mars = new Planet("Mars", 227940, 687, 3389, 88620, marsMoons, Color.Red);
        Planet jupiter = new Planet("Jupiter", 778330, 4333, 69911, 35760, jupiterMoons, Color.SaddleBrown);
        Planet saturn = new Planet("Saturn", 1429400, 10760, 58232, 38520, saturnMoons, Color.Peru);
        Planet uranus = new Planet("Uranus", 2870990, 30685, 25362, 62040, uranusMoons, Color.DarkGray);
        Planet neptune = new Planet("Neptune", 4505300, 60190, 24622, 57960, neptuneMoons, Color.Blue);

        DwarfPlanet pluto = new DwarfPlanet("Pluto", 593520, 90550, 1188, 550800, plutoMoons, Color.BlueViolet);

        
        float numberOfDaysElapsed = -1f;
        while (numberOfDaysElapsed < 0f) {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("===== Number of days elapsed =====");

            numberOfDaysElapsed = int.Parse(Console.ReadLine());
            if (numberOfDaysElapsed < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Number of days can't be less than 0, try again!\n");
                Console.ResetColor();
            }
        }
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n===== Name of planet ======");
        string planet = Console.ReadLine().ToLower();
        Console.ResetColor();

        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Cyan;
        switch (planet)
        {
            case "earth":
                earth.Draw();
                Console.WriteLine($"Position @ {numberOfDaysElapsed} days elapsed = {earth.GetPosition(numberOfDaysElapsed)}");
                break;
            case "mercury":
                mercury.Draw();
                Console.WriteLine($"Position @ {numberOfDaysElapsed} days elapsed = {mercury.GetPosition(numberOfDaysElapsed)}");
                break;
            case "venus":
                venus.Draw();
                Console.WriteLine($"Position @ {numberOfDaysElapsed} days elapsed = {venus.GetPosition(numberOfDaysElapsed)}");
                break;
            case "mars":
                mars.Draw();
                Console.WriteLine($"Position @ {numberOfDaysElapsed} days elapsed = {mars.GetPosition(numberOfDaysElapsed)}");
                break;
            case "jupiter":
                jupiter.Draw();
                Console.WriteLine($"Position @ {numberOfDaysElapsed} days elapsed = {jupiter.GetPosition(numberOfDaysElapsed)}");
                break;
            case "saturn":
                saturn.Draw();
                Console.WriteLine($"Position @ {numberOfDaysElapsed} days elapsed = {saturn.GetPosition(numberOfDaysElapsed)}");
                break;
            case "uranus":
                uranus.Draw();
                Console.WriteLine($"Position @ {numberOfDaysElapsed} days elapsed = {uranus.GetPosition(numberOfDaysElapsed)}");
                break;
            case "neptune":
                neptune.Draw();
                Console.WriteLine($"Position @ {numberOfDaysElapsed} days elapsed = {neptune.GetPosition(numberOfDaysElapsed)}");
                break;
            case "pluto":
                pluto.Draw();
                Console.WriteLine($"Position @ {numberOfDaysElapsed} days elapsed = {pluto.GetPosition(numberOfDaysElapsed)}");
                break;
            default:
                sun.Draw();
                Console.WriteLine($"Position @ {numberOfDaysElapsed} days elapsed = {sun.GetPosition(numberOfDaysElapsed)}");

                Console.WriteLine($"Position of earth @ {numberOfDaysElapsed} days elapsed = {earth.GetPosition(numberOfDaysElapsed)}");
                Console.WriteLine($"Position of mercury @ {numberOfDaysElapsed} days elapsed = {mercury.GetPosition(numberOfDaysElapsed)}");
                Console.WriteLine($"Position of venus @ {numberOfDaysElapsed} days elapsed = {venus.GetPosition(numberOfDaysElapsed)}");
                Console.WriteLine($"Position of mars @ {numberOfDaysElapsed} days elapsed = {mars.GetPosition(numberOfDaysElapsed)}");
                Console.WriteLine($"Position of jupiter @ {numberOfDaysElapsed} days elapsed = {jupiter.GetPosition(numberOfDaysElapsed)}");
                Console.WriteLine($"Position of saturn @ {numberOfDaysElapsed} days elapsed = {saturn.GetPosition(numberOfDaysElapsed)}");
                Console.WriteLine($"Position of uranus @ {numberOfDaysElapsed} days elapsed = {uranus.GetPosition(numberOfDaysElapsed)}");
                Console.WriteLine($"Position of neptune @ {numberOfDaysElapsed} days elapsed = {neptune.GetPosition(numberOfDaysElapsed)}");
                break;
        }
        Console.ResetColor();
    }
}

