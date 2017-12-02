// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SqlCommand.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// <date>
//   17 November 2011
// </date>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Data.SqlClient
{
    using System.Linq;

    using Reflection;

    /// <summary>
    /// Provides functionality relating to running SQL statements on a database.
    /// </summary>
    public static class SqlCommand
    {
        public static System.Collections.Generic.IEnumerable<System.Data.SqlClient.SqlParameter> DeriveParameters(string storedProcedureName, string connectionString)
        {
            // NULL-check the parameters
            if (storedProcedureName == null)
            {
                throw new System.ArgumentNullException(nameof(storedProcedureName));
            }

            if (connectionString == null)
            {
                throw new System.ArgumentNullException(nameof(connectionString));
            }

            using (var connection = new System.Data.SqlClient.SqlConnection(connectionString))
            using (var sqlCommand = new System.Data.SqlClient.SqlCommand(storedProcedureName, connection) { CommandType = System.Data.CommandType.StoredProcedure })
            {
                connection.Open();
                System.Data.SqlClient.SqlCommandBuilder.DeriveParameters(sqlCommand);
                var results = sqlCommand.Parameters.Cast<System.Data.SqlClient.SqlParameter>().ToList();
                sqlCommand.Parameters.Clear();
                return results;
            }
        }

        /// <summary>
        /// Runs a SQL command from file
        /// </summary>
        /// <param name="fileName">The name of the file without the extension</param>
        /// <param name="connectionStringName">The name of the connection string</param>
        public static void RunExecuteNonQueryFromFile(string fileName, string connectionStringName)
        {
            var filePath = System.IO.File.Exists(fileName)
                               ? fileName
                               : $"{System.IO.Directory.GetCurrentDirectory()}\\SQL\\{fileName}.sql";

            // Get the contents of the file, pass each section (within a "GO" statement) to a sql command.
            var fullScript = System.IO.File.ReadAllText(filePath);
            foreach (var scriptSegment in fullScript.Split(new[] { "\nGO" }, System.StringSplitOptions.RemoveEmptyEntries))
            {
                RunExecuteNonQuery(
                    scriptSegment,
                    connectionStringName);
            }
        }

        /// <summary>
        /// Runs a SQL command from file
        /// </summary>
        /// <param name="assembly">An assembly containing the manifest resource.</param>
        /// <param name="resourceName">The name of the manifest resource.</param>
        /// <param name="connectionStringName">The name of the connection string</param>
        public static void RunExecuteNonQueryFromManifestResource(System.Reflection.Assembly assembly, string resourceName, string connectionStringName)
        {
            // NULL-check the assembly parameter
            if (assembly == null)
            {
                throw new System.ArgumentNullException(nameof(assembly));
            }

            // NULL-check the resourceName parameter
            if (string.IsNullOrWhiteSpace(resourceName))
            {
                throw new System.ArgumentNullException(nameof(resourceName));
            }

            // NULL-check the connectionStringName parameter
            if (string.IsNullOrWhiteSpace(connectionStringName))
            {
                throw new System.ArgumentNullException(nameof(connectionStringName));
            }

            // Get the contents of the manifest resource, pass each section (within a "GO" statement) to a sql command.
            var fullScript = assembly.GetManifestResourceString(resourceName);
            foreach (var scriptSegment in fullScript.Split(new[] { "\nGO" }, System.StringSplitOptions.RemoveEmptyEntries))
            {
                RunExecuteNonQuery(scriptSegment, connectionStringName);
            }
        }

        /// <summary>
        /// Runs a SQL command
        /// </summary>
        /// <param name="commandText">The text of the SQL command to run</param>
        /// <param name="connectionStringName">The name of the connection string</param>
        public static void RunExecuteNonQuery(string commandText, string connectionStringName)
        {
            // Sql command
            var sqlCommand = new System.Data.SqlClient.SqlCommand();

            try
            {
                // Initialise the SQL command
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlCommand.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString);
                sqlCommand.CommandText = commandText;

                // Open the connection of the "select ticket recipients" SQL command
                sqlCommand.Connection.Open();

                // Run the command
                sqlCommand.ExecuteNonQuery();
            }
            finally
            {
                // Close the connection for selectTicketRecipientsCommand if it's instanitated and open 
                if (sqlCommand.Connection != null && sqlCommand.Connection.State != System.Data.ConnectionState.Closed)
                {
                    sqlCommand.Connection.Close();
                }
            }
        }

        /// <summary>
        /// Runs a SQL command from file
        /// </summary>
        /// <param name="fileName">The name of the file without the extension</param>
        /// <param name="connectionStringName">The name of the connection string</param>
        /// <returns>The result of the database query</returns>
        public static object RunExecuteScalarFromFile(string fileName, string connectionStringName)
        {
            return
                RunExecuteScalar(
                    System.IO.File.ReadAllText($"{System.IO.Directory.GetCurrentDirectory()}\\SQL\\{fileName}.sql"),
                    connectionStringName);
        }

        /// <summary>
        /// Runs a SQL command from file
        /// </summary>
        /// <param name="assembly">An assembly containing the manifest resource.</param>
        /// <param name="resourceName">The name of the manifest resource.</param>
        /// <param name="connectionStringName">The name of the connection string</param>
        /// <returns>The result of the database query</returns>
        public static object RunExecuteScalarFromManifestResource(System.Reflection.Assembly assembly, string resourceName, string connectionStringName)
        {
            // NULL-check the assembly parameter
            if (assembly == null)
            {
                throw new System.ArgumentNullException(nameof(assembly));
            }

            // NULL-check the resourceName parameter
            if (string.IsNullOrWhiteSpace(resourceName))
            {
                throw new System.ArgumentNullException(nameof(resourceName));
            }

            // NULL-check the connectionStringName parameter
            if (string.IsNullOrWhiteSpace(connectionStringName))
            {
                throw new System.ArgumentNullException(nameof(connectionStringName));
            }

            // Get the contents of the manifest resource and pass it to a sql command.
            return RunExecuteScalar(assembly.GetManifestResourceString(resourceName), connectionStringName);
        }

        /// <summary>
        /// Runs a SQL command
        /// </summary>
        /// <param name="commandText">The text of the SQL command to run</param>
        /// <param name="connectionStringName">The name of the connection string</param>
        /// <returns>The result of the database query</returns>
        public static object RunExecuteScalar(string commandText, string connectionStringName)
        {
            // Result variable
            object result;

            // Sql command
            var sqlCommand = new System.Data.SqlClient.SqlCommand();

            try
            {
                // Initialise the SQL command
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlCommand.Connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString);
                sqlCommand.CommandText = commandText;

                // Open the connection of the "select ticket recipients" SQL command
                sqlCommand.Connection.Open();

                // Run the command
                result = sqlCommand.ExecuteScalar();
            }
            finally
            {
                // Close the connection for selectTicketRecipientsCommand if it's instanitated and open 
                if (sqlCommand.Connection != null && sqlCommand.Connection.State != System.Data.ConnectionState.Closed)
                {
                    sqlCommand.Connection.Close();
                }
            }

            // Return the result
            return result;
        }

        /// <summary>
        /// Produces a HTML table string from the schema table of a <see cref="System.Data.SqlClient.SqlCommand"/>
        /// </summary>
        /// <param name="commandText">
        /// The text of the SQL command.
        /// </param>
        /// <param name="connectionString">
        /// A connection string.
        /// </param>
        public static string SchemaTableToHtmlTable(string commandText, string connectionString)
        {
            using (var connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var selectFromTableCommand = new System.Data.SqlClient.SqlCommand(commandText, connection);
                selectFromTableCommand.Connection.Open();
                using (var reader = selectFromTableCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    try
                    {
                        var schema = reader.GetSchemaTable();

                        if (schema == null)
                        {
                            return string.Empty;
                        }

                        return schema.ToHtmlTable();
                    }
                    finally
                    {
                        selectFromTableCommand.Cancel();
                    }
                }
            }
        }

        /// <summary>
        /// Produces a HTML table string from a <see cref="System.Data.Common.DbCommand"/>
        /// </summary>
        /// <param name="command">
        /// A database command.
        /// </param>
        public static string ToHtmlTable(this System.Data.Common.DbCommand command)
        {
            if (command == null)
            {
                throw new System.ArgumentNullException(nameof(command));
            }

            return ToHtmlTable(command.CommandText, command.Connection.ConnectionString);
        }

        /// <summary>
        /// Produces a HTML table string from a <see cref="System.Data.SqlClient.SqlCommand"/>
        /// </summary>
        /// <param name="commandText">
        /// The text of the SQL command.
        /// </param>
        /// <param name="connectionString">
        /// A connection string.
        /// </param>
        public static string ToHtmlTable(string commandText, string connectionString)
        {
            using (var connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var selectFromTableCommand = new System.Data.SqlClient.SqlCommand(commandText, connection);
                selectFromTableCommand.Connection.Open();

                using (var reader = selectFromTableCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    try
                    {
                        var dataTable = new System.Data.DataTable();
                        dataTable.Load(reader);
                        return dataTable.ToHtmlTable();
                    }
                    finally
                    {
                        selectFromTableCommand.Cancel();
                    }
                }
            }
        }
    }
}
