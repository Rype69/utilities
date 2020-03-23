// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SqlCommandTests.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Configuration;

namespace RyanPenfold.Utilities.Data.Tests.Integration.SqlClient
{
    using System.Data.SqlClient;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Provides unit tests for the <see cref="Data.SqlClient.SqlCommand" /> class.
    /// </summary>
    [TestClass]
    public class SqlCommandTests
    {
        /// <summary>
        /// Tests the RunExecuteScalar method of the 
        /// <see cref="SqlCommand" /> class.
        /// </summary>
        [TestMethod]
        public void RunExecuteScalarFromFile_TableContainsData_DataSelected()
        {
            const string connectionString = "Server=localhost;Database=IntegrationTests;Trusted_Connection=True;"; // TODO: Get connection string from configuration settings

            SqlCommand createTableCommand = null;
            SqlCommand insertCommand = null;
            SqlCommand selectCountCommand = null;
            SqlCommand dropTableCommand = null;

            var filePath = string.Empty;

            try
            {
                // Determine the file path
                const string fileName = "SELECT_COUNT_TEXT_MYTABLE";
                filePath = $"{System.IO.Directory.GetCurrentDirectory()}\\SQL\\{fileName}.sql";

                // Create a table
                createTableCommand = new SqlCommand
                {
                    CommandText =
                        "CREATE TABLE MyTable (ID BIGINT IDENTITY(1, 1), Text VARCHAR(MAX));",
                    Connection = new SqlConnection(connectionString)
                };
                createTableCommand.Connection.Open();
                createTableCommand.ExecuteNonQuery();

                // Insert some data into the table
                insertCommand = new SqlCommand
                {
                    CommandText =
                        "INSERT INTO MyTable ([Text]) VALUES ('Hello World!');INSERT INTO MyTable ([Text]) VALUES ('IPSUM LOREM');",
                    Connection = new SqlConnection(connectionString)
                };
                insertCommand.Connection.Open();
                insertCommand.ExecuteNonQuery();

                // Verify the data is present in the table
                selectCountCommand = new SqlCommand
                {
                    CommandText =
                        "SELECT COUNT([Text]) FROM MyTable;",
                    Connection = new SqlConnection(connectionString)
                };
                selectCountCommand.Connection.Open();
                var selectCountResult = selectCountCommand.ExecuteScalar();

                // Assert result == 2
                Assert.AreEqual(2, selectCountResult);

                // Create a file on disk
                if (!System.IO.Directory.Exists($"{System.IO.Directory.GetCurrentDirectory()}\\SQL\\"))
                {
                    System.IO.Directory.CreateDirectory($"{ System.IO.Directory.GetCurrentDirectory()}\\SQL\\");
                }

                using (var streamWriter = new System.IO.StreamWriter(filePath, true))
                {
                    streamWriter.Write("SELECT COUNT([Text]) FROM MyTable;");
                }

                // Assert the file exists
                Assert.IsTrue(System.IO.File.Exists(filePath));

                // Act
                var result = Data.SqlClient.SqlCommand.RunExecuteScalarFromFile(fileName, new ConnectionStringSettings("IntegrationTests", connectionString, "System.Data.SqlClient"));

                // Assert
                Assert.AreEqual(2, result);
            }
            finally
            {
                createTableCommand?.Connection?.Close();

                insertCommand?.Connection?.Close();

                selectCountCommand?.Connection?.Close();

                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }

                try
                {
                    // Drop the table
                    dropTableCommand = new SqlCommand
                    {
                        CommandText =
                            "DROP TABLE MyTable;",
                        Connection = new SqlConnection(connectionString)
                    };
                    dropTableCommand.Connection.Open();
                    dropTableCommand.ExecuteNonQuery();
                }
                finally
                {
                    dropTableCommand?.Connection?.Close();
                }
            }
        }

        /// <summary>
        /// Tests the RunExecuteScalar method of the 
        /// <see cref="SqlCommand" /> class.
        /// </summary>
        [TestMethod]
        public void RunExecuteScalar_TableContainsData_DataSelected()
        {
            SqlCommand createTableCommand = null;
            SqlCommand insertCommand = null;
            SqlCommand selectCountCommand = null;
            SqlCommand dropTableCommand = null;

            const string connectionString = "Server=localhost;Database=IntegrationTests;Trusted_Connection=True;"; // TODO: Get connection string from configuration settings

            try
            {
                // Create a table
                createTableCommand = new SqlCommand
                {
                    CommandText =
                        "CREATE TABLE MyTable (ID BIGINT IDENTITY(1, 1), Text VARCHAR(MAX));",
                    Connection = new SqlConnection(connectionString)
                };
                createTableCommand.Connection.Open();
                createTableCommand.ExecuteNonQuery();

                // Insert some data into the table
                insertCommand = new SqlCommand
                {
                    CommandText =
                        "INSERT INTO MyTable ([Text]) VALUES ('Hello World!');INSERT INTO MyTable ([Text]) VALUES ('IPSUM LOREM');",
                    Connection = new SqlConnection(connectionString)
                };
                insertCommand.Connection.Open();
                insertCommand.ExecuteNonQuery();

                // Verify the data is present in the table
                selectCountCommand = new SqlCommand
                {
                    CommandText =
                        "SELECT COUNT([Text]) FROM MyTable;",
                    Connection = new SqlConnection(connectionString)
                };
                selectCountCommand.Connection.Open();
                var selectCountResult = selectCountCommand.ExecuteScalar();

                // Assert result == 2
                Assert.AreEqual(2, selectCountResult);

                // Act
                var result = Data.SqlClient.SqlCommand.RunExecuteScalar(
                    "SELECT COUNT([Text]) FROM MyTable;", new ConnectionStringSettings("IntegrationTests", connectionString, "System.Data.SqlClient"));

                // Assert
                Assert.AreEqual(2, result);
            }
            finally
            {
                createTableCommand?.Connection?.Close();

                insertCommand?.Connection?.Close();

                selectCountCommand?.Connection?.Close();

                try
                {
                    // Drop the table
                    dropTableCommand = new SqlCommand
                    {
                        CommandText =
                            "DROP TABLE MyTable;",
                        Connection = new SqlConnection(connectionString)
                    };
                    dropTableCommand.Connection.Open();
                    dropTableCommand.ExecuteNonQuery();
                }
                finally
                {
                    dropTableCommand?.Connection?.Close();
                }
            }
        }
    }
}
