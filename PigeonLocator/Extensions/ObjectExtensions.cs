#region License
/* Copyright (c) 2018 W. Hampson
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */
#endregion

using System;
using System.Reflection;

namespace WHampson.PigeonLocator.Extensions
{
    /// <summary>
    /// Extensions to the <see cref="object"/> type.
    /// </summary>
    internal static class ObjectExtensions
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
        public static string GenerateToString(this object obj, string[] propertyNames)
        {
            if (obj == null) {
                return null;
            }

            string body = "";
            for (int i = 0; i < propertyNames.Length; i++) {
                string propName = propertyNames[i];
                object propVal = obj.GetPropertyValueByName(propName);
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
        public static object GetPropertyValueByName(this object obj, string propertyName)
        {
            if (obj == null || propertyName == null) {
                return null;
            }

            Type t = obj.GetType();
            PropertyInfo p = t.GetProperty(propertyName);   // TODO: binding flags?
            if (p == null) {
                return null;
            }

            return p.GetValue(obj, null);
        }
    }
}
