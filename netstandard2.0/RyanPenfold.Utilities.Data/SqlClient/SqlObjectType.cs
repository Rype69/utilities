// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SqlObjectType.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Data.SqlClient
{
    /// <summary>
    /// Denotes a type of SQL object.
    /// </summary>
    public enum SqlObjectType
    {
        /// <summary>
        /// Invalid, default value.
        /// </summary>
        Invalid = 0,

        /// <summary>
        /// Denotes a SQL stored procedure.
        /// </summary>
        StoredProcedure = 1,

        /// <summary>
        /// Denotes a SQL table.
        /// </summary>
        Table = 2,

        /// <summary>
        /// Denotes a SQL table valued function.
        /// </summary>
        TableValuedFunction = 3,

        /// <summary>
        /// Denotes a SQL view.
        /// </summary>
        View = 4
    }
}
