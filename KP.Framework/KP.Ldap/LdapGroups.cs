using System.Diagnostics;
using System.DirectoryServices;

namespace KP.Ldap
{
    public class LdapGroups
    {
        private LdapManager ldapManager = new LdapManager();

        private void GetAllGroups()
        {
            SearchResultCollection results;
            DirectorySearcher ds = null;
            DirectoryEntry de = new
            DirectoryEntry(ldapManager.GetCurrentDomainPath());
            ds = new DirectorySearcher(de);
            // Sort by name
            ds.Sort = new SortOption("name", SortDirection.Ascending);
            ds.PropertiesToLoad.Add("name");
            ds.PropertiesToLoad.Add("memberof");
            ds.PropertiesToLoad.Add("member");
            ds.Filter = "(&(objectCategory=Group))";
            results = ds.FindAll();
            foreach (SearchResult sr in results)
            {
                if (sr.Properties["name"].Count > 0)
                    Debug.WriteLine(sr.Properties["name"][0].ToString());
                if (sr.Properties["memberof"].Count > 0)
                {
                    Debug.WriteLine(" Member of...");
                    foreach (string item in sr.Properties["memberof"])
                    {
                        Debug.WriteLine(" " + item);
                    }
                }
                if (sr.Properties["member"].Count > 0)
                {
                    Debug.WriteLine(" Members");
                    foreach (string item in sr.Properties["member"])
                    {
                        Debug.WriteLine(" " + item);
                    }
                }
            }
        }
    }
}
