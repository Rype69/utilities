/*
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SqlTable.cs" company="Inspire IT Ltd">
//   Copyright © Inspire IT Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Data.SqlClient
{
    /// <summary>
    /// Provides utility functions relating to SQL database tables
    /// </summary>
    public static class SqlTable
    {
        /// <summary>
        /// Finds the names of the primary key columns of a specified table.
        /// </summary>
        /// <param name="connectionString">The connection string to a database.</param>
        /// <param name="tableName">The name of a table to find primary keys for.</param>
        /// <param name="tableSchema">The schema of the table to find primary keys for.</param>
        /// <returns>A set of strings.</returns>
        public static System.Collections.Generic.IEnumerable<string> GetPrimaryKeyColumnNames(string connectionString, string tableName, string tableSchema)
        {
            // NULL-check connectionString
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new System.ArgumentNullException(nameof(connectionString));
            }

            // NULL-check tableName
            if (string.IsNullOrWhiteSpace(tableName))
            {
                throw new System.ArgumentNullException(nameof(tableName));
            }

            // NULL-check tableSchema
            if (string.IsNullOrWhiteSpace(tableSchema))
            {
                throw new System.ArgumentNullException(nameof(tableSchema));
            }

            var commandText = new System.Text.StringBuilder();
            commandText.AppendLine("SELECT");
            commandText.AppendLine("	INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE.Column_Name");
            commandText.AppendLine("FROM ");
            commandText.AppendLine("    INFORMATION_SCHEMA.TABLE_CONSTRAINTS, ");
            commandText.AppendLine("    INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE ");
            commandText.AppendLine("WHERE ");
            commandText.AppendLine("    INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE.Constraint_Name = INFORMATION_SCHEMA.TABLE_CONSTRAINTS.Constraint_Name");
            commandText.AppendLine("    AND");
            commandText.AppendLine("    INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE.Table_Name = INFORMATION_SCHEMA.TABLE_CONSTRAINTS.Table_Name");
            commandText.AppendLine("    AND");
            commandText.AppendLine("    INFORMATION_SCHEMA.TABLE_CONSTRAINTS.Constraint_Type = 'PRIMARY KEY'");
            commandText.AppendLine("    AND");
            commandText.AppendLine("    INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE.Table_Name = @TableName");
            commandText.AppendLine("    AND");
            commandText.AppendLine("    INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE.Table_Schema = @TableSchema;");

            var results = new System.Collections.Generic.List<string>();
            using (var connection = new System.Data.SqlClient.SqlConnection(connectionString))
            using (var command = new System.Data.SqlClient.SqlCommand(commandText.ToString(), connection))
            {
                command.Parameters.AddWithValue("@TableName", tableName);
                command.Parameters.AddWithValue("@TableSchema", tableSchema);
                command.Connection.Open();
                using (var reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    try
                    {
                        while (reader.Read())
                        {
                            if (reader["Column_Name"] != null && reader["Column_Name"] != System.DBNull.Value)
                            {
                                results.Add(reader["Column_Name"].ToString());
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