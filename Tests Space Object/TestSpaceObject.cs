using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceObjects;
using System.Drawing;

namespace Tests_Space_Object
{
    [TestClass]
    public class TestSpaceObject
    {
       
        [TestMethod]
        public void TestSpaceObjectWithZeroOrbitalRadiusAtOrigio()
        {
            SpaceObject spaceObject = new SpaceObject("", 0f, 1f, 1f, 1f, Color.Black);

            Position2D position = spaceObject.GetPosition(100f);

            Assert.AreEqual(position.X, 0);
            Assert.AreEqual(position.Y, 0);
        }
    }
}