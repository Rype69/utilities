/*
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SqlFunctions.cs" company="Inspire IT Ltd">
//   Copyright © Inspire IT Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Data.SqlClient
{
    /// <summary>
    /// Runs SQL statements on SQL databases.
    /// </summary>
    public static class SqlFunctions
    {
        /// <summary>
        /// Finds the names of objects of a specified type in a database.
        /// </summary>
        /// <param name="connectionString">The connection string to a database.</param>
        /// <param name="includeStoredProcedures">Indicates whether to include stored procedures in the results.</param>
        /// <param name="includeTables">Indicates whether to include tables in the results.</param>
        /// <param name="includeTableValuedFunctions">Indicates whether to include table valued functions in the results.</param>
        /// <param name="includeViews">Indicates whether to include views in the results.</param>
        /// <returns>A set of <see cref="string"/> tuples containing the schema, name, and type of each of the database objects.</returns>
        public static System.Collections.Generic.IEnumerable<System.Tuple<string, string, string>> GetObjectNames(
            string connectionString,
            bool includeStoredProcedures = true,
            bool includeTables = true,
            bool includeTableValuedFunctions = true,
            bool includeViews = true)
        {
            // NULL-check connectionString
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new System.ArgumentNullException(nameof(connectionString));
            }

            if (!includeStoredProcedures && !includeTables && !includeTableValuedFunctions && !includeViews)
            {
                return System.Linq.Enumerable.Empty<System.Tuple<string, string, string>>();
            }

            var whereClauseBuilder = new System.Text.StringBuilder();
            if (includeStoredProcedures)
            {
                Text.StringBuilder.AppendWithDelimiter(whereClauseBuilder, "    [sys].[objects].[type] = 'P'", "\r\n    OR");
            }

            if (includeTables)
            {
                Text.StringBuilder.AppendWithDelimiter(whereClauseBuilder, "    [sys].[objects].[type] = 'U'", "\r\n    OR");
            }

            if (includeTableValuedFunctions)
            {
                Text.StringBuilder.AppendWithDelimiter(whereClauseBuilder, "    [sys].[objects].[type] = 'IF'", "\r\n    OR");
            }

            if (includeViews)
            {
                Text.StringBuilder.AppendWithDelimiter(whereClauseBuilder, "    [sys].[objects].[type] = 'V'", "\r\n    OR");
            }

            var commandText = new System.Text.StringBuilder();
            commandText.AppendLine("SELECT");
            commandText.AppendLine("	[sys].[schemas].[name] AS [schema]");
            commandText.AppendLine("   ,[sys].[objects].[name]");
            commandText.AppendLine("   ,[sys].[objects].[type]");
            commandText.AppendLine("   ,CASE [sys].[objects].[type]");
            commandText.AppendLine("		WHEN 'P' THEN 'Stored Procedure'");
            commandText.AppendLine("		WHEN 'U' THEN 'Table'");
            commandText.AppendLine("		WHEN 'IF' THEN 'Table-Valued Function'");
            commandText.AppendLine("		WHEN 'V' THEN 'View' END AS [TypeName]");
            commandText.AppendLine("FROM ");
            commandText.AppendLine("	[sys].[objects]");
            commandText.AppendLine("INNER JOIN");
            commandText.AppendLine("	[sys].[schemas]");
            commandText.AppendLine("	ON");
            commandText.AppendLine("	[sys].[objects].[schema_id] = [sys].[schemas].[schema_id]");
            commandText.AppendLine("WHERE");
            commandText.AppendLine(whereClauseBuilder.ToString());
            commandText.AppendLine("ORDER BY");
            commandText.AppendLine("    [TypeName]");
            commandText.AppendLine("   ,[schema]");
            commandText.AppendLine("   ,[sys].[objects].[name];");

            var results = new System.Collections.Generic.List<System.Tuple<string, string, string>>();
            using (var connection = new System.Data.SqlClient.SqlConnection(connectionString))
            using (var command = new System.Data.SqlClient.SqlCommand(commandText.ToString(), connection))
            {
                command.Connection.Open();
                using (var reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    try
                    {
                        while (reader.Read())
                        {
                            if (reader["schema"] != null && reader["schema"] != System.DBNull.Value &&
                                reader["name"] != null && reader["name"] != System.DBNull.Value &&
                                reader["type"] != null && reader["type"] != System.DBNull.Value)
                            {
                                results.Add(new System.Tuple<string, string, string>(reader["schema"].ToString(), reader["name"].ToString(), reader["type"].ToString()));
                            }
                        }
                    }
                    finally
                    {
                        command.Cancel();
                    }
                }
            }

            return results;
        }
    }
}
*/