using EmpolyeeTask.Data;
using EmpolyeeTask.Helper;
using EmpolyeeTask.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmpolyeeTask.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        CountryApi _api = new CountryApi();
        private readonly ApplicationDbContext context;

        public EmployeeController(ApplicationDbContext context)
        {
            this.context = context;
        }
        // GET: EmployeeController
        public async Task<ActionResult> Index(Employee employee) 
        {
            List<Country> countrie = new List<Country>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("http://localhost:5000/api/Country");

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                countrie = JsonConvert.DeserializeObject<List<Country>>(result);
            }

            var detail = context.Employees
                //.Include(y => y.country)
                .Include(y => y.Departments)
                .ToList();
            return View(detail);
        }
        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            var employee = context.Employees.Find(id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: EmployeeController/Create
        public  async Task<ActionResult> Create()
        {
            List<Country> countrie = new List<Country>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("http://localhost:5000/api/Country");

            if(res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                countrie = JsonConvert.DeserializeObject<List<Country>>(result);
            }
            //ViewBag.Country = countrie;
            ViewBag.Country = new SelectList(countrie.OrderBy(x => x.Name), "CountryId", "Name");
            ViewBag.Depart = new SelectList(context.Departments.OrderBy(x => x.DepartName), "ID", "DepartName");

            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {

            var employModel = new Employee()
            {
               
                UserName = employee.UserName,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                country = employee.country,
                Departments = employee.Departments,
                PhoneNumber = employee.PhoneNumber
            };

            context.Add(employee);
            context.SaveChanges();
            TempData["Success"] = "تمت إضافه النشاط بنجاح!";

            return RedirectToAction("Index");

        }

        //// GET: EmployeeController/Edit/5
        public async Task<ActionResult> Edit(string id)
        {

            List<Country> countrie = new List<Country>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("http://localhost:5000/api/Country");

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                countrie = JsonConvert.DeserializeObject<List<Country>>(result);
            }

            ViewBag.Country = new SelectList(countrie.OrderBy(x => x.Name), "CountryId", "Name");

            //ViewBag.Country = new SelectList(context.Cuntries.OrderBy(x => x.Name), "CountryId", "Name");
            ViewBag.Depart = new SelectList(context.Departments.OrderBy(x => x.DepartName), "ID", "DepartName");


            Employee employee = await context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }



            return View(employee);
        }

        //// POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Employee employee)
        {
           var  EEmploy = context.Employees.SingleOrDefault(x => x.Id == id);

            EEmploy.UserName = employee.UserName;
            EEmploy.FirstName = employee.FirstName;
            EEmploy.LastName = employee.LastName;
            EEmploy.country = employee.country;
            EEmploy.Departments = employee.Departments;
            EEmploy.PhoneNumber = employee.PhoneNumber;

            context.Update(EEmploy);

            context.SaveChanges();
            TempData["Success"] = "تمت تعديل النشاط بنجاح!";


            return RedirectToAction("Index", new { id });
        }



        //// POST: EmployeeController/Delete/5

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

