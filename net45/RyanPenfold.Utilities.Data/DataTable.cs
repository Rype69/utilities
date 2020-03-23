// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataTable.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Data
{
    /// <summary>
    /// Provides extension methods on <see cref="System.Data.DataTable"/> instances.
    /// </summary>
    public static class DataTable
    {
        /// <summary>
        /// Produces a HTML table string from a <see cref="System.Data.DataTable"/>.
        /// </summary>
        /// <param name="dataTable">
        /// A data Table to parse.
        /// </param>
        /// <param name="produceEntireDocument">
        /// When true, produces an entire HTML document.
        /// </param>
        /// <returns>
        /// A HTML table <see cref="string"/>.
        /// </returns>
        public static string ToHtmlTable(this System.Data.DataTable dataTable, bool produceEntireDocument = false)
        {
            if (dataTable == null)
            {
                return string.Empty;
            }

            var htmlBuilder = new System.Text.StringBuilder();

            if (produceEntireDocument)
            {
                htmlBuilder.AppendLine("<!DOCTYPE html>");
                htmlBuilder.AppendLine("<html>");
                htmlBuilder.AppendLine("\t<head lang=\"en\">");
                htmlBuilder.AppendLine("\t<meta charset=\"utf-8\"/>");
                htmlBuilder.AppendLine("\t<title>[Document Title]</title>");
                htmlBuilder.AppendLine("\t</head>");
                htmlBuilder.AppendLine("\t<body>");
            }

            htmlBuilder.AppendLine("\t\t<table>");
            htmlBuilder.AppendLine("\t\t\t<tr>");

            foreach (System.Data.DataColumn column in dataTable.Columns)
            {
                htmlBuilder.Append("\t\t\t\t<th>");
                htmlBuilder.Append(column.ColumnName);
                htmlBuilder.AppendLine("</th>");
            }

            htmlBuilder.AppendLine("\t\t\t</tr>");

            foreach (System.Data.DataRow row in dataTable.Rows)
            {
                htmlBuilder.AppendLine("\t\t\t<tr>");

                foreach (var item in row.ItemArray)
                {
                    htmlBuilder.Append("\t\t\t\t<td>");
                    var value = item == null || item is System.DBNull 
                        ? "NULL"
                        : item.ToString();

                    htmlBuilder.Append(value);
                    htmlBuilder.AppendLine("</td>");
                }

                htmlBuilder.AppendLine("\t\t\t</tr>");
            }

            htmlBuilder.AppendLine("\t\t</table>");

            if (produceEntireDocument)
            {
                htmlBuilder.AppendLine("\t</body>");
                htmlBuilder.AppendLine("</html>");
            }

            return htmlBuilder.ToString();
        }
    }
}
