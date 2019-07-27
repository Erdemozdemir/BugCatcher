using System;

namespace BugCatcher.UI.Models.Comments
{
    public class CommentFileModel
    {
        public int Id { get; set; }
        public string Text{ get; set; }
        public bool IsFile { get; set; }
        public DateTime CreDate { get; set; }
    }
}
