using FreelanceTracker.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using FreelanceTracker.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FreelanceTracker.Controllers
{

    [Authorize]
    public class InvoiceController : Controller
    {
        private readonly ApplicationDbContext _context;
        public InvoiceController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SelectList> populateDropdown()
        {

            string currUserID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userClients = await _context.Clients.Where(c => c.UserID == currUserID).ToListAsync();

            return ViewBag.ClientID = new SelectList(userClients, "ID", "Name");
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string currUserID = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var invoiceList = await _context.Invoices
                .Where(i => i.Client.UserID == currUserID)
                .Include(i => i.Client)
                .OrderByDescending(i => i.IssueDate)
                .ToListAsync();

            return View(invoiceList);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await populateDropdown();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InvoiceNumber,Amount,IssueDate,DueDate,Status,ClientID")] Invoice invoice)
        {
            string currUserID = User.FindFirstValue(ClaimTypes.NameIdentifier);

            bool ownsClient = await _context.Clients.AnyAsync(c => c.ID == invoice.ClientID && c.UserID == currUserID);

            if (!ownsClient)
            {
                return Forbid();
            }

            ModelState.Remove("Client");

            if (ModelState.IsValid)
            {
                await _context.Invoices.AddAsync(invoice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            await populateDropdown();
            return View(invoice);
        }
    }
}
