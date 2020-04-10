using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace WHampson.PigeonLocator.Extensions
{
    public static class EnumExtensions
    {
        public static T GetAttribute<T>(this Enum e) where T : Attribute
        {
            if (e == null) {
                return null;
            }

            MemberInfo[] m = e.GetType().GetMember(e.ToString());
            if (m.Count() == 0) {
                return null;
            }

            return (T) Attribute.GetCustomAttribute(m[0], typeof(T));
        }

        public static string GetDescription(this Enum value)
        {
            DescriptionAttribute descAttr = GetAttribute<DescriptionAttribute>(value);
            if (descAttr == null) {
                return value.ToString();
            }

            return descAttr.Description;
        }
    }
}
