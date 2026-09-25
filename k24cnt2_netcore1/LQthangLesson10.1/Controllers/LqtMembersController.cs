using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LQthangLesson10._1.Models;

namespace LQthangLesson10._1.Controllers
{
    public class LqtMembersController : Controller
    {
        private readonly Lqtk24cnt2Lesson10Context _context;

        public LqtMembersController(Lqtk24cnt2Lesson10Context context)
        {
            _context = context;
        }

        // GET: LqtMembers
        public async Task<IActionResult> Index()
        {
            return View(await _context.LqtMembers.ToListAsync());
        }

        // GET: LqtMembers/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lqtMember = await _context.LqtMembers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lqtMember == null)
            {
                return NotFound();
            }

            return View(lqtMember);
        }

        // GET: LqtMembers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LqtMembers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LqtUserName,LqtPassword,LqtFullName,LqtEmail,LqtPhone,LqtStatus")] LqtMember lqtMember)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lqtMember);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lqtMember);
        }

        // GET: LqtMembers/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lqtMember = await _context.LqtMembers.FindAsync(id);
            if (lqtMember == null)
            {
                return NotFound();
            }
            return View(lqtMember);
        }

        // POST: LqtMembers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,LqtUserName,LqtPassword,LqtFullName,LqtEmail,LqtPhone,LqtStatus")] LqtMember lqtMember)
        {
            if (id != lqtMember.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lqtMember);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LqtMemberExists(lqtMember.Id))
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
            return View(lqtMember);
        }

        // GET: LqtMembers/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lqtMember = await _context.LqtMembers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lqtMember == null)
            {
                return NotFound();
            }

            return View(lqtMember);
        }

        // POST: LqtMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var lqtMember = await _context.LqtMembers.FindAsync(id);
            if (lqtMember != null)
            {
                _context.LqtMembers.Remove(lqtMember);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LqtMemberExists(long id)
        {
            return _context.LqtMembers.Any(e => e.Id == id);
        }
    }
}
