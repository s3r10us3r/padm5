using System.ComponentModel.DataAnnotations;

namespace padm5.models.Dtos
{
    public class WorkerProfileDto
    {
        [Required]
        public string Mail { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
