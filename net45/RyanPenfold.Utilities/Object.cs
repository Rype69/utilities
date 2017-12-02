// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Object.cs" company="Ryan Penfold">
//   Copyright © Ryan Penfold. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace RyanPenfold.Utilities
{
    using System.Linq;

    /// <summary>
    /// Provides methods performed on the System.Object type.
    /// </summary>
    public static class Object
    {
        /// <summary>
        /// Clones an object.
        /// </summary>
        /// <typeparam name="T">
        /// The return type
        /// </typeparam>
        /// <param name="source">
        /// The source object to clone.
        /// </param>
        /// <returns>
        /// Returns a cloned object.
        /// </returns>
        public static object Clone<T>(this object source)
        {
            object result = null;

            var typeName = typeof(T).AssemblyQualifiedName;

            string assemblyName = null;
            if (typeName != null)
            {
                var commaId = typeName.IndexOf(",", System.StringComparison.Ordinal);

                if (commaId > -1)
                {
                    typeName = typeName.Substring(0, commaId);
                }

                var dotId = typeName.LastIndexOf(".", System.StringComparison.Ordinal);

                if (dotId > -1)
                {
                    assemblyName = typeName.Substring(0, dotId);
                }
            }

            if (assemblyName != null)
            {
                result = System.Reflection.Assembly.Load(assemblyName).CreateInstance(typeName);
            }

            // Fields
            foreach (var field in source.GetType().GetFields())
            {
                if (field == null)
                {
                }
                else
                {
                    try
                    {
                        result?.GetType().InvokeMember(
                            field.Name,
                            System.Reflection.BindingFlags.SetField,
                            null,
                            result,
                            new[] { source.GetType().GetField(field.Name).GetValue(source) });
                    }
                    catch (System.MissingFieldException)
                    {
                    }
                    catch (System.MissingMethodException)
                    {
                    }
                }
            }

            // Properties
            foreach (var prop in
                source.GetType().GetProperties().Where(prop => (prop != null) && prop.CanWrite))
            {
                try
                {
                    result?.GetType().InvokeMember(
                        prop.Name,
                        System.Reflection.BindingFlags.SetProperty,
                        null,
                        result,
                        new[] { source.GetType().GetProperty(prop.Name).GetValue(source, null) });
                }
                catch (System.MissingFieldException)
                {
                }
                catch (System.MissingMethodException)
                {
                }
            }

            return result;
        }

        /// <summary>
        /// Copies the field and property values from one instance to another.
        /// </summary>
        /// <typeparam name="T">
        /// The type of object to copy.
        /// </typeparam>
        /// <param name="destination">
        /// The destination object to copy field and property values to.
        /// </param>
        /// <param name="source">
        /// The source object to copy the field and property values from.
        /// </param>
        public static void CopyFrom<T>(this object destination, T source)
        {
            // NULL-check the destination
            if (destination == null)
            {
                throw new System.ArgumentNullException(nameof(destination));
            }

            // NULL-check the source
            if (source == null)
            {
                throw new System.ArgumentNullException(nameof(source));
            }

            // Copy all field values
            foreach (var sourceField in typeof(T).GetFields())
            {
                sourceField.SetValue(destination, sourceField.GetValue(source));

                var destinationField = destination.GetType().GetField(sourceField.Name);
                if (destinationField != null)
                {
                    var destinationType = System.Nullable.GetUnderlyingType(destinationField.FieldType) ?? destinationField.FieldType;
                    destinationField.SetValue(destination,
                        System.Convert.ChangeType(sourceField.GetValue(source), destinationType));
                }
            }

            // Copy all property values
            foreach (var sourceProperty in typeof(T).GetProperties().Where(p => p.CanRead))
            {
                var destinationProperty = destination.GetType().GetProperty(sourceProperty.Name);
                if (destinationProperty != null && destinationProperty.CanWrite)
                {
                    var destinationType = System.Nullable.GetUnderlyingType(destinationProperty.PropertyType) ?? destinationProperty.PropertyType;
                    destinationProperty.SetValue(destination, 
                        System.Convert.ChangeType(sourceProperty.GetValue(source), destinationType));
                }
            }
        }

        /// <summary>
        /// Determines whether the specified object instances are considered equal.
        /// </summary>
        /// <param name="objA">The first object to compare.</param>
        /// <param name="objB">The second object to compare.</param>
        /// <returns>true if the objects are considered equal; otherwise, false. If both objA and objB are null, the method returns true.</returns>
        public static new bool Equals(object objA, object objB)
        {
            if (objA == null && objB == null)
            {
                return true;
            }

            if ((objA == null && objB != null) || (objA != null && objB == null))
            {
                return false;
            }

            var result = true;

            foreach (var field in objA.GetType().GetFields())
            {
                result = result && Equals(field.GetValue(objA), field.GetValue(objB));
            }

            foreach (var property in objA.GetType().GetProperties())
            {
                result = result && Equals(property.GetValue(objA, null), property.GetValue(objB, null));
            }

            return result;
        }

        /// <summary>
        /// Generates and returns a hash code for an instance.
        /// </summary>
        /// <param name="obj">An instance to determine a hash code for.</param>
        /// <returns>An <see cref="int"/>.</returns>
        public static int GetHashCode(object obj)
        {
            // NULL-check the object
            if (obj == null)
            {
                throw new System.ArgumentNullException(nameof(obj));
            }

            // Return the sum of all the numeric codes of the characters in the string form of the instance.
            return ToString(obj).ToCharArray().Aggregate(0, (current, c) => current + c);
        }

        /// <summary>
        /// NULL-checks an object and attempts to get the value of the specified member
        /// </summary>
        /// <param name="obj">The object to get a member value of</param>
        /// <param name="memberName">The name of the member</param>
        /// <returns>null if the object is null, or the value of the specified member</returns>
        public static object GetMemberValue(this object obj, string memberName)
        {
            // Determine whether the subject of the operation is null.
            if (obj == null)
            {
                return null;
            }

            // NULL-check fieldName
            if (string.IsNullOrWhiteSpace(memberName))
            {
                throw new System.ArgumentNullException(nameof(memberName));
            }

            // The result of the method
            object result = null;

            // Attempt to find a property with the matching name
            var propertyInfo = obj.GetType().GetProperty(memberName);

            // NULL-check the property
            if (propertyInfo != null)
            {
                // Attempt to get the property value
                result = propertyInfo.GetValue(obj);
            }
            else
            {
                // Attempt to find a field with the matching name
                var fieldInfo = obj.GetType().GetField(memberName);

                // NULL-check the field
                if (fieldInfo != null)
                {
                    // Attempt to get the field value
                    result = fieldInfo.GetValue(obj);
                }
            }

            // Return the result
            return result;
        }

        /// <summary>
        /// Checks an object to see if it is null or clear of data.
        /// </summary>
        /// <param name="value">
        /// The object to check.
        /// </param>
        /// <returns>
        /// A boolean value that determines whether an object is null or clear of data.
        /// </returns>
        public static bool IsNullOrEmpty(object value)
        {
            var result = true;

            if (value != null)
            {
                foreach (var prop in value.GetType().GetProperties())
                {
                    var propValueIsNothing = true;

                    var objPropValue = prop.GetValue(value, null);

                    if (objPropValue == null)
                    {
                        continue;
                    }

                    switch (objPropValue.GetType().Name)
                    {
                        case "Int16":
                        case "Int32":
                        case "Int64":
                        case "Byte":
                        case "Short":
                        case "Integer":
                        case "Long":
                            propValueIsNothing = System.Convert.ToInt64(objPropValue) == 0;
                            break;
                        case "Date":
                        case "DateTime":
                            propValueIsNothing = System.Convert.ToDateTime(objPropValue) == System.DateTime.MinValue;
                            break;
                        case "Boolean":
                            propValueIsNothing = System.Convert.ToBoolean(objPropValue) == false;
                            break;
                        case "Char":
                            propValueIsNothing = objPropValue.ToString() == "\0";
                            break;
                        case "Decimal":
                        case "Single":
                        case "Double":
                            propValueIsNothing = System.Convert.ToInt64(objPropValue) == 0;
                            break;
                        case "String":
                            propValueIsNothing = string.IsNullOrEmpty(System.Convert.ToString(objPropValue));
                            break;
                    }

                    if (propValueIsNothing)
                    {
                        continue;
                    }

                    result = false;

                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// Converts an instance of <see cref="T"/> a <see cref="string"/>.
        /// </summary>
        /// <param name="obj">
        /// An object to parse to <see cref="string"/>
        /// </param>
        /// <returns>A <see cref="string"/>.</returns>
        public static string ToString<T>(T obj)
        {
            // NULL-check the object
            if (obj == null)
            {
                throw new System.ArgumentNullException(nameof(obj));
            }

            // If the input is of type string, return it.
            if (obj is string)
            {
                return $"\"{obj}\"";
            }

            // Result object
            var result = new System.Text.StringBuilder();

            var properties = typeof(T).GetProperties().Where(p => p != null).ToList();
            if (properties.Any(p => p != null))
            {
                result.Append("{");
            }
            else
            {
                return $"\"{obj}\"";
            }

            // Loop through each of the properties
            for (var propertyId = 0; propertyId < properties.Count; propertyId++)
            {
                var propertyInfo = properties[propertyId];

                var value = propertyInfo.GetValue(obj);
                if (value == null || value == System.DBNull.Value)
                {
                    continue;
                }

                var stringValue = ToString(value);
                if (string.IsNullOrWhiteSpace(stringValue))
                {
                    continue;
                }

                var lines = stringValue.Split(new[] { "\r\n" }, System.StringSplitOptions.RemoveEmptyEntries);

                if (lines.All(string.IsNullOrWhiteSpace))
                {
                    continue;
                }

                var lineCount = lines.Count();

                result.Append($"\r\n\t{propertyInfo.Name} : ");

                foreach (var line in lines)
                {
                    result.Append(lineCount == 1 ? line : $"\r\n\t{line}");
                }

                if (propertyId < properties.Count - 1)
                {
                    result.Append(",");
                }
            }

            // Append closing brace
            if (properties.Any(p => p != null))
            {
                result.Append("\n}");
            }

            // Return result
            return result.ToString();
        }
    }
}
