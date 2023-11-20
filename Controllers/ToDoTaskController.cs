using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalToDo.Data;
using ProyectoFinalToDo.Models;

namespace ProyectoFinalToDo.Controllers
{
    public class ToDoTaskController : Controller
    {
        private readonly ToDoAppDbContext _context;

        public ToDoTaskController(ToDoAppDbContext context)
        {
            _context = context;
        }

        // GET: ToDoTask
        public async Task<IActionResult> Index()
        {
            var toDoAppDbContext = _context.ToDoTask.Include(t => t.User);
            return View(await toDoAppDbContext.ToListAsync());
        }

        // GET: ToDoTask/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ToDoTask == null)
            {
                return NotFound();
            }

            var toDoTask = await _context.ToDoTask
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toDoTask == null)
            {
                return NotFound();
            }

            return View(toDoTask);
        }

        // GET: ToDoTask/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: ToDoTask/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,IsCompleted,HasPomodoro,PomodoroCount")] ToDoTask toDoTask)
        {
            if (ModelState.IsValid)
            {
                _context.Add(toDoTask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Users, "Id", "Id", toDoTask.Id);
            return View(toDoTask);
        }

        // GET: ToDoTask/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ToDoTask == null)
            {
                return NotFound();
            }

            var toDoTask = await _context.ToDoTask.FindAsync(id);
            if (toDoTask == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.Users, "Id", "Id", toDoTask.Id);
            return View(toDoTask);
        }

        // POST: ToDoTask/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,IsCompleted,HasPomodoro,PomodoroCount")] ToDoTask toDoTask)
        {
            if (id != toDoTask.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(toDoTask);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToDoTaskExists(toDoTask.Id))
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
            ViewData["Id"] = new SelectList(_context.Users, "Id", "Id", toDoTask.Id);
            return View(toDoTask);
        }

        // GET: ToDoTask/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ToDoTask == null)
            {
                return NotFound();
            }

            var toDoTask = await _context.ToDoTask
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toDoTask == null)
            {
                return NotFound();
            }

            return View(toDoTask);
        }

        // POST: ToDoTask/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ToDoTask == null)
            {
                return Problem("Entity set 'ToDoAppDbContext.ToDoTask'  is null.");
            }
            var toDoTask = await _context.ToDoTask.FindAsync(id);
            if (toDoTask != null)
            {
                _context.ToDoTask.Remove(toDoTask);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ToDoTaskExists(int id)
        {
          return (_context.ToDoTask?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
