using System.ComponentModel.DataAnnotations;

namespace padm5.models
{
    public class Department : Entity
    {
        [Required]
        [Length(1,100)]
        public string Name { get; set; }
        public List<Team> Teams { get; set; }
    }
}
