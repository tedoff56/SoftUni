using System;
using NUnit.Framework;

namespace Tests
{
    public class DatabaseTests
    {
        private const int ArrayMaxSize = 16;
        private Database db;
        
        [SetUp]
        public void Setup()
        {
            db = new Database();
        }

        [Test]
        public void Ctor_AddValidItemsToDb()
        {
            var elements = new int[] { 1, 2, 3};
            db = new Database(elements);
            Assert.That(db.Count, Is.EqualTo(elements.Length));
        }
        
        [Test]
        public void Ctor_Throws_Exception_If_Try_To_Add_More_Than_16_Elements()
        {
            var arr = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };
            
            Assert.Throws<InvalidOperationException>(() =>
            {
                db = new Database(arr);
            });
            
        }
        
        [Test]
        public void Add_IncrementCountWhenAddIsValid()
        {
            int n = 5;
            for (int i = 0; i < n; i++)
            {
                db.Add(i);
            }
            
            Assert.That(db.Count, Is.EqualTo(n));
        }
        
        [Test]
        public void Add_Throws_Exception_If_Try_To_Add_More_Than_16_Elements()
        {
            
            for (int i = 0; i < ArrayMaxSize; i++)
            {
                db.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(17);
            });
        }
        
        
        
        [Test]
        public void Remove_Throws_Exception_If_Try_To_Remove_From_Empty_Database()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Remove();
            });
        }

        [Test]
        public void Remove_DecreaseCapacityWhenRemoveElement()
        {
            var elements = new int[] { 1, 2, 3};

            db = new Database(elements);
            
            db.Remove();
            Assert.That(db.Count, Is.EqualTo(elements.Length - 1));
            
        }
        
        [Test]
        public void Fetch_Try_To_Create_A_Copy_Of_Database()
        {
            db.Add(1);
            db.Add(2);
            var firstCopy = db.Fetch();
            db.Add(3);
            var secondCopy = db.Fetch();
            db.Remove();
            Assert.That(firstCopy.Length, Is.Not.EqualTo(secondCopy.Length));

        }

        

    }
}