using LeQuangThang2410900071_exam.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeQuangThang2410900071_exam.Controllers;

public class LqtEmployeeController : Controller
{
    private readonly Lqt_2410900071Context _context;

    public LqtEmployeeController(Lqt_2410900071Context context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.LqtEmployees.ToListAsync());
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
            return NotFound();

        var student = await _context.LqtEmployees.FirstOrDefaultAsync(x => x.Id == id);
        if (student == null)
            return NotFound();

        return View(student);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(LqtEmployee student)
    {
        if (!ModelState.IsValid)
            return View(student);

        _context.Add(student);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
            return NotFound();

        var student = await _context.LqtEmployees.FindAsync(id);
        if (student == null)
            return NotFound();

        return View(student);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, LqtEmployee student)
    {
        if (id != student.Id)
            return NotFound();

        if (!ModelState.IsValid)
            return View(student);

        try
        {
            _context.Update(student);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await _context.LqtEmployees.AnyAsync(x => x.Id == student.Id))
                return NotFound();
            throw;
        }

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
            return NotFound();

        var student = await _context.LqtEmployees.FirstOrDefaultAsync(x => x.Id == id);
        if (student == null)
            return NotFound();

        return View(student);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var student = await _context.LqtEmployees.FindAsync(id);
        if (student != null)
        {
            _context.LqtEmployees.Remove(student);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }
}
