using System.ComponentModel.DataAnnotations;

namespace padm5.models.Dtos
{
    public class DepartmentDto
    {
        [Required]
        [Length(1,100)]
        public string Name { get; set; }

        public Department ToModel() => new() { Name =  Name };
    }
}
