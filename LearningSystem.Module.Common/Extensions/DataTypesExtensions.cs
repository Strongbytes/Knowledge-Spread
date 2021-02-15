using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LearningSystem.Module.Common.Extensions
{
    public static class DataTypesExtensions
    {
        public static IEnumerable<Type> GetAllTypesImplementingOpenGenericType(this Type openGenericType)
        {
            return from assembly in AppDomain.CurrentDomain.GetAssemblies()
                   from currentType in assembly.GetTypes()
                   from currentInterface in currentType.GetInterfaces()
                   let baseType = currentType.BaseType
                   where baseType != null && baseType.IsGenericType && openGenericType.IsAssignableFrom(baseType.GetGenericTypeDefinition())
                      || currentInterface.IsGenericType && openGenericType.IsAssignableFrom(currentInterface.GetGenericTypeDefinition())
                   select currentType;
        }

        public static bool TryParseJson<T>(this string input, out T result)
        {
            bool success = true;

            var settings = new JsonSerializerSettings
            {
                Error = (sender, args) => { success = false; args.ErrorContext.Handled = true; },
                MissingMemberHandling = MissingMemberHandling.Error
            };

            result = JsonConvert.DeserializeObject<T>(input, settings);
            return success;
        }
    }
}
