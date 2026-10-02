using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FreelanceTracker.Models;

namespace FreelanceTracker.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        DbSet<Invoice> Invoices { get; set; }
        DbSet<Client> Clients { get; set; }
    }
}
