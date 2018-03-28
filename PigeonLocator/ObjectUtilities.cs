using System;
using System.Reflection;

namespace WHampson.PigeonLocator
{
    /// <summary>
    /// Helper class for retrieving information about objects.
    /// </summary>
    internal static class ObjectUtilities
    {
        /// <summary>
        /// Creates a string representation of an object containing the names
        /// and values of the specified properties.
        /// </summary>
        /// <remarks>
        /// For a class 'Foo' containing the int properties 'Bar' and 'Baz',
        /// the generated string will be formatted as follows:
        ///     Foo: { Bar = 123; Baz = 456; }
        /// </remarks>
        /// <param name="obj">
        /// The object to generate a string representation of.
        /// </param>
        /// <param name="propertyNames">
        /// The properties to be included in the string representation.
        /// </param>
        /// <returns>
        /// A string representation of the object if not null.
        /// <c>null</c> if the given object is null.
        /// </returns>
        public static string GenerateToString(object obj, string[] propertyNames)
        {
            if (obj == null)
            {
                return null;
            }

            string body = "";
            for (int i = 0; i < propertyNames.Length; i++)
            {
                string propName = propertyNames[i];
                object propVal = GetPropertyValueByName(obj, propName);
                body += string.Format("{0} = {1}; ", propName, propVal);
            }
            body = body.Trim();

            return string.Format("{0}: {{ {1} }}", obj.GetType().Name, body);
        }

        /// <summary>
        /// Returns the value of the specified property for a given object.
        /// </summary>
        /// <param name="obj">
        /// The object to read the property from.
        /// </param>
        /// <param name="propertyName">
        /// The name of the property to get.
        /// </param>
        /// <returns>
        /// The property value.
        /// <c>null</c> if the object is null or does not contain a property with
        /// a matching property name.
        /// </returns>
        public static object GetPropertyValueByName(object obj, string propertyName)
        {
            if (obj == null || propertyName == null)
            {
                return null;
            }

            Type t = obj.GetType();
            PropertyInfo p = t.GetProperty(propertyName);   // TODO: binding flags?
            if (p == null)
            {
                return null;
            }

            return p.GetValue(obj, null);
        }
    }
}
