using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ReadFileEdiXML.Libraries
{
    public class ShouldSerializeContractResolver : DefaultContractResolver
    {
        public static readonly ShouldSerializeContractResolver Instance = new ShouldSerializeContractResolver();

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            if (property.PropertyType == typeof(string))
            {
                // Do not include emptry strings
                property.ShouldSerialize = instance =>
                {
                    return !string.IsNullOrWhiteSpace(instance.GetType().GetProperty(member.Name).GetValue(instance, null) as string);
                };
            }
            else if (property.PropertyType == typeof(DateTime))
            {
                // Do not include zero DateTime
                property.ShouldSerialize = instance =>
                {
                    return Convert.ToDateTime(instance.GetType().GetProperty(member.Name).GetValue(instance, null)) != default(DateTime);
                };
            }
            else if (typeof(IEnumerable).IsAssignableFrom(property.PropertyType))
            {
                // Do not include zero-length lists
                switch (member.MemberType)
                {
                    case MemberTypes.Property:
                        property.ShouldSerialize = instance =>
                        {
                            var enumerable = instance.GetType().GetProperty(member.Name).GetValue(instance, null) as IEnumerable;
                            return enumerable != null ? enumerable.GetEnumerator().MoveNext() : false;
                        };
                        break;

                    case MemberTypes.Field:
                        property.ShouldSerialize = instance =>
                        {
                            var enumerable = instance.GetType().GetField(member.Name).GetValue(instance) as IEnumerable;
                            return enumerable != null ? enumerable.GetEnumerator().MoveNext() : false;
                        };
                        break;
                }
            }
            else
            {
                property.ShouldSerialize = instance =>
                {
                    bool IsNOTSerialize = true;

                    var _obj = instance.GetType().GetProperty(member.Name).GetValue(instance, null);
                    if (_obj != null)
                    {
                        foreach (var prop in _obj.GetType().GetProperties())
                        {
                            var _val = prop.GetValue(_obj, null);

                            if (_val != null)
                            {
                                if (_val.GetType() == typeof(string))
                                {
                                    if (!string.IsNullOrWhiteSpace(_val as string))
                                        IsNOTSerialize = false;
                                }
                                else
                                    IsNOTSerialize = false;
                            }
                        }
                    }

                    return !IsNOTSerialize;
                };
            }
            return property;
        }
    }

    public class FilteredExpandoObjectConverter : ExpandoObjectConverter
    {
        public override bool CanWrite
        { get { return true; } }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var expando = (IDictionary<string, object>)value;
            var dictionary = expando
                .Where(p => !(p.Value == null || string.IsNullOrWhiteSpace(p.Value.ToString())))
                .ToDictionary(p => p.Key, p => p.Value);

            serializer.Serialize(writer, dictionary);
        }
    }

    public class ScheduleShouldSerializeContractResolver : DefaultContractResolver
    {
        public static readonly ScheduleShouldSerializeContractResolver Instance = new ScheduleShouldSerializeContractResolver();

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            if (property.PropertyType == typeof(string))
            {
                // Do not include emptry strings
                property.ShouldSerialize = instance =>
                {
                    return !string.IsNullOrWhiteSpace(instance.GetType().GetProperty(member.Name).GetValue(instance, null) as string);
                };
            }
            else if (property.PropertyType == typeof(DateTime))
            {
                // Do not include zero DateTime
                property.ShouldSerialize = instance =>
                {
                    return Convert.ToDateTime(instance.GetType().GetProperty(member.Name).GetValue(instance, null)) != default(DateTime);
                };
            }
            else
            {
                property.ShouldSerialize = instance =>
                {
                    if (property.PropertyType.Name.Contains("IList"))
                    {
                        return (property.ValueProvider.GetValue(instance) as dynamic).Count > 0;
                    }
                    return true;
                };
            }
            return property;
        }
    }
}