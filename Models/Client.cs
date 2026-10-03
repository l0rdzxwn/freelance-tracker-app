using System.ComponentModel.DataAnnotations;

namespace FreelanceTracker.Models
{
    public class Client
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage="Email is required.")]
        public string Email { get; set; }
        public string Company { get; set; }

        public string UserID { get; set; }

        public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
    }
}
