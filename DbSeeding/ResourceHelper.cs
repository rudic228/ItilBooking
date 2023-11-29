using System.Reflection;

namespace DbSeeding
{
    public static class ResourceHelper
    {
        public static byte[] GetEmbeddedResourceAsBytes(string resourceName)
        {
            return GetEmbeddedResourceAsByte(resourceName, Assembly.GetCallingAssembly());
        }

        public static byte[] GetEmbeddedResourceAsByte(string resourceName, Assembly assembly)
        {
            resourceName = FormatResourceName(assembly, resourceName);

            using var resourceStream = assembly.GetManifestResourceStream(resourceName);

            var content = new byte[resourceStream.Length];

            resourceStream.Read(content, 0, content.Length);

            return content;
        }

        private static string FormatResourceName(Assembly assembly, string resourceName)
        {
            return assembly.GetName().Name + "." + resourceName.Replace(" ", "_").Replace("\\", ".").Replace("/", ".");
        }
    }
}
