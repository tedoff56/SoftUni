using System;
using NUnit.Framework;

namespace Tests
{
    public class WarriorTests
    {
        private const int MIN_ATTACK_HP = 30;
        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
            warrior = new Warrior("Pesho", 5, 100);
        }

        [Test]
        public void Ctor_ThrowsExceptionWithNullName()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior(null, 5, 100);
            });
        }
        
        [Test]
        public void Ctor_ThrowsExceptionWithEmptyName()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior("", 5, 100);
            });
        }
        
        [Test]
        public void Ctor_ThrowsExceptionWithWhiteSpaceName()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior(" ", 5, 100);
            });
        }
        
        [Test]
        public void Ctor_ThrowsExceptionWithNegativeDamage()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior("Pesho", -1, 100);
            });
        }
        
        [Test]
        public void Ctor_ThrowsExceptionWithZeroDamage()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior("Pesho", 0, 100);
            });
        }
        
        [Test]
        public void Ctor_ThrowsExceptionWithNegativeHp()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior("Pesho", 5, -1);
            });
        }

        [Test]
        public void Ctor_SuccessfullyCreateWarrior()
        {
            string name = "Pesho";
            int damage = 5;
            int hp = 100;

            warrior = new Warrior(name, damage, hp);
            
            Assert.That(warrior.Name, Is.EqualTo(name));
            Assert.That(warrior.Damage, Is.EqualTo(damage));
            Assert.That(warrior.HP, Is.EqualTo(hp));
        }

        [Test]
        [TestCase(MIN_ATTACK_HP)]
        [TestCase(MIN_ATTACK_HP - 1)]
        public void Attack_ThrowsExceptionIfAttackerHpIsLowerThanAllowed(int minAttackHp)
        {
            Warrior attacker = new Warrior("Pesho", 5, minAttackHp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(warrior);
            });
        }

        [Test]
        [TestCase(MIN_ATTACK_HP)]
        [TestCase(MIN_ATTACK_HP - 1)]
        public void Attack_ThrowsExceptionIfEnemyHpIsLowerThanAllowed(int minAttackHp)
        {
            Warrior enemy = new Warrior("Ivan", 10, minAttackHp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(enemy);
            });
        }

        [Test]
        public void Attack_ThrowsExceptionIfAttackerHpIsLessThanEnemyDamage()
        {
            Warrior attacker = new Warrior("Pesho", 100, 5);
            Warrior enemy = new Warrior("Ivan", 100, 100);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(enemy);
            });
        }

        [Test]
        public void Attack_SetHpToZeroIfAttackerDamageIsMoreThanDefenderHp()
        {
            Warrior attacker = new Warrior("Pesho", 100, 100);
            Warrior enemy = new Warrior("Ivan", 50, 80);
            
            attacker.Attack(enemy);
            
            Assert.That(enemy.HP, Is.EqualTo(0));
        }
        
        [Test]
        public void Attack_SuccessfullyAttackEnemy()
        {
            Warrior attacker = new Warrior("Pesho", 50, 100);
            Warrior enemy = new Warrior("Ivan", 60, 100);

            attacker.Attack(enemy);
            
            Assert.That(attacker.HP, Is.EqualTo(40));
            Assert.That(enemy.HP, Is.EqualTo(50));
        }


    }
}