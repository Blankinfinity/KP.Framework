using System.DirectoryServices;

namespace KP.Ldap
{
    public class LdapManager
    {
        private string GetCurrentDomainPath()
        {
            var de = new DirectoryEntry("LDAP://RootDSE");
            return de.Properties["defaultNamingContext"][0].ToString();
        }
    }
}
