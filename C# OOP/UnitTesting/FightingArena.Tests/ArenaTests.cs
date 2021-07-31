using System;
using System.Linq;
using NUnit.Framework;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        private Warrior warrior;
        
        [SetUp]
        public void Setup()
        {
            arena = new Arena();
            warrior = new Warrior("Pesho", 5, 100);
        }

        [Test]
        public void Ctor_SuccessfullyCreateListOfWarriors()
        {
            Assert.That(arena.Count, Is.EqualTo(0));
        }

        [Test]
        public void Count_IncrementCountWhenAddWarrior()
        {
            arena.Enroll(warrior);
            
            Assert.That(arena.Count, Is.EqualTo(1));
        }

        [Test]
        public void Enroll_ThrowsExceptionIfWarriorIsAlreadyEnrolled()
        {
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(warrior);
            });
        }

        [Test]
        public void Enroll_SuccessfullyEnrollWarriorIntoTheArena()
        {
            arena.Enroll(warrior);

            Warrior enrolledWarrior = arena.Warriors.FirstOrDefault(w => w.Name == warrior.Name);
            
            Assert.That(enrolledWarrior, Is.Not.EqualTo(null));
        }

        [Test]
        public void Fight_SuccessfullyAttackTheDefender()
        {
            string attackerName = "Pesho";
            string defenderName = "Ivan";
            
            Warrior attacker = new Warrior(attackerName, 50, 100);
            Warrior defender = new Warrior(defenderName, 50, 100);

            arena.Enroll(attacker);
            arena.Enroll(defender);
            
            arena.Fight(attackerName, defenderName);
            
            Assert.That(attacker.HP, Is.EqualTo(50));
            Assert.That(defender.HP, Is.EqualTo(50));
        }

        [Test]
        public void Fight_ThrowsExceptionWhenTheAttackerIsNotInTheArena()
        {
            string defenderName = "Pesho";
            
            arena.Enroll(new Warrior(defenderName, 5, 100));
            
            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight("Ivan", defenderName);
            });
        }
        
        [Test]
        public void Fight_ThrowsExceptionWhenTheDefenderIsNotInTheArena()
        {
            string attackerName = "Ivan";
            
            arena.Enroll(new Warrior(attackerName, 5, 100));
            
            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight(attackerName, "Pesho");
            });
        }
    }
}
