
namespace iTin.Charting.Models.ComponentModel
{
    using System;
    using System.Collections;
    using System.Reflection;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// Please see https://gist.github.com/ejsmith/4d60f03d1f1d756c26a9
    /// </summary>
    internal class EmptyCollectionContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            Predicate<object> shouldSerialize = property.ShouldSerialize;
            property.ShouldSerialize = obj => (shouldSerialize == null || shouldSerialize(obj)) && !IsEmptyCollection(property, obj);
            return property;
        }

        private static bool IsEmptyCollection(JsonProperty property, object target)
        {
            var value = property.ValueProvider.GetValue(target);
            var collection = value as ICollection;
            if (collection != null && collection.Count == 0)
            {
                return true;
            }

            if (!typeof(IEnumerable).IsAssignableFrom(property.PropertyType))
            {
                return false;
            }

            var countProp = property.PropertyType.GetProperty("Count");
            if (countProp == null)
            {
                return false;
            }

            var count = (int)countProp.GetValue(value, null);
            return count == 0;
        }
    }
}
