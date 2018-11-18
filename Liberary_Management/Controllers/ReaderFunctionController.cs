using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Liberary_Management.Controllers
{
    public class ReaderFunctionController : Controller
    {
        // GET: ReaderFunction
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IsUserValid(string data)
        {
            var user = new reader();
            if (!string.IsNullOrEmpty(data))
            {
                try
                {
                    using (var context = new LiberaryManagementEntities())
                    {
                        var userValid = context.reader.Where(x => x.readerid.ToString() == data).FirstOrDefault();
                        if (userValid != null)
                        {
                            user = userValid;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            return Json(user, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SearchBook()
        {
            return PartialView("SearchBook");
        }

        public ActionResult BookCheckout()
        {
            return PartialView("BookCheckout");
        }

        [HttpPost]
        public ActionResult SearchByBook(int option, string data)
        {
            List<SearchBookBy_Result> books = new List<SearchBookBy_Result>();
            try
            {
                using (var context = new LiberaryManagementEntities())
                {
                    books = context.SearchBookBy(option, data).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in SearchByBook. \n{ex.Message}");
            }
            return Json(books, JsonRequestBehavior.AllowGet);
        }
    }
}