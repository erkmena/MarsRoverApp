using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRoverApp.Model.Implementations;
using MarsRoverApp.Model;

namespace RoverUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Plateau plateau = new Plateau(1, 1);
            RoboticRover robotic = new RoboticRover('N',plateau);
            Console.ReadLine();

        }
    }
}
