using NUnit.Framework;

namespace Robots.Tests
{
    using System;
    public class RobotsTests
    {
        [SetUp]
        public void Setup()
        {
            
        }
        
        [Test]
        public void Capacity_ThrowsExceptionWhenLessThanZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                RobotManager manager = new RobotManager(-5);
            });
        }
        
        [Test]
        public void Capacity_WorksCorrectlyWhenMoreThanZero()
        {
            int capacity = 10;
            RobotManager manager = new RobotManager(capacity);
            
            Assert.That(manager.Capacity, Is.EqualTo(capacity));
        }
        
        [Test]
        public void Count_WorksCorrectlyWhenRobotIsAdded()
        {
            RobotManager manager = new RobotManager(10);

            manager.Add(new Robot("pesho", 100));
            
            Assert.That(manager.Count, Is.EqualTo(1));
        }
        
        [Test]
        public void Add_ThrowsExceptionWhenRobotNameAlreadyExists()
        {
            RobotManager manager = new RobotManager(10);

            string robotName = "Pesho";
            
            manager.Add(new Robot(robotName, 2));
            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Add(new Robot(robotName, 3));
            });
        }
        
        [Test]
        public void Add_ThrowsExceptionWhenTryToAddMoreRobotsThanCapacity()
        {
            RobotManager manager = new RobotManager(1);
            
            
            manager.Add(new Robot("Pesho", 2));
            
            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Add(new Robot("Gosho", 3));
            });
        }
        
        [Test]
        public void Add_SuccessfullyAddsTheRobot()
        {
            RobotManager manager = new RobotManager(1);
            Robot robot = new Robot("Pesho", 10);
            
            manager.Add(robot);
            
            Assert.That(manager.Count, Is.EqualTo(1));
        }
        
        [Test]
        public void Remove_ThrowsExceptionWhenRobotWithThatNameDoesNotExists()
        {
            RobotManager manager = new RobotManager(1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Remove("pesho");
            });
        }        
        
        [Test]
        public void Remove_SuccessfullyRemovesTheRobot()
        {
            RobotManager manager = new RobotManager(1);

            string robotName = "Pesho";
            Robot robot = new Robot(robotName, 10);
            manager.Add(robot);
            
            Assert.That(manager.Count, Is.EqualTo(1));
            
            manager.Remove(robotName);
            
            Assert.That(manager.Count, Is.EqualTo(0));
        }
        
        [Test]
        public void Work_ThrowsExceptionWhenRobotWithGivenNameDoesNotExist()
        {
            RobotManager manager = new RobotManager(1);
            
            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Work("Pesho", "test", 10);
            });
        }
        
        [Test]
        public void Work_ThrowsExceptionWhenRobotDoesNotHaveEnoughBattery()
        {
            RobotManager manager = new RobotManager(1);

            string robotName = "Ivan";
            
            manager.Add(new Robot(robotName, 100));

            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Work(robotName, "test", 101);
            });
        }
        
        [Test]
        public void Work_ReduceRobotBatterySuccessfully()
        {
            RobotManager manager = new RobotManager(1);

            string robotName = "Ivan";
            
            Robot robot = new Robot(robotName, 100);
            
            manager.Add(robot);

            manager.Work(robotName, "test", 50);
            
            Assert.That(robot.Battery, Is.EqualTo(50));
        }
        
        [Test]
        public void Charge_ThrowsExceptionWhenRobotDoesNotExist()
        {
            RobotManager manager = new RobotManager(1);
            
            manager.Add(new Robot("Gosho", 100));
            
            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Charge("Ivan");
            });
        }

        [Test]
        public void Charge_ChargesBatteryToMaximumSuccessfully()
        {
            RobotManager manager = new RobotManager(1);

            string robotName = "Gosho";
            Robot robot = new Robot(robotName, 100);
            
            manager.Add(robot);
            
            manager.Work(robotName, "test", 50);
            
            Assert.That(robot.Battery, Is.EqualTo(50));

            manager.Charge(robotName);
            
            Assert.That(robot.Battery, Is.EqualTo(100));
        }
        
    }
}
