using System;
using NUnit.Framework;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase database;
        
        [SetUp]
        public void Setup()
        {
            database = new ExtendedDatabase();
        }

        [Test]
        public void Add_ThrowsExceptionIfTryToAddMoreThanAllowedCapacity()
        {
            int n = 16;
            for (int i = 0; i < n; i++)
            {
                database.Add(new Person(i, "Name" + i));
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(new Person(17, "Name" + 17));
            });
        }

        [Test]
        public void Add_ThrowsExceptionIfUsernameAlreadyExists()
        {
            string name = "Pesho";
            database.Add(new Person(1, name));
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(new Person(2, name));
            });
        }

        [Test]
        public void Add_ThrowsExceptionIfIdAlreadyExists()
        {
            int id = 1;
            database.Add(new Person(id, "Pesho"));
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(new Person(id, "Gosho"));
            });
        }

        [Test]
        public void Add_AddValidUsersToDb()
        {
            int n = 5;
            for (int i = 0; i < n; i++)
            {
                database.Add(new Person(i, "Name" + i));
            }
            
            Assert.That(database.Count, Is.EqualTo(n));
        }

        [Test]
        public void Remove_ThrowsExceptionIfTryToRemoveFromEmptyDb()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            });
        }

        [Test]
        public void Remove_RemoveSuccessfullyElementFromDb()
        {
            int n = 5;
            for (int i = 0; i < n; i++)
            {
                database.Add(new Person(i, "Name" + i));
            }
            database.Remove();
            
            Assert.That(database.Count, Is.EqualTo(n - 1));
        }
        
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void FindByUserName_ThrowsExceptionIfNameIsNull(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                database.FindByUsername(name);
            });
        }

        
        [Test]
        public void FindByUsername_ThrowsExceptionIfUserNotFound()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindByUsername("Pesho");
            });

        }

        [Test]
        public void FindByUsername_SuccessfullyFoundUser()
        {
            string name = "Pesho";
            database.Add(new Person(1, name));

            Person foundPerson = database.FindByUsername(name);
            
            Assert.That(name, Is.EqualTo(foundPerson.UserName));
        }

        [Test]
        public void FindById_ThrowsExceptionIfIdIsNegativeNumber()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                database.FindById(-1);
            });
        }

        [Test]
        public void FindById_ThrowsExceptionIfNoUserFoundWithProvidedId()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindById(1);
            });
        }

        [Test]
        public void FindById_SuccessfullyFoundPersonWithProvidedId()
        {
            int id = 1;
            database.Add(new Person(id, "Pesho"));

            Person foundPerson = database.FindById(id);
            
            Assert.That(foundPerson.Id, Is.EqualTo(id));
        }
        
        

    }
}