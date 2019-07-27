
namespace BugCatcher.WebApplication.Helpers
{
    public static class StringHelper
    {
        public static string RemoveSqlTags(this string query)
        {
            query = query.Replace("use", "")
                         .Replace("database", "")
                         .Replace("select", "")
                         .Replace("from", "")
                         .Replace("*", "")
                         .Replace("--", "")
                         .Trim();


            return query;
        }
    }
}
