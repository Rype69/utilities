// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ControlTypeAttribute.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities.Attributes
{
    /// <summary>
    /// An attribute that defines the distinct type of a control.
    /// </summary>
    public class ControlTypeAttribute : System.Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ControlTypeAttribute"/> class.
        /// </summary>
        /// <param name="typeName">
        /// The type name.
        /// </param>
        public ControlTypeAttribute(string typeName)
        {
            this.TypeName = typeName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ControlTypeAttribute"/> class.
        /// </summary>
        /// <param name="typeName">
        /// The type name.
        /// </param>
        /// <param name="readOnly">
        /// The read only.
        /// </param>
        public ControlTypeAttribute(string typeName, bool readOnly)
        {
            this.TypeName = typeName;
            this.ReadOnly = readOnly;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ControlTypeAttribute"/> class.
        /// </summary>
        /// <param name="typeName">
        /// The type name.
        /// </param>
        /// <param name="readOnly">
        /// The read only.
        /// </param>
        /// <param name="htmlEncode">
        /// The html encode.
        /// </param>
        public ControlTypeAttribute(string typeName, bool readOnly, bool htmlEncode)
        {
            this.TypeName = typeName;
            this.ReadOnly = readOnly;
            this.HtmlEncode = htmlEncode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ControlTypeAttribute"/> class.
        /// </summary>
        /// <param name="typeName">
        /// The type name.
        /// </param>
        /// <param name="dataSourceType">
        /// The data source type.
        /// </param>
        /// <param name="dataTextField">
        /// The data text field.
        /// </param>
        /// <param name="dataValueField">
        /// The data value field.
        /// </param>
        public ControlTypeAttribute(string typeName, System.Type dataSourceType, string dataTextField, string dataValueField)
        {
            this.TypeName = typeName;
            this.DataSourceType = dataSourceType;
            this.DataTextField = dataTextField;
            this.DataValueField = dataValueField;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ControlTypeAttribute"/> class.
        /// </summary>
        /// <param name="typeName">
        /// The type name.
        /// </param>
        /// <param name="dataSourceType">
        /// The data source type.
        /// </param>
        /// <param name="dataTextField">
        /// The data text field.
        /// </param>
        /// <param name="dataValueField">
        /// The data value field.
        /// </param>
        /// <param name="readOnly">
        /// The read only.
        /// </param>
        public ControlTypeAttribute(string typeName, System.Type dataSourceType, string dataTextField, string dataValueField, bool readOnly)
        {
            this.TypeName = typeName;
            this.DataSourceType = dataSourceType;
            this.DataTextField = dataTextField;
            this.DataValueField = dataValueField;
            this.ReadOnly = readOnly;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ControlTypeAttribute"/> class.
        /// </summary>
        /// <param name="typeName">
        /// The type name.
        /// </param>
        /// <param name="dataSourceType">
        /// The data source type.
        /// </param>
        /// <param name="dataTextField">
        /// The data text field.
        /// </param>
        /// <param name="dataValueField">
        /// The data value field.
        /// </param>
        /// <param name="readOnly">
        /// The read only.
        /// </param>
        /// <param name="autoPostBack">
        /// The auto post back.
        /// </param>
        public ControlTypeAttribute(string typeName, System.Type dataSourceType, string dataTextField, string dataValueField, bool readOnly, bool autoPostBack)
        {
            this.TypeName = typeName;
            this.DataSourceType = dataSourceType;
            this.DataTextField = dataTextField;
            this.DataValueField = dataValueField;
            this.ReadOnly = readOnly;
            this.AutoPostBack = autoPostBack;
        }

        /// <summary>
        /// Gets or sets a value indicating whether AutoPostBack is active.
        /// </summary>
        public bool AutoPostBack { get; set; }

        /// <summary>
        /// Gets or sets the DataSourceType.
        /// </summary>
        public System.Type DataSourceType { get; set; }

        /// <summary>
        /// Gets or sets the DataTextField.
        /// </summary>
        public string DataTextField { get; set; }

        /// <summary>
        /// Gets or sets the DataValueField.
        /// </summary>
        public string DataValueField { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the control is ReadOnly.
        /// </summary>
        public bool ReadOnly { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether HtmlEncode is active.
        /// </summary>
        public bool HtmlEncode { get; set; }

        /// <summary>
        /// Gets or sets the TypeName.
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        /// Gets the default type name.
        /// </summary>
        /// <param name="dataType">
        /// The data type.
        /// </param>
        /// <returns>
        /// The default type name.
        /// </returns>
        public static string GetDefaultTypeName(System.Type dataType)
        {
            string result;
            switch (dataType.FullName)
            {
                case "System.Boolean":
                    result = "CheckBox";
                    break;
                case "System.Date":
                case "System.Char":
                case "System.String":
                case "System.Decimal":
                case "System.Byte":
                case "System.Short":
                case "System.Integer":
                case "System.Long":
                case "System.Single":
                case "System.Double":
                    result = "TextBox";
                    break;
                default:
                    result = "TextBox";
                    break;
            }

            return result;
        }
    }
}
