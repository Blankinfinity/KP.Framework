using KP.Ldap.ExtensionMethods;
using System.Diagnostics;
using System.DirectoryServices;

namespace KP.Ldap
{
    public class LdapUsers
    {
        private readonly LdapManager ldapManager = new LdapManager();

        private DirectorySearcher BuildUserSearcher(DirectoryEntry de)
        {
            DirectorySearcher ds = new DirectorySearcher(de);
            // Full Name
            ds.PropertiesToLoad.Add("name");
            // Email Address
            ds.PropertiesToLoad.Add("mail");
            // First Name
            ds.PropertiesToLoad.Add("givenname");
            // Last Name (Surname)
            ds.PropertiesToLoad.Add("sn");
            // Login Name
            ds.PropertiesToLoad.Add("userPrincipalName");
            // Distinguished Name
            ds.PropertiesToLoad.Add("distinguishedName");
            return ds;
        }

        public void GetAllUsers()
        {
            SearchResultCollection results;
            DirectoryEntry de = new
            DirectoryEntry(ldapManager.GetCurrentDomainPath());
            DirectorySearcher ds = new DirectorySearcher(de)
            {
                Filter = "(&(objectCategory=User)(objectClass=person))"
            };
            results = ds.FindAll();
            foreach (SearchResult sr in results)
            {
                // Using the index zero (0) is required!
                Debug.WriteLine(sr.Properties["name"][0].ToString());
            }
        }

        public void GetAUser(string userName)
        {
            DirectoryEntry de = new
            DirectoryEntry(ldapManager.GetCurrentDomainPath());
            SearchResult sr;
            // Build User Searcher
            DirectorySearcher ds = BuildUserSearcher(de);
            // Set the filter to look for a specific user
            ds.Filter = "(&(objectCategory=User)(objectClass=person)(name = " + userName + ")";
            sr = ds.FindOne();
            if (sr != null)
            {
                Debug.WriteLine(sr.GetPropertyValue("name"));
                Debug.WriteLine(sr.GetPropertyValue("mail"));
                Debug.WriteLine(sr.GetPropertyValue("givenname"));
                Debug.WriteLine(sr.GetPropertyValue("sn"));
                Debug.WriteLine(sr.GetPropertyValue(
                "userPrincipalName"));
                Debug.WriteLine(sr.GetPropertyValue(
                "distinguishedName"));
            }
        }
    }
}
