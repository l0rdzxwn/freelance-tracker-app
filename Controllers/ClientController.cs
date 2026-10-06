using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FreelanceTracker.Data;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using FreelanceTracker.Models;

namespace FreelanceTracker.Controllers
{

    [Authorize]
    public class ClientController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            string currUserID = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var client = await _context.Clients.Include(i => i.Invoices).FirstOrDefaultAsync(c => id == c.ID && currUserID == c.UserID);

            if (client == null)
            {
                return NotFound();
            }

            return View(client);


        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string currUserID = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var clientList = await _context.Clients.Where(c => c.UserID == currUserID).Include(c => c.Invoices).ToListAsync();

            return View(clientList);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Email,Company")] Client client)
        {
            string currUserID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            client.UserID = currUserID;

            ModelState.Remove("UserID");

            if (ModelState.IsValid)
            {
                await _context.Clients.AddAsync(client);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(client);


        }

    }
}
