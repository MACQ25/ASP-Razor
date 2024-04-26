using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Assignment4.Data;
using Assignment4.Models;

namespace Assignment4.Pages.Employees
{
    public class DetailsModel : PageModel
    {
        private readonly Assignment4.Data.NorthwindContext _context;

        public DetailsModel(Assignment4.Data.NorthwindContext context)
        {
            _context = context;
        }

      public Employee Employee { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }
            else 
            {
                Employee = employee;
                var toRep = await _context.Employees.FirstOrDefaultAsync(m =>
                m.EmployeeId == Employee.ReportsTo);
                if (toRep != null)
                {
                    ViewData["ReportPerson"] = toRep.FirstName + " " + toRep.LastName;
                }
                else ViewData["ReportPerson"] = "No one";
            }
            return Page();
        }
    }
}
