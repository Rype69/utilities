// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScriptGenerator.cs" company="Inspire IT Ltd">
//   Copyright © Inspire IT Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Data.SqlClient
{
    // using Reflection;
    using Text;

    /// <summary>
    /// Provides functions that generate SQL scripts.
    /// </summary>
    public static class ScriptGenerator
    {
        /*
        /// <summary>
        /// Generates a CREATE OBJECT SQL script for a pre-existing SQL object in a database.
        /// The type of objects that can be created include stored procedures, table valued functions, and views, 
        /// </summary>
        /// <param name="connectionString">A connection string to a database where the object resides.</param>
        /// <param name="objectName">The name of the object to generate a script for.</param>
        /// <param name="objectSchema">The schema name of the object to generate a script for.</param>
        /// <returns>A <see cref="string"/> containing the SQL script.</returns>
        public static string GenerateCreateObjectScript(string connectionString, string objectName, string objectSchema = "dbo")
        {
            // NULL-check the connectionString parameter
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new System.ArgumentNullException(nameof(connectionString));
            }

            // NULL-check the objectName parameter
            if (objectName == null)
            {
                throw new System.ArgumentNullException(nameof(objectName));
            }

            // NULL-check the objectSchema parameter
            if (objectSchema == null)
            {
                throw new System.ArgumentNullException(nameof(objectSchema));
            }

            // Result variable
            var result = new System.Text.StringBuilder();

            // Configure and run the SQL command
            using (var sqlConnection = new System.Data.SqlClient.SqlConnection(connectionString))
            using (var sqlCommand = new System.Data.SqlClient.SqlCommand($"sp_helptext '{objectSchema}.{objectName}';", sqlConnection))
            {
                sqlCommand.Connection.Open();
                using (var reader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    try
                    {
                        while (reader.Read())
                        {
                            result.Append(reader["Text"]);
                        }
                    }
                    finally
                    {
                        sqlCommand.Cancel();
                    }
                }
            }

            // Return the result
            return result.ToString();
        }
        */

        /// <summary>
        /// Generates a CREATE SCHEMA SQL script for a given name.
        /// </summary>
        /// <param name="schemaName">The name of the schema to generate a script for.</param>
        /// <returns>A <see cref="string"/> containing the SQL script.</returns>
        public static string GenerateCreateSchemaScript(string schemaName)
        {
            // NULL-check the storedProcedureName parameter
            if (schemaName == null)
            {
                throw new System.ArgumentNullException(nameof(schemaName));
            }

            // New string builder instance to contain the script
            var builder = new System.Text.StringBuilder();

            builder.AppendWithDelimiter(
                $"IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = '{schemaName}')",
                "\r\n");
            builder.AppendWithDelimiter("BEGIN", "\r\n");
            builder.AppendWithDelimiter($"EXEC sp_executesql N'CREATE SCHEMA {schemaName};';", "\r\n\t");
            builder.AppendWithDelimiter("END", "\r\n");

            // Return result
            return builder.ToString();
        }

        /*
        /// <summary>
        /// Generates a CREATE TABLE SQL script based on a pre-existing SQL table in a database.
        /// </summary>
        /// <param name="connectionString">A connection string to a database where the table resides.</param>
        /// <param name="tableName">The name of the table to generate a script for.</param>
        /// <param name="tableSchema">The schema name of the table to generate a script for.</param>
        /// <returns>A <see cref="string"/> containing the SQL script.</returns>
        public static string GenerateCreateTableScript(string connectionString, string tableName, string tableSchema = "dbo")
        {
            // NULL-check the connectionString parameter
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new System.ArgumentNullException(nameof(connectionString));
            }

            // NULL-check the tableName parameter
            if (tableName == null)
            {
                throw new System.ArgumentNullException(nameof(tableName));
            }

            // NULL-check the tableSchema parameter
            if (tableSchema == null)
            {
                throw new System.ArgumentNullException(nameof(tableSchema));
            }

            // Get the command text from an embedded resource, run it on the database, and return the result.
            using (var sqlConnection = new System.Data.SqlClient.SqlConnection(connectionString))
            using (
                var sqlCommand =
                    new System.Data.SqlClient.SqlCommand(
                        System.Reflection.Assembly.GetExecutingAssembly()
                            .GetManifestResourceString(
                                // ReSharper disable once PossibleNullReferenceException
                                $"{System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace}.SQL.CreateTableGenerator.sql"),
                        sqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@schema", tableSchema);
                sqlCommand.Parameters.AddWithValue("@table", tableName);
                sqlCommand.Connection.Open();
                return sqlCommand.ExecuteScalar() as string;
            }
        }

        /// <summary>
        /// Generates a CREATE TABLE SQL script based on a CLR type.
        /// </summary>
        /// <param name="type">A type to create a SQL table for.</param>
        /// <param name="tableName">
        /// The name of the table.
        /// </param>
        /// <param name="tableSchema">
        /// The schema of the table.
        /// </param>
        /// <param name="fullScript">Indicates whether to include the full script, including preceding DROP TABLE statement and settings etc.</param>
        /// <returns>A <see cref="string"/> containing the SQL script.</returns>
        public static string GenerateCreateTableScript(System.Type type, string tableName, string tableSchema, bool fullScript = true)
        {
            // NULL-check the type parameter
            if (type == null)
            {
                throw new System.ArgumentNullException(nameof(type));
            }

            var columnsBuilder = new System.Text.StringBuilder();
            foreach (var property in type.GetProperties())
            {
                var nullDeclaration = property.PropertyType.IsValueType && !property.PropertyType.IsNullable() ? string.Empty : " NULL";
                columnsBuilder.AppendWithDelimiter($"\t[{property.Name}] {property.PropertyType.ToSqlDbTypeSqlString()}{nullDeclaration}", ",\r\n");
            }

            var thisType = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType;

            // ReSharper disable PossibleNullReferenceException
            var manifestName = fullScript
                                   ? $"{thisType.Assembly.GetName().Name}.SqlClient.SQL.CREATE TABLE.FULL.sql"
                                   : $"{thisType.Assembly.GetName().Name}.SqlClient.SQL.CREATE TABLE.sql";
            // ReSharper restore PossibleNullReferenceException

            var sqlStringBuilder = new System.Text.StringBuilder(thisType.Assembly.GetManifestResourceString(manifestName));

            sqlStringBuilder.Replace("{columns}", columnsBuilder.ToString());
            sqlStringBuilder.Replace("{date}", System.DateTime.Now.ToString("dd/MM/yyyy"));
            sqlStringBuilder.Replace("{tableName}", tableName);
            sqlStringBuilder.Replace("{tableSchema}", tableSchema);
            sqlStringBuilder.Replace("{time}", System.DateTime.Now.ToString("HH:mm:ss"));

            return sqlStringBuilder.ToString();
        }
        */

        /// <summary>
        /// Generates a DROP SCHEMA SQL script for a given name.
        /// </summary>
        /// <param name="schemaName">The name of the schema to generate a script for.</param>
        /// <returns>A <see cref="string"/> containing the SQL script.</returns>
        public static string GenerateDropSchemaScript(string schemaName)
        {
            // NULL-check the storedProcedureName parameter
            if (schemaName == null)
            {
                throw new System.ArgumentNullException(nameof(schemaName));
            }

            // New string builder instance to contain the script
            var builder = new System.Text.StringBuilder();

            builder.AppendWithDelimiter(
                $"IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = '{schemaName}')",
                "\r\n");
            builder.AppendWithDelimiter("BEGIN", "\r\n");
            builder.AppendWithDelimiter($"EXEC sp_executesql N'DROP SCHEMA {schemaName};';", "\r\n\t");
            builder.AppendWithDelimiter("END", "\r\n");

            // Return result
            return builder.ToString();
        }

        /// <summary>
        /// Generates a DROP STORED PROCEDURE SQL script for a given stored procedure name and schema.
        /// </summary>
        /// <param name="storedProcedureName">The name of the stored procedure to generate a script for.</param>
        /// <param name="storedProcedureSchema">The schema name of the stored procedure to generate a script for.</param>
        /// <returns>A <see cref="string"/> containing the SQL script.</returns>
        public static string GenerateDropStoredProcedureScript(string storedProcedureName, string storedProcedureSchema = "dbo")
        {
            // NULL-check the storedProcedureName parameter
            if (storedProcedureName == null)
            {
                throw new System.ArgumentNullException(nameof(storedProcedureName));
            }

            // NULL-check the storedProcedureSchema parameter
            if (storedProcedureSchema == null)
            {
                throw new System.ArgumentNullException(nameof(storedProcedureSchema));
            }

            // New string builder instance to contain the script
            var builder = new System.Text.StringBuilder();

            builder.AppendWithDelimiter(
                $"IF OBJECT_ID('{storedProcedureSchema}.{storedProcedureName}', 'P') IS NOT NULL)",
                "\r\n");
            builder.AppendWithDelimiter("BEGIN", "\r\n");
            builder.AppendWithDelimiter($"DROP PROCEDURE [{storedProcedureSchema}].[{storedProcedureName}];", "\r\n\t");
            builder.AppendWithDelimiter("END", "\r\n");

            // Return result
            return builder.ToString();
        }

        /// <summary>
        /// Generates a DROP object SQL script for a given object type, name and schema.
        /// </summary>
        /// <param name="objectType">The type of SQL object to generate a script for.</param>
        /// <param name="objectName">The name of the object to generate a script for.</param>
        /// <param name="objectSchema">The schema name of the object to generate a script for.</param>
        /// <returns>A <see cref="string"/> containing the SQL script.</returns>
        public static string GenerateDropObjectScript(SqlObjectType objectType, string objectName, string objectSchema = "dbo")
        {
            // NULL-check the objectName parameter
            if (objectName == null)
            {
                throw new System.ArgumentNullException(nameof(objectName));
            }

            // NULL-check the objectSchema parameter
            if (objectSchema == null)
            {
                throw new System.ArgumentNullException(nameof(objectSchema));
            }

            // New string builder instance to contain the script
            var builder = new System.Text.StringBuilder();

            switch (objectType)
            {
                case SqlObjectType.StoredProcedure:
                    builder.AppendWithDelimiter(
                        $"IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_TYPE = 'PROCEDURE' AND ROUTINE_SCHEMA = '{objectSchema}' AND ROUTINE_NAME = '{objectName}')",
                        "\r\n");
                    builder.AppendWithDelimiter("BEGIN", "\r\n");
                    builder.AppendWithDelimiter($"DROP PROCEDURE [{objectSchema}].[{objectName}];", "\r\n\t");
                    builder.AppendWithDelimiter("END", "\r\n");
                    break;
                case SqlObjectType.Table:
                    builder.AppendWithDelimiter(
                        $"IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = '{objectSchema}' AND TABLE_NAME = '{objectName}')",
                        "\r\n");
                    builder.AppendWithDelimiter("BEGIN", "\r\n");
                    builder.AppendWithDelimiter($"DROP TABLE [{objectSchema}].[{objectName}];", "\r\n\t");
                    builder.AppendWithDelimiter("END", "\r\n");
                    break;
                case SqlObjectType.TableValuedFunction:
                    builder.AppendWithDelimiter(
                        $"IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_TYPE = 'FUNCTION' AND DATA_TYPE = 'TABLE' AND ROUTINE_SCHEMA = '{objectSchema}' AND ROUTINE_NAME = '{objectName}')",
                        "\r\n");
                    builder.AppendWithDelimiter("BEGIN", "\r\n");
                    builder.AppendWithDelimiter($"DROP FUNCTION [{objectSchema}].[{objectName}];", "\r\n\t");
                    builder.AppendWithDelimiter("END", "\r\n");
                    break;
                case SqlObjectType.View:
                    builder.AppendWithDelimiter(
                        $"IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'VIEW' AND TABLE_SCHEMA = '{objectSchema}' AND TABLE_NAME = '{objectName}')",
                        "\r\n");
                    builder.AppendWithDelimiter("BEGIN", "\r\n");
                    builder.AppendWithDelimiter($"DROP VIEW [{objectSchema}].[{objectName}];", "\r\n\t");
                    builder.AppendWithDelimiter("END", "\r\n");
                    break;
                default:
                    throw new System.InvalidOperationException("Invalid objectType specified.");
            }

            // Return result
            return builder.ToString();
        }
    }
}
