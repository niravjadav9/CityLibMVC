using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            List<branch> objBranchList = new List<branch>();
            using (var context = new LiberaryManagementEntities())
            {
                objBranchList = context.branch.OrderBy(x => x.name).ToList();
            }
            List<SelectListItem> ObjList = new List<SelectListItem>();
            ObjList.Add(new SelectListItem { Text = "Select Branch Name", Value = "0", Selected = true });

            foreach (var item in objBranchList)
            {
                ObjList.Add(new SelectListItem { Text = item.name + " - " + item.location, Value = item.branchid.ToString() });
            }
            ViewBag.BranchList = ObjList;

            return PartialView();
        }

        [HttpPost]
        public ActionResult SearchByBook(int? option, string data)
        {
            List<SearchBookBy1_Result> books = new List<SearchBookBy1_Result>();
            try
            {
                using (var context = new LiberaryManagementEntities())
                {
                    var temp = context.SearchBookBy1(option, data).ToList();
                    foreach (var item in temp)
                    {
                        books.Add(new SearchBookBy1_Result {
                            AuthorName = item.AuthorName,
                            BookId = item.BookId,
                            BookTitle = item.BookTitle,
                            ISBN = item.ISBN,
                            PublicationDate = item.PublicationDate.Date,
                            PublisherName = item.PublisherName
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in SearchByBook. \n{ex.Message}");
            }
            return Json(books, JsonRequestBehavior.AllowGet);
        }

        public ActionResult BookReserve()
        {
            List<branch> objBranchList = new List<branch>();
            using (var context = new LiberaryManagementEntities())
            {
                objBranchList = context.branch.OrderBy(x => x.name).ToList();
            }
            List<SelectListItem> ObjList = new List<SelectListItem>();
            ObjList.Add(new SelectListItem { Text = "Select Branch Name", Value = "0", Selected = true });

            foreach (var item in objBranchList)
            {
                ObjList.Add(new SelectListItem { Text = item.name + " - " + item.location, Value = item.branchid.ToString() });
            }
            ViewBag.BranchList = ObjList;
            return PartialView("BookReserve");
        }

        [HttpPost]
        public JsonResult GetBooksByBranch(int BranchId)
        {
            try
            {
                using (var db = new LiberaryManagementEntities())
                {
                    var query = (from bi in db.bookinfo
                                 join b in db.book
                                 on bi.isbn equals b.isbn
                                 where bi.branchid == BranchId
                                 orderby bi.title
                                 select new
                                 {
                                     b.isbn,
                                     b.bookid,
                                     bi.title,
                                     bi.branchid
                                 }).Distinct().ToList();
                    return Json(query, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("Somethings went wrong please try again", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult ReserveBook(int BranchId, int BookId, string ISBN, int ReaderId)
        {
            try
            {
                using (var db = new LiberaryManagementEntities())
                {
                    if (db.reserve.AsEnumerable().Any(x => x.readerid == ReaderId && x.bookid == BookId && x.date.Date == DateTime.Now.Date && x.date.Month == DateTime.Now.Month && x.date.Year == DateTime.Now.Year))
                    {
                        return Json("This book already reserved to you!", JsonRequestBehavior.AllowGet);
                    }

                    if (db.reserve.AsEnumerable().Count(x => x.readerid == ReaderId && x.date.Date == DateTime.Now.Date && x.date.Month == DateTime.Now.Month && x.date.Year == DateTime.Now.Year) > 10)
                    {
                        return Json("You can't reserve more than 10 books!", JsonRequestBehavior.AllowGet);
                    }

                    if (db.copy.AsQueryable().Where(x => x.branchid == BranchId && x.isbn == ISBN).Select(x => x.numcopy).Count() < 0)
                    {
                        return Json("The book is not available for this branch!", JsonRequestBehavior.AllowGet);
                    }

                    //if (db.borrow.AsQueryable().Any(x => x.branchid == BranchId && x.bookid == BookId && x.readerid == ReaderId && (x.bdate <= DateTime.Now && x.rdate >= DateTime.Now)))
                    //{
                    //    return Json("This book is already borrowed to you!", JsonRequestBehavior.AllowGet);
                    //}

                    reserve objR = new reserve();
                    objR.readerid = ReaderId;
                    objR.bookid = BookId;
                    objR.date = DateTime.Now;
                    db.reserve.Add(objR);
                    db.SaveChanges();

                    return Json("This book will remain reserved for next 24 hours for you!", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("Somethings went wrong please try again.", JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult ComputeFine()
        {

            return PartialView();
        }

        public JsonResult DisplayComputedFine(int ReaderId)
        {
            try
            {
                using (var db = new LiberaryManagementEntities())
                {
                    var query = (from brb in db.borrow
                                 join b in db.book on brb.bookid equals b.bookid
                                 join bi in db.bookinfo on b.isbn equals bi.isbn
                                 join brc in db.branch on brb.branchid equals brc.branchid
                                 where (brb.readerid == ReaderId) && (brb.rdate == null)
                                 select new
                                 {
                                     brb.bookid,
                                     brb.bdate,
                                     bi.title,
                                     brc.name,
                                     brc.location,
                                     PassedDayCount = DbFunctions.DiffDays(brb.bdate, DateTime.Now),
                                     computedFine = DbFunctions.DiffDays(brb.bdate, DateTime.Now) > 20 ? DbFunctions.DiffDays(brb.bdate, DateTime.Now) * 0.2 : 0.0,

                                 }).Distinct().ToList();
                    return Json(query, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("Somethings went wrong please try again.", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult CheckoutBook(int BranchId, int BookId, string ISBN, int ReaderId)
        {
            try
            {
                using (var db = new LiberaryManagementEntities())
                {
                    if (db.borrow.AsEnumerable().Any(x => x.readerid == ReaderId && x.bookid == BookId && x.branchid == BranchId && x.rdate == null))
                    {
                        return Json("This book is already borrowed to you!", JsonRequestBehavior.AllowGet);
                    }

                    borrow objb = new borrow();
                    objb.bookid = BookId;
                    objb.readerid = ReaderId;
                    objb.branchid = BranchId;
                    objb.bdate = DateTime.Now;
                    db.borrow.Add(objb);
                    db.SaveChanges();

                    return Json("Thank you for borrowing a book", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("Somethings went wrong please try again.", JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult BookReturn()
        {
            List<branch> objBranchList = new List<branch>();
            using (var context = new LiberaryManagementEntities())
            {
                objBranchList = context.branch.OrderBy(x => x.name).ToList();
            }
            List<SelectListItem> ObjList = new List<SelectListItem>();
            ObjList.Add(new SelectListItem { Text = "Select Branch Name", Value = "0", Selected = true });

            foreach (var item in objBranchList)
            {
                ObjList.Add(new SelectListItem { Text = item.name + " - " + item.location, Value = item.branchid.ToString() });
            }
            ViewBag.BranchList = ObjList;
            return PartialView();
        }

        [HttpPost]
        public JsonResult GetBooksForReturn(int BranchId, int ReaderId)
        {
            try
            {
                using (var db = new LiberaryManagementEntities())
                {
                    var query = (from brb in db.borrow
                                 join b in db.book on brb.bookid equals b.bookid
                                 join bi in db.bookinfo on b.isbn equals bi.isbn
                                 where bi.branchid == BranchId && brb.readerid == ReaderId && brb.rdate == null
                                 orderby bi.title
                                 select new
                                 {
                                     b.isbn,
                                     b.bookid,
                                     bi.title,
                                     bi.branchid
                                 }).Distinct().ToList();
                    return Json(query, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("Somethings went wrong please try again", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult BookReturn(int BranchId, int BookId, int ReaderId)
        {
            try
            {
                using (var db = new LiberaryManagementEntities())
                {
                    var query = db.borrow.SingleOrDefault(x => x.readerid == ReaderId && x.branchid == BranchId && x.bookid == BookId && x.rdate == null);
                    if (query != null)
                    {
                        query.rdate = DateTime.Now;
                        db.SaveChanges();
                    }

                    return Json("Thank you for returning the book " + BookId, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("Somethings went wrong please try again.", JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult PrintBookList()
        {

            return PartialView();
        }

        [HttpPost]
        public JsonResult PrintBookList(int ReaderId)
        {
            using (var db = new LiberaryManagementEntities())
            {
                var query = (from brb in db.borrow
                             join b in db.book on brb.bookid equals b.bookid
                             join bi in db.bookinfo on b.isbn equals bi.isbn
                             where brb.readerid == ReaderId
                             orderby bi.title
                             select new
                             {
                                 b.isbn,
                                 b.bookid,
                                 bi.title,
                                 brb.readerid,
                                 status = (brb.rdate == null ? "Not Available!" : "Availabel Now")
                             }).Distinct().ToList();
                return Json(query, JsonRequestBehavior.AllowGet);
            }
        }
    }
}