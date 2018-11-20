using Liberary_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

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
        public ActionResult Dashboard()
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
                    ViewBag.Isbn = context.book.ToList();
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
        public ActionResult AddBookCopy(string isbn, string title, string publisher, string author, string publicationDate, string branch, string position)
        {
            bool isSucessfull = false;
            try
            {
                using (var context = new LiberaryManagementEntities())
                {
                    var temp = context.SP_InsertBookCopy(isbn, title, publisher, author, publicationDate, branch, position);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return Json(isSucessfull, JsonRequestBehavior.AllowGet);
        }

        // GET: Top 10 Borrower
        public ActionResult Top10MostBorrower()
        {
            try
            {
                using (var context = new LiberaryManagementEntities())
                {
                    ViewBag.BranchList = context.branch.ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error found at Top10MostBorrower.\n {e.Message}");
            }

            return PartialView("Top10MostBorrower");
        }

        public ActionResult Top10BrrowerList(int? branchid)
        {
            var top10BrrowerList = new List<Top10BorrowerViewModel>();
            try
            {
                using (var context = new LiberaryManagementEntities())
                {
                    var top10Borrower = context.SP_Top10Borrower(branchid).ToList();
                    foreach (var item in top10Borrower)
                    {
                        top10BrrowerList.Add(new Top10BorrowerViewModel
                        {
                            readerName = item.ReaderName,
                            totalBook = item.TotalBook
                        });
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error found at Top10BrrowerList. \n{e.Message}");
            }

            return Json(top10BrrowerList, JsonRequestBehavior.AllowGet);
        }

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

        // GET: Branch Location
        public ActionResult BranchLocation()
        {
            var branches = new List<BranchViewModel>();
            try
            {
                using (var context = new LiberaryManagementEntities())
                {
                    var dbBranches = context.branch.ToList();
                    foreach (var item in dbBranches)
                    {
                        branches.Add(new BranchViewModel
                        {
                            BrnahcId = item.branchid,
                            Name = item.name,
                            Location = item.location
                        });
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error found in BranchLocation: \n{e.Message}");
            }
            return PartialView("BranchLocation", branches);
        }
    }
}
