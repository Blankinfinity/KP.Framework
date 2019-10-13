using System.DirectoryServices;

namespace KP.Ldap
{
    public class LdapManager
    {
        /// <summary>
        /// Instead of having to know your actual domain name, you can use the following generic
        /// code to query the LDAP server for the connection string.
        /// </summary>
        /// <returns></returns>
        public string GetCurrentDomainPath()
        {
            var de = new DirectoryEntry("LDAP://RootDSE");
            return de.Properties["defaultNamingContext"][0].ToString();
        }
    }
}
