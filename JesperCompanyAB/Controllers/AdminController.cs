using JesperCompanyAB.Data;
using JesperCompanyAB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JesperCompanyAB.Controllers
{
    
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> usermanager;
        private readonly ApplicationDbContext context;
        public AdminController(ApplicationDbContext _context ,UserManager<ApplicationUser> _usermanager)
        {
            usermanager = _usermanager;
            context = _context;
        }

        public async Task<IActionResult> Index(string SearchString)
        {
            
            ViewData["CurrentFilter"] = SearchString;

            var employees = from s in context.Users
                            select s;
            if (!String.IsNullOrEmpty(SearchString))
            {
                employees = employees.Where(s => s.LastName.Contains(SearchString)
                                       || s.FirstName.Contains(SearchString));
            }



            List < InfoModel > List = new List<InfoModel>();
            var items = await (from emp in employees
                               join holi in context.Holidays on emp.Id equals holi.FK_UserId
                               select new
                               {
                                   Start = holi.Start,
                                   Stop = holi.Stop,
                                   HolidayType = holi.HolidayType,
                                   FirstName = emp.FirstName,
                                   LastName = emp.LastName,
                                   MadeAt = holi.MadeAt,
                               }).ToListAsync();
            // konvertera från anonymous
            foreach (var item in items)
            {
                InfoModel listItem = new InfoModel();
                listItem.Start = item.Start;
                listItem.Stop = item.Stop;
                listItem.HolidayType = item.HolidayType;
                listItem.FirstName = item.FirstName;
                listItem.LastName = item.LastName;
                listItem.MadeAt = item.MadeAt;
                List.Add(listItem);
            }
            // Kalla på view
            return View(List);
        }

        //public async Task<IActionResult> Index()
        //{
        //    var admins = (await usermanager
        //        .GetUsersInRoleAsync("Administrator"))
        //        .ToArray();

        //    var everyone = await usermanager.Users.ToArrayAsync();

        //    var model = new AdminViewModel
        //    {
        //        Administrators = admins,
        //        Everyone = everyone
        //    };

        //    return View(model);
        //}
    }
}
