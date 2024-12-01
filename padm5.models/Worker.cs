using padm5.models.Dtos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace padm5.models
{
    public class Worker : Entity
    {
        [Required]
        [Length(1,64)]
        public string FirstName { get; set; }
        [Required]
        [Length(1,64)]
        public string LastName { get; set; }
        [Required]
        [Length(1,64)]
        public string Position { get; set; }
        [Required]
        [Range(1, 10_000_000)]
        public decimal Salary { get; set; }
        public List<Team>? Teams { get; set; }
        public WorkerProfile? Profile { get; set; }

        public WorkerDtoWithId ToDto()
        {
            return new()
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                Position = Position,
                Salary = Salary
            };
        }
    }
}
