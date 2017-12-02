// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScriptGenerator.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Data.SqlClient
{
    using Reflection;

    using Text;

    /// <summary>
    /// Provides functions that generate SQL scripts.
    /// </summary>
    public static class ScriptGenerator
    {
        /// <summary>
        /// Generates a set of create scripts for all the objects in a database
        /// </summary>
        /// <returns>A <see cref="string"/> containing the SQL script.</returns>
        public static string GenerateCreateDatabaseObjectScript(string connectionString)
        {
            // NULL-check the parameter
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new System.ArgumentNullException(nameof(connectionString));
            }

            // Result objects
            var generateSchemataScriptStringBuilder = new System.Text.StringBuilder();
            var generateTableScriptStringBuilder = new System.Text.StringBuilder();
            var generateObjectScriptStringBuilder = new System.Text.StringBuilder();

            // Set of schemata for which scripts have been generated
            var schemata = new System.Collections.Generic.List<string>();

            var selectCommandText = new System.Text.StringBuilder();
            selectCommandText.Append("SELECT TABLE_SCHEMA AS [SCHEMA], TABLE_NAME AS [NAME], TABLE_TYPE AS [TYPE] FROM INFORMATION_SCHEMA.TABLES ");
            selectCommandText.Append("UNION ALL ");
            selectCommandText.Append("SELECT ROUTINE_SCHEMA AS [SCHEMA], ROUTINE_NAME AS [NAME], ROUTINE_TYPE AS [TYPE] FROM INFORMATION_SCHEMA.ROUTINES ORDER BY TYPE;");

            // For each table / view / stored procedure / function
            using (var connection = new System.Data.SqlClient.SqlConnection(connectionString))
            using (var selectCommand = new System.Data.SqlClient.SqlCommand(selectCommandText.ToString(), connection))
            {
                selectCommand.Connection.Open();

                using (var reader = selectCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        string schema = null;

                        // TODO: Use sys.objects to determine schemas rather than INFORMATION_SCHEMA
                        if (reader["SCHEMA"] != null && !(reader["SCHEMA"] is System.DBNull))
                        {
                            schema = reader["SCHEMA"].ToString();
                            if (!schemata.Contains(schema))
                            {
                                generateSchemataScriptStringBuilder.AppendLine(GenerateCreateSchemaScript(reader["SCHEMA"].ToString()));
                                generateSchemataScriptStringBuilder.AppendLine("GO\r\n");
                                schemata.Add(schema);
                            }
                        }

                        if (reader["NAME"] != null && !(reader["NAME"] is System.DBNull))
                        {
                            generateTableScriptStringBuilder.AppendLine(GenerateDropObjectScript(SqlObjectType.Table, reader["NAME"].ToString(), schema));
                            generateTableScriptStringBuilder.AppendLine("GO\r\n");

                            if (reader["TYPE"] != null && !(reader["TYPE"] is System.DBNull))
                            {
                                switch (reader["TYPE"].ToString().ToUpper())
                                {
                                    case "BASE TABLE":
                                        generateTableScriptStringBuilder.AppendLine(GenerateCreateTableScript(connectionString, reader["NAME"].ToString(), schema));
                                        generateTableScriptStringBuilder.AppendLine("GO\r\n");
                                        break;
                                    default:
                                        generateObjectScriptStringBuilder.AppendLine(GenerateCreateObjectScript(connectionString, reader["NAME"].ToString(), schema));
                                        generateObjectScriptStringBuilder.AppendLine("GO\r\n");
                                        break;
                                }
                            }
                        }
                    }
                }
            }

            return $"{generateSchemataScriptStringBuilder}\r\n{generateTableScriptStringBuilder}\r\n{generateObjectScriptStringBuilder}";
        }

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

        /// <summary>
        /// Generates a set of populated INSERT statements for all tables in a database.
        /// </summary>
        /// <param name="connectionString">A connection string to a database where the tables reside.</param>
        public static string GenerateInsertDataScripts(string connectionString)
        {
            var generateInsertStatementsStringBuilder = new System.Text.StringBuilder();

            // For each table / view / stored procedure / function
            using (var connection = new System.Data.SqlClient.SqlConnection(connectionString))
            using (var selectCommand = new System.Data.SqlClient.SqlCommand(
                "SELECT TABLE_SCHEMA, TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' ORDER BY TABLE_SCHEMA, TABLE_NAME;", connection))
            {
                selectCommand.Connection.Open();

                using (var reader = selectCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        string schema = null;

                        // TODO: Use sys.objects to determine schemas rather than INFORMATION_SCHEMA
                        if (reader["TABLE_SCHEMA"] != null && !(reader["TABLE_SCHEMA"] is System.DBNull))
                        {
                            schema = reader["TABLE_SCHEMA"].ToString();
                        }

                        if (reader["TABLE_NAME"] != null && !(reader["TABLE_NAME"] is System.DBNull))
                        {
                            var script = GenerateInsertDataScripts(connectionString, reader["TABLE_NAME"].ToString(), schema, true);

                            if (!string.IsNullOrWhiteSpace(script))
                            {
                                generateInsertStatementsStringBuilder.AppendLine(script);
                                generateInsertStatementsStringBuilder.AppendLine("GO\r\n");
                            }
                        }
                    }
                }
            }

            return generateInsertStatementsStringBuilder.ToString();
        }

        /// <summary>
        /// Generates a set of populated INSERT statements for the specified table and schema.
        /// </summary>
        /// <param name="connectionString">A connection string to a database where the table resides.</param>
        /// <param name="tableName">The name of the object to generate an insert statement script for.</param>
        /// <param name="tableSchema">The schema name of the object to generate an insert statement script for.</param>
        /// <param name="identityInsertEnabled">Indicates whether INSERT statements should be generated to insert values into identity columns.</param>
        /// <returns>A <see cref="string"/> containing the SQL script.</returns>
        public static string GenerateInsertDataScripts(string connectionString, string tableName, string tableSchema = "dbo", bool identityInsertEnabled = false)
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
                                $"{System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace}.SQL.GenerateInsertStatements.sql"),
                        sqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@SchemaName", tableSchema);
                sqlCommand.Parameters.AddWithValue("@TableName", tableName);
                sqlCommand.Parameters.AddWithValue("@IdentityInsertEnabled", identityInsertEnabled);
                sqlCommand.Connection.Open();
                return sqlCommand.ExecuteScalar() as string;
            }
        }
    }
}
