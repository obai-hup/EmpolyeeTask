using EmpolyeeTask.Data;
using EmpolyeeTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpolyeeTask.Controllers
{
    public class DepartmentController : Controller
    {

        private readonly ApplicationDbContext context;
        public DepartmentController(ApplicationDbContext context)
        {
            this.context = context;
        }


        public IActionResult Index(CreateDepartViewModel viewModel)
        {
            var detail = context.Departments
                 .ToList();
            return View(detail);
        }
        // GET: DepartmentController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateDepartViewModel department)
        {

            var DepartmentModel = new Department()
            {

                DepartName = department.DepartName,
                DepartNo = department.DepartNo,
                CreatedAt = department.CreatedAt,
                CreatedBy = User.Identity.Name
            };

            context.Add(DepartmentModel);
            context.SaveChanges();
            TempData["Success"] = "تمت إضافه النشاط بنجاح!";

            return RedirectToAction("Index");

        }

        //// GET: DepartmentController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {

            Department department = await context.Departments.FindAsync(id);

            if (department == null)
            {
                return NotFound();
            }



            return View(department);
        }

        //// POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditDepartViewModel department)
        {
            var dep = context.Departments.SingleOrDefault(x => x.ID == id);

            dep.DepartName = department.DepartName;
            dep.DepartNo = department.DepartNo;
            dep.LastModifiedAt = department.LastModifiedAt;
            dep.LastModifiedBy = User.Identity.Name;

            context.Update(dep);

            context.SaveChanges();
            TempData["Success"] = "تمت تعديل النشاط بنجاح!";


            return RedirectToAction("Index", new { id });
        }

        //// POST: DepartmentController/Delete/5

        public async Task<ActionResult> Delete(string id)
        {
            var page = await context.Employees.FindAsync(id);

            if (page != null)
            {

                context.Remove(page);
                await context.SaveChangesAsync();
                TempData["Success"] = "تمت حذف النشاط بنجاح!";

            }

            return RedirectToAction("Index");


        }
    }
}
