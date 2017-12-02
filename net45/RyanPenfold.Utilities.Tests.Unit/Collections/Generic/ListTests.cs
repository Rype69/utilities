// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ListTests.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Tests.Unit.Collections.Generic
{
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using RyanPenfold.Utilities.Collections.Generic;

    /// <summary>
    /// Provides unit tests for the 
    /// <see cref="Utilities.Collections.Generic.List" /> class and the 
    /// <see cref="Utilities.Collections.Generic.Comparer{T}" /> class.
    /// </summary>
    [TestClass]
    public class ListTests
    {
        /// <summary>
        /// Tests the Sort method of the
        /// <see cref="RyanPenfold.Utilities.Collections.Generic.List" /> 
        /// class.
        /// </summary>
        [TestMethod]
        public void Sort()
        {
            // Create new list of people
            var people = new List<Person>
            {
                new Person { FirstName = "Charlie", Surname = "Dassex" },
                new Person { FirstName = "Abraham", Surname = "Askew" },
                new Person { FirstName = "David", Surname = "Brightstone" },
                new Person { FirstName = "Bryan", Surname = "Cumnor" }
            };

            // Sort the list alphabetically by first name
            people.Sort(new Utilities.Collections.Generic.Comparer<Person>("FirstName"));

            // The first name of the first person is expected to be "Abraham"
            Assert.AreEqual("Abraham", people[0].FirstName);

            // The first name of the second person is expected to be "Bryan"
            Assert.AreEqual("Bryan", people[1].FirstName);

            // The first name of the third person is expected to be "Charlie"
            Assert.AreEqual("Charlie", people[2].FirstName);

            // The first name of the fourth person is expected to be "David"
            Assert.AreEqual("David", people[3].FirstName);

            // Then, sort the list alphabetically by Surname
            people.Sort(new Utilities.Collections.Generic.Comparer<Person>("Surname"));

            // The surname of the first person is expected to be "Askew"
            Assert.AreEqual("Askew", people[0].Surname);

            // The surname of the second person is expected to be "Brightstone"
            Assert.AreEqual("Brightstone", people[1].Surname);

            // The surname of the third person is expected to be "Lovelace"
            Assert.AreEqual("Cumnor", people[2].Surname);

            // The surname of the fourth person is expected to be "Monkton"
            Assert.AreEqual("Dassex", people[3].Surname);
        }

        /// <summary>
        /// Tests the Sort method of the
        /// <see cref="RyanPenfold.Utilities.Collections.Generic.List" /> 
        /// class.
        /// </summary>
        [TestMethod]
        public void SortDesc()
        {
            // Create new list of people
            var people = new List<Person>
            {
                new Person { FirstName = "Charlie", Surname = "Dassex" },
                new Person { FirstName = "Abraham", Surname = "Askew" },
                new Person { FirstName = "David", Surname = "Brightstone" },
                new Person { FirstName = "Bryan", Surname = "Cumnor" }
            };

            // Sort the list alphabetically by first name
            people.Sort(new Utilities.Collections.Generic.Comparer<Person>("FirstName", "DESC"));

            // The first name of the first person is expected to be "Abraham"
            Assert.AreEqual("David", people[0].FirstName);

            // The first name of the second person is expected to be "Bryan"
            Assert.AreEqual("Charlie", people[1].FirstName);

            // The first name of the third person is expected to be "Charlie"
            Assert.AreEqual("Bryan", people[2].FirstName);

            // The first name of the fourth person is expected to be "David"
            Assert.AreEqual("Abraham", people[3].FirstName);

            // Then, sort the list alphabetically by Surname
            people.Sort(new Utilities.Collections.Generic.Comparer<Person>("Surname", "DESC"));

            // The surname of the first person is expected to be "Askew"
            Assert.AreEqual("Dassex", people[0].Surname);

            // The surname of the second person is expected to be "Brightstone"
            Assert.AreEqual("Cumnor", people[1].Surname);

            // The surname of the third person is expected to be "Lovelace"
            Assert.AreEqual("Brightstone", people[2].Surname);

            // The surname of the fourth person is expected to be "Monkton"
            Assert.AreEqual("Askew", people[3].Surname);
        }

        /// <summary>
        /// Tests the Sort method of the
        /// <see cref="RyanPenfold.Utilities.Collections.Generic.List" /> 
        /// class.
        /// </summary>
        [TestMethod]
        public void SortWithoutComparer()
        {
            // Create new list of people
            var people = new List<Person>
            {
                new Person { FirstName = "Charlie", Surname = "Dassex" },
                new Person { FirstName = "Abraham", Surname = "Askew" },
                new Person { FirstName = "David", Surname = "Brightstone" },
                new Person { FirstName = "Bryan", Surname = "Cumnor" }
            };

            // Sort the list alphabetically by first name
            people.Sort("Surname", "ASC");

            // The surname of the first person is expected to be "Askew"
            Assert.AreEqual("Askew", people[0].Surname);

            // The surname of the second person is expected to be "Brightstone"
            Assert.AreEqual("Brightstone", people[1].Surname);

            // The surname of the third person is expected to be "Lovelace"
            Assert.AreEqual("Cumnor", people[2].Surname);

            // The surname of the fourth person is expected to be "Monkton"
            Assert.AreEqual("Dassex", people[3].Surname);
        }

        /// <summary>
        /// Tests the DistinctAdd method of the
        /// <see cref="RyanPenfold.Utilities.Collections.Generic.List" /> 
        /// class.
        /// </summary>
        [TestMethod]
        public void DistinctAddIdenticalLists()
        {
            // Create first list of people
            var peopleList1 = new List<Person>
            {
                new Person { FirstName = "Charlie", Surname = "Dassex" },
                new Person { FirstName = "Abraham", Surname = "Askew" },
                new Person { FirstName = "David", Surname = "Brightstone" },
                new Person { FirstName = "Bryan", Surname = "Cumnor" }
            };

            // Create second list of people
            var peopleList2 = new List<Person>
            {
                new Person { FirstName = "Charlie", Surname = "Dassex" },
                new Person { FirstName = "Abraham", Surname = "Askew" },
                new Person { FirstName = "David", Surname = "Brightstone" },
                new Person { FirstName = "Bryan", Surname = "Cumnor" }
            };

            // Attempt to merge these lists
            peopleList1.DistinctAdd(peopleList2, "FirstName");

            // There should only be four records in the list
            Assert.AreEqual(4, peopleList1.Count);

            // The records should be the original ones
            Assert.AreEqual("Charlie", peopleList1[0].FirstName);
            Assert.AreEqual("Dassex", peopleList1[0].Surname);

            Assert.AreEqual("Abraham", peopleList1[1].FirstName);
            Assert.AreEqual("Askew", peopleList1[1].Surname);

            Assert.AreEqual("David", peopleList1[2].FirstName);
            Assert.AreEqual("Brightstone", peopleList1[2].Surname);

            Assert.AreEqual("Bryan", peopleList1[3].FirstName);
            Assert.AreEqual("Cumnor", peopleList1[3].Surname);
        }

        /// <summary>
        /// Tests the DistinctAdd method of the
        /// <see cref="RyanPenfold.Utilities.Collections.Generic.List" /> 
        /// class.
        /// </summary>
        [TestMethod]
        public void DistinctAddDifferentLists()
        {
            // Create first list of people
            var peopleList1 = new List<Person>
            {
                new Person { FirstName = "Charlie", Surname = "Dassex" },
                new Person { FirstName = "Abraham", Surname = "Askew" },
                new Person { FirstName = "David", Surname = "Brightstone" },
                new Person { FirstName = "Bryan", Surname = "Cumnor" }
            };

            // Create second list of people
            var peopleList2 = new List<Person>
            {
                new Person { FirstName = "Edward", Surname = "Windsor" },
                new Person { FirstName = "Fred", Surname = "Jenson" },
                new Person { FirstName = "Gillian", Surname = "Kammington" },
                new Person { FirstName = "Hazel", Surname = "Joy" }
            };

            // Attempt to merge these lists
            peopleList1.DistinctAdd(peopleList2, "FirstName");

            // There should be a total of 8 records in the list
            Assert.AreEqual(8, peopleList1.Count);

            // The records should be as follows
            Assert.AreEqual("Charlie", peopleList1[0].FirstName);
            Assert.AreEqual("Dassex", peopleList1[0].Surname);

            Assert.AreEqual("Abraham", peopleList1[1].FirstName);
            Assert.AreEqual("Askew", peopleList1[1].Surname);

            Assert.AreEqual("David", peopleList1[2].FirstName);
            Assert.AreEqual("Brightstone", peopleList1[2].Surname);

            Assert.AreEqual("Bryan", peopleList1[3].FirstName);
            Assert.AreEqual("Cumnor", peopleList1[3].Surname);

            Assert.AreEqual("Edward", peopleList1[4].FirstName);
            Assert.AreEqual("Windsor", peopleList1[4].Surname);

            Assert.AreEqual("Fred", peopleList1[5].FirstName);
            Assert.AreEqual("Jenson", peopleList1[5].Surname);

            Assert.AreEqual("Gillian", peopleList1[6].FirstName);
            Assert.AreEqual("Kammington", peopleList1[6].Surname);

            Assert.AreEqual("Hazel", peopleList1[7].FirstName);
            Assert.AreEqual("Joy", peopleList1[7].Surname);
        }

        /// <summary>
        /// Tests the DistinctAdd method of the
        /// <see cref="RyanPenfold.Utilities.Collections.Generic.List" /> 
        /// class.
        /// </summary>
        [TestMethod]
        public void DistinctAddPartiallySimilarLists()
        {
            // Create first list of people
            var peopleList1 = new List<Person>
            {
                new Person { FirstName = "Edward", Surname = "Windsor" },
                new Person { FirstName = "Fred", Surname = "Jenson" },
                new Person { FirstName = "Gillian", Surname = "Kammington" },
                new Person { FirstName = "Hazel", Surname = "Joy" }
            };

            // Create second list of people
            var peopleList2 = new List<Person>
            {
                new Person { FirstName = "Edward", Surname = "Windsor" },
                new Person { FirstName = "David", Surname = "Brightstone" },
                new Person { FirstName = "Fred", Surname = "Jenson" },
                new Person { FirstName = "Bryan", Surname = "Cumnor" },
                new Person { FirstName = "Neil", Surname = "Livingstone" }
            };

            // Attempt to merge these lists
            peopleList1.DistinctAdd(peopleList2, "FirstName");

            // There should be a total of 7 records in the list
            Assert.AreEqual(7, peopleList1.Count);

            // The records should be as follows
            Assert.AreEqual("Edward", peopleList1[0].FirstName);
            Assert.AreEqual("Windsor", peopleList1[0].Surname);

            Assert.AreEqual("Fred", peopleList1[1].FirstName);
            Assert.AreEqual("Jenson", peopleList1[1].Surname);

            Assert.AreEqual("Gillian", peopleList1[2].FirstName);
            Assert.AreEqual("Kammington", peopleList1[2].Surname);

            Assert.AreEqual("Hazel", peopleList1[3].FirstName);
            Assert.AreEqual("Joy", peopleList1[3].Surname);

            Assert.AreEqual("David", peopleList1[4].FirstName);
            Assert.AreEqual("Brightstone", peopleList1[4].Surname);

            Assert.AreEqual("Bryan", peopleList1[5].FirstName);
            Assert.AreEqual("Cumnor", peopleList1[5].Surname);

            Assert.AreEqual("Neil", peopleList1[6].FirstName);
            Assert.AreEqual("Livingstone", peopleList1[6].Surname);
        }

        /// <summary>
        /// Tests the DistinctAdd method of the
        /// <see cref="RyanPenfold.Utilities.Collections.Generic.List" /> 
        /// class.
        /// </summary>
        [TestMethod]
        public void DistinctAddNullLists()
        {
            // Arrange
            var peopleList1 = new List<Person>();

            // Act
            peopleList1.DistinctAdd(null, string.Empty);
        }

        /// <summary>
        /// Tests the DistinctAdd method of the
        /// <see cref="RyanPenfold.Utilities.Collections.Generic.List" /> 
        /// class.
        /// </summary>
        [TestMethod]
        public void DistinctAddEmptyPropertyName()
        {
            // Arrange
            // Create first list of people
            var peopleList1 = new List<Person>
            {
                new Person { FirstName = "Edward", Surname = "Windsor" },
                new Person { FirstName = "Fred", Surname = "Jenson" },
                new Person { FirstName = "Gillian", Surname = "Kammington" },
                new Person { FirstName = "Hazel", Surname = "Joy" }
            };

            // Create second list of people
            var peopleList2 = new List<Person>
            {
                new Person { FirstName = "Edward", Surname = "Windsor" },
                new Person { FirstName = "David", Surname = "Brightstone" },
                new Person { FirstName = "Fred", Surname = "Jenson" },
                new Person { FirstName = "Bryan", Surname = "Cumnor" },
                new Person { FirstName = "Neil", Surname = "Livingstone" }
            };

            // Act
            peopleList1.DistinctAdd(peopleList2, "Surname");
        }
    }
}
