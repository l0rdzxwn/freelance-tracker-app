namespace FreelanceTracker.Models
{
    public class Invoice
    {
        public int ID { get; set; }
        public string invoiceNumber { get; set; }
        public double amount { get; set; }
        public DateTime issueDate = DateTime.UtcNow;
        public DateTime dueDate { get; set; }
        public string Status { get; set; }
        public int ClientID { get; set; }
        
        public Client? Client { get; set; }
    }
}
