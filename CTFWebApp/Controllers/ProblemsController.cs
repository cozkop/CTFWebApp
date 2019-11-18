using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CTFWebApp.Data;
using CTFWebApp.Models;
using Microsoft.AspNetCore.Identity;

namespace CTFWebApp.Controllers
{
    public class ProblemsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public ProblemsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User); //get user from httpcontext

        // GET: Problems
        public async Task<IActionResult> Index()
        {
            return View(await _context.Problem.ToListAsync());
        }

        // GET: Problems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var problem = await _context.Problem
                .FirstOrDefaultAsync(m => m.Id == id);

           
            if (problem == null)
            {
                return NotFound();
            }

            SubmitProblemViewModel submitProblemVM = new SubmitProblemViewModel();

            submitProblemVM.Id = problem.Id;
            submitProblemVM.ProblemName = problem.ProblemName;
            submitProblemVM.ProblemDescription = problem.ProblemDescription;
            submitProblemVM.ProblemLevel = problem.ProblemLevel;
            submitProblemVM.Points = problem.Points;


            return View(submitProblemVM);
        }

        // POST: Problems/Details/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(int id, [Bind("Id,ProblemName,ProblemDescription,ProblemLevel,Points,SubmittedAnswer")] SubmitProblemViewModel submittedProblem)
        {
            if (id != submittedProblem.Id)
            {
                return NotFound();
            }

            var problem = await _context.Problem
                .FirstOrDefaultAsync(m => m.Id == id);

            if (problem == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (submittedProblem.SubmittedAnswer.Equals(problem.Answer))
                {
                    var CurrentUser = new ApplicationUser();
                    CurrentUser = await GetCurrentUserAsync();
                    await _context.Entry(CurrentUser).Reference(x => x.MyTeam).LoadAsync(); //explicitly load myTeam because of lazy loading

                    CurrentUser.MyTeam.Score += problem.Points;
                    try
                    {
                        _context.Update(CurrentUser);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ProblemExists(problem.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction("MyTeam", "Teams");
                }
            }
            return RedirectToAction("Details", "Problems"); //refresh
        }


        // GET: Problems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Problems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProblemName,ProblemDescription,ProblemLevel,Points,Answer")] Problem problem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(problem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(problem);
        }

        // GET: Problems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var problem = await _context.Problem.FindAsync(id);
            if (problem == null)
            {
                return NotFound();
            }
            return View(problem);
        }

        // POST: Problems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProblemName,ProblemDescription,Points,Answer,SubmittedAnswer")] Problem problem)
        {
            if (id != problem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(problem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProblemExists(problem.Id))
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
            return View(problem);
        }

        // GET: Problems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var problem = await _context.Problem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (problem == null)
            {
                return NotFound();
            }

            return View(problem);
        }

        // POST: Problems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var problem = await _context.Problem.FindAsync(id);
            _context.Problem.Remove(problem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProblemExists(int id)
        {
            return _context.Problem.Any(e => e.Id == id);
        }

        public IActionResult Problem2()
        {
            return View();
        }

    }
}
