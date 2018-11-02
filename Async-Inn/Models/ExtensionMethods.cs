using System;

namespace AsyncInn.Models
{
    public class ExtensionMethods
    {
        // Implement a case insensitive string comparison
        public static bool CaseInsensitiveContains(string dbString, string searchTerm, StringComparison comparer)
        {
            return dbString != null && searchTerm != null ? dbString.IndexOf(searchTerm, comparer) >= 0 : false;
        }
    }
}