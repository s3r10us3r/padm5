using System.ComponentModel.DataAnnotations;

namespace padm5.models
{
    public class WorkerProfile : Entity
    {
        public int WorkerId { get; set; }
        [Required]
        public string Mail { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
