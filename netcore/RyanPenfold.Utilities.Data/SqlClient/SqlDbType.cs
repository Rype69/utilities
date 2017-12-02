// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SqlDbType.cs" company="Inspire IT Ltd">
//   Copyright © Inspire IT Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Data.SqlClient
{
    using System.Linq;

    /// <summary>
    /// Provides extension methods for the <see cref="System.Data.SqlDbType"/> type.
    /// </summary>
    public static class SqlDbType
    {
        /// <summary>
        /// Determines the appropriate <see cref="System.Data.SqlDbType"/> for a <see cref="System.Type"/> type.
        /// </summary>
        /// <param name="type">A CLR type to determine an appropriate <see cref="System.Data.SqlDbType"/> for.</param>
        /// <returns>The appropriate <see cref="System.Data.SqlDbType"/> for a CLR type.</returns>
        public static Data.SqlDbType FromClrType(this System.Type type)
        {
            Data.SqlDbType result;

            var typeName = type.FullName;
            var nullableTypePrefix = "System.Nullable`1[[";

            if (typeName.StartsWith(nullableTypePrefix) && typeName.Contains(","))
            {
                typeName = typeName.Split(new[] { ',' }, System.StringSplitOptions.RemoveEmptyEntries).First().Substring(nullableTypePrefix.Length);
            }

            switch (typeName)
            {
                case "Microsoft.SqlServer.Types.SqlGeography":
                    result = Data.SqlDbType.Geography;
                    break;
                case "Microsoft.SqlServer.Types.SqlGeometry":
                    result = Data.SqlDbType.Geometry;
                    break;
                case "Microsoft.SqlServer.Types.SqlHierarchyId":
                    result = Data.SqlDbType.HierarchyId;
                    break;
                case "System.Boolean":
                    result = Data.SqlDbType.Bit;
                    break;
                case "System.Byte":
                    result = Data.SqlDbType.TinyInt;
                    break;
                case "System.Byte[]":
                    result = Data.SqlDbType.VarBinary;
                    break;
                case "System.Char":
                    result = Data.SqlDbType.Char;
                    break;
                case "Data.SqlTypes.SqlXml":
                    result = Data.SqlDbType.Xml;
                    break;
                case "System.DateTime":
                    result = Data.SqlDbType.DateTime2;
                    break;
                case "System.DateTimeOffset":
                    result = Data.SqlDbType.DateTimeOffset;
                    break;
                case "System.Decimal":
                    result = Data.SqlDbType.Decimal;
                    break;
                case "System.Double":
                    result = Data.SqlDbType.Float;
                    break;
                case "System.Guid":
                    result = Data.SqlDbType.UniqueIdentifier;
                    break;
                case "System.Int16":
                    result = Data.SqlDbType.SmallInt;
                    break;
                case "System.Int32":
                    result = Data.SqlDbType.Int;
                    break;
                case "System.Int64":
                    result = Data.SqlDbType.BigInt;
                    break;
                case "System.Object":
                    result = Data.SqlDbType.Udt;
                    break;
                case "System.Single":
                    result = Data.SqlDbType.Real;
                    break;
                case "System.String":
                    result = Data.SqlDbType.NVarChar;
                    break;
                case "System.TimeSpan":
                    result = Data.SqlDbType.Time;
                    break;
                default:
                    result = Data.SqlDbType.Variant;
                    break;
            }

            return result;
        }

                /*

        /// <summary>
        /// Determines the appropriate CLR type for a <see cref="System.Data.SqlDbType"/> type.
        /// </summary>
        /// <param name="sqlDbType">A <see cref="System.Data.SqlDbType"/> type to determine an appropriate CLR type for.</param>
        /// <returns>The appropriate CLR type for a <see cref="System.Data.SqlDbType"/> type.</returns>
        public static System.Type ToClrType(this System.Data.SqlDbType sqlDbType)
        {
            System.Type result = null;

            switch (sqlDbType)
            {
                case System.Data.SqlDbType.BigInt:
                    result = typeof(long);
                    break;
                case System.Data.SqlDbType.Binary:
                    result = typeof(byte[]);
                    break;
                case System.Data.SqlDbType.Bit:
                    result = typeof(bool);
                    break;
                case System.Data.SqlDbType.Char:
                    result = typeof(char);
                    break;
                case System.Data.SqlDbType.Date:
                    result = typeof(System.DateTime);
                    break;
                case System.Data.SqlDbType.DateTime:
                    result = typeof(System.DateTime);
                    break;
                case System.Data.SqlDbType.DateTime2:
                    result = typeof(System.DateTime);
                    break;
                case System.Data.SqlDbType.DateTimeOffset:
                    result = typeof(System.DateTimeOffset);
                    break;
                case System.Data.SqlDbType.Decimal:
                    result = typeof(decimal);
                    break;
                case System.Data.SqlDbType.Float:
                    result = typeof(double);
                    break;
                case System.Data.SqlDbType.Image:
                    result = typeof(byte[]);
                    break;
                case System.Data.SqlDbType.Int:
                    result = typeof(int);
                    break;
                case System.Data.SqlDbType.Money:
                    result = typeof(decimal);
                    break;
                case System.Data.SqlDbType.NChar:
                    result = typeof(string);
                    break;
                case System.Data.SqlDbType.NText:
                    result = typeof(string);
                    break;
                case System.Data.SqlDbType.NVarChar:
                    result = typeof(string);
                    break;
                case System.Data.SqlDbType.Real:
                    result = typeof(float);
                    break;
                case System.Data.SqlDbType.SmallDateTime:
                    result = typeof(System.DateTime);
                    break;
                case System.Data.SqlDbType.SmallInt:
                    result = typeof(short);
                    break;
                case System.Data.SqlDbType.SmallMoney:
                    result = typeof(decimal);
                    break;
                case System.Data.SqlDbType.Structured:
                    result = typeof(object);
                    break;
                case System.Data.SqlDbType.Text:
                    result = typeof(string);
                    break;
                case System.Data.SqlDbType.Time:
                    result = typeof(System.TimeSpan);
                    break;
                case System.Data.SqlDbType.Timestamp:
                    result = typeof(byte[]);
                    break;
                case System.Data.SqlDbType.TinyInt:
                    result = typeof(byte);
                    break;
                case System.Data.SqlDbType.Udt:
                    result = typeof(object);
                    break;
                case System.Data.SqlDbType.UniqueIdentifier:
                    result = typeof(System.Guid);
                    break;
                case System.Data.SqlDbType.VarBinary:
                    result = typeof(byte[]);
                    break;
                case System.Data.SqlDbType.VarChar:
                    result = typeof(string);
                    break;
                case System.Data.SqlDbType.Variant:
                    result = typeof(string);
                    break;
                case System.Data.SqlDbType.Xml:
                    result = typeof(System.Data.SqlTypes.SqlXml);
                    break;
            }

            return result;
        } */

        /// <summary>
        /// Determines the appropriate <see cref="System.Data.SqlDbType"/> for a <see cref="System.Type"/> type, and converts it to a <see cref="string"/>.
        /// </summary>
        /// <param name="type">A CLR type to determine an appropriate <see cref="System.Data.SqlDbType"/> for.</param>
        /// <param name="binaryLength">The length of any binary columns. Setting for binaryLength must be from 1 to 8000.</param>
        /// <param name="charLength">The length of any char columns. Setting for charLength must be from 1 to 8000.</param>
        /// <param name="datetime2Scale">The scale of any datetime2 columns. Setting for datetime2Scale must be from 0 to 7.</param>
        /// <param name="datetimeoffsetScale">The scale of any datetimeoffset columns. Setting for datetimeoffsetScale must be from 0 to 7.</param>
        /// <param name="decimalPrecision">The precision of any decimal columns. Setting for decimalPrecision must be from 1 to 38.</param>
        /// <param name="decimalScale">The scale of any decimal columns. Setting for decimalScale must be from 0 to 38.</param>
        /// <param name="ncharLength">The scale of any nchar columns. Setting for ncharLength must be from 1 to 4000.</param>
        /// <param name="numericPrecision">The scale of any numeric columns. Setting for numericPrecision must be from 1 to 38.</param>
        /// <param name="numericScale">The scale of any numeric columns. Setting for numericScale must be from 0 to 38.</param>
        /// <param name="nvarcharLength">The scale of any nvarchar columns. Setting for nvarcharLength must be from 1 to 4000.</param>
        /// <param name="timeScale">The scale of any time columns. Setting for timeScale must be from 0 to 7.</param>
        /// <param name="varbinaryLength">The scale of any varbinary columns. Setting for varbinaryLength must be from 1 to 8000.</param>
        /// <param name="varcharLength">The scale of any varchar columns. Setting for varcharLength must be from 1 to 8000.</param>
        /// <returns>The appropriate <see cref="System.Data.SqlDbType"/> for a CLR type as a <see cref="string"/>.</returns>
        public static string ToSqlDbTypeSqlString(
            this System.Type type, 
            short binaryLength = 50,
            short charLength = 10,
            byte datetime2Scale = 7,
            byte datetimeoffsetScale = 7,
            byte decimalPrecision = 18,
            byte decimalScale = 0,
            short ncharLength = 10,
            byte numericPrecision = 18,
            byte numericScale = 0,
            short? nvarcharLength = null,
            byte timeScale = 7,
            short? varbinaryLength = null,
            short? varcharLength = null)
        {
            if (type == null)
            {
                throw new System.ArgumentNullException(nameof(type));
            }

            if (binaryLength < 1 || binaryLength > 8000)
            {
                throw new System.ArgumentOutOfRangeException(nameof(binaryLength), "Setting for binaryLength must be from 1 to 8000.");
            }

            if (charLength < 1 || charLength > 8000)
            {
                throw new System.ArgumentOutOfRangeException(nameof(charLength), "Setting for charLength must be from 1 to 8000.");
            }

            if (datetime2Scale > 7)
            {
                throw new System.ArgumentOutOfRangeException(nameof(datetime2Scale), "Setting for datetime2Scale must be from 0 to 7.");
            }

            if (datetimeoffsetScale > 7)
            {
                throw new System.ArgumentOutOfRangeException(nameof(datetimeoffsetScale), "Setting for datetimeoffsetScale must be from 0 to 7.");
            }

            if (decimalPrecision < 1 || decimalPrecision > 38)
            {
                throw new System.ArgumentOutOfRangeException(nameof(decimalPrecision), "Setting for decimalPrecision must be from 1 to 38.");
            }

            if (decimalScale > 38)
            {
                throw new System.ArgumentOutOfRangeException(nameof(decimalScale), "Setting for decimalScale must be from 0 to 38.");
            }

            if (ncharLength < 1 || ncharLength > 4000)
            {
                throw new System.ArgumentOutOfRangeException(nameof(ncharLength), "Setting for ncharLength must be from 1 to 4000.");
            }

            if (numericPrecision < 1 || numericPrecision > 38)
            {
                throw new System.ArgumentOutOfRangeException(nameof(numericPrecision), "Setting for numericPrecision must be from 1 to 38.");
            }

            if (numericScale > 38)
            {
                throw new System.ArgumentOutOfRangeException(nameof(numericScale), "Setting for numericScale must be from 0 to 38.");
            }

            if (nvarcharLength < 1 || nvarcharLength > 4000)
            {
                throw new System.ArgumentOutOfRangeException(nameof(nvarcharLength), "Setting for nvarcharLength must be from 1 to 4000.");
            }

            if (timeScale > 7)
            {
                throw new System.ArgumentOutOfRangeException(nameof(timeScale), "Setting for timeScale must be from 1 to 4000.");
            }

            if (varbinaryLength < 1 || varbinaryLength > 8000)
            {
                throw new System.ArgumentOutOfRangeException(nameof(varbinaryLength), "Setting for varbinaryLength must be from 1 to 8000.");
            }

            if (varcharLength < 1 || varcharLength > 8000)
            {
                throw new System.ArgumentOutOfRangeException(nameof(varcharLength), "Setting for varcharLength must be from 1 to 8000.");
            }

            var result = "NVARCHAR(MAX)";

            var sqlDbType = FromClrType(type);

            switch (sqlDbType)
            {
                case Data.SqlDbType.BigInt:
                    result = "BIGINT";
                    break;
                case Data.SqlDbType.Binary:
                    result = $"BINARY({binaryLength})";
                    break;
                case Data.SqlDbType.Bit:
                    result = "BIT";
                    break;
                case Data.SqlDbType.Char:
                    result = $"CHAR({charLength})";
                    break;
                case Data.SqlDbType.Date:
                    result = "DATE";
                    break;
                case Data.SqlDbType.DateTime:
                    result = "DATETIME";
                    break;
                case Data.SqlDbType.DateTime2:
                    result = $"DATETIME2({datetime2Scale})";
                    break;
                case Data.SqlDbType.DateTimeOffset:
                    result = $"DATETIMEOFFSET({datetimeoffsetScale})";
                    break;
                case Data.SqlDbType.Decimal:
                    result = $"DECIMAL({decimalPrecision},{decimalScale})";
                    break;
                case Data.SqlDbType.Float:
                    result = "FLOAT";
                    break;
                case Data.SqlDbType.Geography:
                    result = "GEOGRAPHY";
                    break;
                case Data.SqlDbType.Geometry:
                    result = "GEOMETRY";
                    break;
                case Data.SqlDbType.HierarchyId:
                    result = "HIERARCHYID";
                    break;
                case Data.SqlDbType.Image:
                    result = "IMAGE";
                    break;
                case Data.SqlDbType.Int:
                    result = "INT";
                    break;
                case Data.SqlDbType.Money:
                    result = "MONEY";
                    break;
                case Data.SqlDbType.NChar:
                    result = $"NCHAR({ncharLength})";
                    break;
                case Data.SqlDbType.NText:
                    result = "NTEXT";
                    break;
                case Data.SqlDbType.NVarChar:
                    result = nvarcharLength.HasValue ? $"NVARCHAR({nvarcharLength.Value})" : "NVARCHAR(MAX)";
                    break;
                case Data.SqlDbType.Real:
                    result = "REAL";
                    break;
                case Data.SqlDbType.SmallDateTime:
                    result = "SMALLDATETIME";
                    break;
                case Data.SqlDbType.SmallInt:
                    result = "SMALLINT";
                    break;
                case Data.SqlDbType.SmallMoney:
                    result = "SMALLMONEY";
                    break;
                case Data.SqlDbType.Structured:
                    result = "STRUCTURED";
                    break;
                case Data.SqlDbType.Text:
                    result = "TEXT";
                    break;
                case Data.SqlDbType.Time:
                    result = $"TIME({timeScale})";
                    break;
                case Data.SqlDbType.Timestamp:
                    result = "TIMESTAMP";
                    break;
                case Data.SqlDbType.TinyInt:
                    result = "TINYINT";
                    break;
                case Data.SqlDbType.Udt:
                    result = "UDT";
                    break;
                case Data.SqlDbType.UniqueIdentifier:
                    result = "UNIQUEIDENTIFIER";
                    break;
                case Data.SqlDbType.VarBinary:
                    result = varbinaryLength.HasValue ? $"VARBINARY({varbinaryLength.Value})" : "VARBINARY(MAX)";
                    break;
                case Data.SqlDbType.VarChar:
                    result = varcharLength.HasValue ? $"VARCHAR({varcharLength.Value})" : "VARCHAR(MAX)";
                    break;
                case Data.SqlDbType.Variant:
                    result = "SQL_VARIANT";
                    break;
                case Data.SqlDbType.Xml:
                    result = "XML";
                    break;
            }

            return result;
        }
    }
}
