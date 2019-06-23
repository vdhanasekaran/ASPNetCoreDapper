using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee.Models;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return base.View(Models.Employee.GetEmployees());
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee([Bind] Models.Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (Models.Employee.AddEmployee(employee) > 0)
                {
                    return base.RedirectToAction("Index");
                }
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult EditEmployee(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Models.Employee employee = Models.Employee.GetEmployeeById(id);
            if (employee == null)
                return NotFound();
            return View(employee);
        }

        [HttpPost]
        public IActionResult EditEmployee(int id, [Bind] Models.Employee employee)
        {
            if (id != employee.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                Models.Employee.UpdateEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        public IActionResult DeleteEmployee(int id)
        {
            Models.Employee employee = Models.Employee.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }
        [HttpPost]
        public IActionResult DeleteEmployee(int id, Models.Employee employee)
        {
            if (Models.Employee.DeleteEmployee(id) > 0)
            {
                return base.RedirectToAction("Index");
            }
            return View(employee);
        }
    }
}