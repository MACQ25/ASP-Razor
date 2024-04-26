using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Assignment4.Data;
using Assignment4.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Assignment4.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly Assignment4.Data.NorthwindContext _context;

        public IndexModel(Assignment4.Data.NorthwindContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; } = default!;

        public SelectList Employees { get; set; } = default!;


        [BindProperty(SupportsGet = true)]
        public int? employeeSelection { get; set; }
        public async Task OnGetAsync()
        {

            if (_context.Orders != null)
            {
                Order = await _context.Orders
                .Where(o => o.Freight >= 250)
                .Include(o => o.Employee)
                .Include(o => o.ShipViaNavigation).ToListAsync();

                if(employeeSelection != null)
                {
                    Order = Order.Where(o => o.EmployeeId == employeeSelection).ToList();
                }
                
            }
            if (_context.Employees != null)
            {
                var optionsList = from e in _context.Employees
                                  .OrderBy(e => e.LastName)
                                  select new
                                  {
                                      Id = e.EmployeeId,
                                      EmployeeName = e.FirstName + " " + e.LastName,
                                  };
                Employees = new SelectList(optionsList, "Id", "EmployeeName");
            }
        }
    }
}
