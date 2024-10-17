using GAMF_LA02.Data;
using GAMF_LA02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GAMF_LA02.Controllers
{
    public class ReportController : Controller
    {


        private readonly GAMFDbContext _context;

        public ReportController (GAMFDbContext context)
        { 
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IActionResult EnrollmentDateReport()
        {
            var result = _context.Students.GroupBy(c => c.EnrollmentDate)
                .OrderBy(o => o.Key)
                .Select(e => new EnrollmentDataVM { 
                    EnrollmentDate = e.Key,
                    StudentCount = e.Count()
                });
            /*
            select EnrollmentDate, count(*) from Students 
            group by EnrollmentDate
             */

            return View(result.ToList());
        }

        public IActionResult CreditReport()
        {
            var result = _context.Students
                .Include(e => e.Enrollments)
                .ThenInclude(x => x.Course)
                .GroupBy(c => c.LastName)
                .Select(e => new CreditReport
                {
                    StudentName = e.Key,
                    CreditCount = e.Sum(s => s.Enrollments.Sum(enr => enr.Course.Credits))
                });

            return View(result.ToList());
        }

    }
}
