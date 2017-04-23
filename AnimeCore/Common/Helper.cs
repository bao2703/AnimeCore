using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Entities.Domain;
using Microsoft.AspNetCore.Mvc;

namespace AnimeCore.Common
{
    public class Helper
    {
        public static IEnumerable<List<T>> SplitList<T>(List<T> locations, int nSize = 30)
        {
            for (var i = 0; i < locations.Count; i += nSize)
            {
                yield return locations.GetRange(i, Math.Min(nSize, locations.Count - i));
            }
        }

        public static string GetStatusClass(AdsStatus status)
        {
            var statusClass = "";
            switch (status)
            {
                case AdsStatus.Active:
                    statusClass = "success";
                    break;
                case AdsStatus.Expired:
                    statusClass = "danger";
                    break;
                case AdsStatus.NotStart:
                    statusClass = "info";
                    break;
            }
            return statusClass;
        }

        public static string GetStatusClass(MovieStatus status)
        {
            var statusClass = "";
            switch (status)
            {
                case MovieStatus.Ongoing:
                    statusClass = "warning";
                    break;
                case MovieStatus.Completed:
                    statusClass = "success";
                    break;
            }
            return statusClass;
        }

        public static IEnumerable<Type> GetControllers(string namespaces)
        {
            var asm = Assembly.GetEntryAssembly();

            return asm.GetTypes()
                .Where(type => typeof(Controller).IsAssignableFrom(type) && type.Namespace.Contains(namespaces))
                .OrderBy(x => x.Name);
        }
    }
}