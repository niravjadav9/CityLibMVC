using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using Liberary_Management.Models;

namespace Liberary_Management.Controllers
{
    public class AdminFunctionController : Controller
    {
        // GET: AdminFunction
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Index(LoginViewModel collection)
        {
            var adminUser = new admin();
            try
            {
                if (ModelState.IsValid)
                {
                    using (var context = new LiberaryManagementEntities())
                    {
                        adminUser = context.admin.Where(x => x.id == collection.Username && x.password == collection.Password).FirstOrDefault();
                        if (adminUser != null)
                        {
                            return RedirectToAction("Dashboard", "AdminFunction");  
                        }
                        else
                        {
                            TempData["msg"] = "Invalid Credentials";
                            return RedirectToAction("Index");
                        }
                    }
                }
                else
                {
                    TempData["msg"] = "Invalid Credentials";
                    return RedirectToAction("Index");
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine($"Error at Index POST. \n{ex.Message}");
            }
            return View("Index");
        }

        // GET: Dashboard
        public ActionResult Dashboard ()
        {
            return View("Dashboard");
        }

        // GET: Add a book copy
        public ActionResult AddBook()
        {
            try
            {
                using (var context = new LiberaryManagementEntities())
                {
                    ViewBag.Isbn = context.book.Select(x => x.isbn).ToList();

                    ViewBag.Publisher = context.publisher.ToList();
                    ViewBag.Author = context.author.ToList();
                    ViewBag.Branch = context.branch.ToList();
                    ViewBag.Position = context.location.ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return PartialView("AddBook");
        }

        // POST: Add book copy to database
        //public ActionResult AddBookCopy ()

        // GET: AdminFunction/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminFunction/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminFunction/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminFunction/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminFunction/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminFunction/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminFunction/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
