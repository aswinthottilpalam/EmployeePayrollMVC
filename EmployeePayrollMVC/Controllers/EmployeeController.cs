using BusinessLayer.Interface;
using CommonLayer.User;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EmployeePayrollMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUserBL UserBL;
        public EmployeeController(IUserBL UserBL)
        {
            this.UserBL = UserBL;
        }

        // Show employee list
        public IActionResult Index()
        {
            List<UserpostModel> allEmployees = new List<UserpostModel>();
            allEmployees = UserBL.GetAllEmployees().ToList();
            return View(allEmployees);
        }

        // Add new employee

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind] UserpostModel employee)
        {
            if (ModelState.IsValid)
            {
                UserBL.AddEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // Update employee details
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            UserpostModel employee = UserBL.GetEmployeeData(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        [HttpPost]
        public IActionResult Edit(int id, [Bind] UserpostModel employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                UserBL.UpdateEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // Delete Employee 
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            UserpostModel employee = UserBL.GetEmployeeData(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int? id)
        {
            UserBL.DeleteEmployee(id);
            return RedirectToAction("Index");
        }

    }
}
