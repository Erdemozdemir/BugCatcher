using System.ComponentModel.DataAnnotations;

namespace BugCatcher.Entities.CustomDataAnnotation
{
    public class ShowInFilter: ValidationAttribute
    {
        public bool ShowInTable { get; set; }

        public override bool IsValid(object value)
        {
            return ShowInTable;
        }
    }
}
