using System.ComponentModel.DataAnnotations;

namespace padm5.models
{
    public class Team : Entity
    {
        [Required]
        [Length(1, 100)]
        public string Name { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        public List<Worker>? Workers { get; set; }
        public Department? Department { get; set; }
    }
}
