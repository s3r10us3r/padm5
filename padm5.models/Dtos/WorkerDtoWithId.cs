using System.ComponentModel.DataAnnotations;

namespace padm5.models.Dtos
{
    public class WorkerDtoWithId
    {
        [Required]
        public int Id { get; set; }

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

        public Worker ToModel()
            => new()
            { FirstName = FirstName, LastName = LastName, Position = Position, Salary = Salary, Id = Id };
    }
}
