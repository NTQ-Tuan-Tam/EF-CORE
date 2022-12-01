using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Curd.EfModels;

namespace Curd.Controllers
{
    public class userrrrsController : Controller
    {
        private readonly Entities _context;

        public userrrrsController(Entities context)
        {
            _context = context;
        }

        // GET: userrrrs
        public async Task<IActionResult> Index()
        {
            return View(await _context.userrrrs.ToListAsync());
        }

        // GET: userrrrs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userrrr = await _context.userrrrs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userrrr == null)
            {
                return NotFound();
            }

            return View(userrrr);
        }

        // GET: userrrrs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: userrrrs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Address,Phone")] userrrr userrrr)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userrrr);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userrrr);
        }

        // GET: userrrrs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userrrr = await _context.userrrrs.FindAsync(id);
            if (userrrr == null)
            {
                return NotFound();
            }
            return View(userrrr);
        }

        // POST: userrrrs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Address,Phone")] userrrr userrrr)
        {
            if (id != userrrr.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userrrr);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!userrrrExists(userrrr.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userrrr);
        }

        // GET: userrrrs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userrrr = await _context.userrrrs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userrrr == null)
            {
                return NotFound();
            }

            return View(userrrr);
        }

        // POST: userrrrs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userrrr = await _context.userrrrs.FindAsync(id);
            _context.userrrrs.Remove(userrrr);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool userrrrExists(int id)
        {
            return _context.userrrrs.Any(e => e.Id == id);
        }

        internal static object ToList()
        {
            throw new NotImplementedException();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost, ActionName("Login")]
        public IActionResult Login(string username, string password)
        {
           
            var p = _context.userrrrs.ToList();
            var userDetail = p.Where(x => x.Name == username && x.Email == password).SingleOrDefault();

            if (userDetail != null)
            {
                return RedirectToAction("Index", "userrrrs");
            }
            else
            {
                return View();
            }
        }
    }
}
