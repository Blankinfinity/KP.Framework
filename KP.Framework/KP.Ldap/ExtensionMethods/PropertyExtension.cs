using System.DirectoryServices;

namespace KP.Ldap.ExtensionMethods
{
    public static class PropertyExtension
    {
        public static string GetPropertyValue(this SearchResult sr, string propertyName)
        {
            string props = string.Empty;

            if (sr.Properties[propertyName].Count > 0)
                props = sr.Properties[propertyName][0].ToString();
            return props;
        }
    }
}
