using System.ComponentModel.DataAnnotations;

namespace BugCatcher.Entities.Concrete
{
    public class QueryEntity:EntityBase
    {
        [Required, StringLength(50), Display(Order = 2)]
        public string Title { get; set; }
        [Required,StringLength(4000),Display(Order =3)]
        public string Query { get; set; }

    }
}
