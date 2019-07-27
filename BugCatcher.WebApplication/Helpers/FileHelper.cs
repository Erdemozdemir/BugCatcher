using System.IO;

namespace BugCatcher.WebApplication.Helpers
{
    public class FileHelper
    {
        public string EnsureCorrectFilename(string filename)
        {
            if (filename.Contains("\\"))
                filename = filename.Substring(filename.LastIndexOf("\\") + 1);

            return filename;
        }

        public string GetPathAndFilename(string filename)
        {
            return Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\ItemsFiles\\", filename);
        }

    }
}
