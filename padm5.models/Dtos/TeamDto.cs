using System.ComponentModel.DataAnnotations;

namespace padm5.models.Dtos
{
    public class TeamDto
    {
        [Required]
        [Length(1, 100)]
        public string Name { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        public List<WorkerDtoWithId> Workers { get; set; }

        public Team ToModel()
        {
            return new()
            {
                Name = Name,
                DepartmentId = DepartmentId,
                Workers = Workers.Select(w => w.ToModel()).ToList()
            };
        }
    }
}
