using System.ComponentModel.DataAnnotations.Schema;

namespace FreelanceTracker.Models
{
    public class Invoice
    {
        public int ID { get; set; }
        public string InvoiceNumber { get; set; }
        public double Amount { get; set; }
        public DateTime IssueDate { get; set; } = DateTime.UtcNow;
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
        public int ClientID { get; set; }

        [ForeignKey("ClientID")]
        public Client? Client { get; set; }
    }
}
