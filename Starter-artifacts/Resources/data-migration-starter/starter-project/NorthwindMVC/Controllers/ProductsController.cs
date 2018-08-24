using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using NorthwindMVC.Data;

namespace NorthwindMVC.Controllers
{
    public class ProductsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Products
        public ActionResult Index()
        {
            var pRODUCTS = this.db.PRODUCTS.Include(p => p.CATEGORy).Include(p => p.SUPPLIER);

            return this.View(pRODUCTS.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var pRODUCT = this.db.PRODUCTS.Find(id);

            if (pRODUCT == null)
            {
                return this.HttpNotFound();
            }

            return this.View(pRODUCT);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CATEGORYID = new SelectList(this.db.CATEGORIES, "CATEGORYID", "CATEGORYNAME");
            ViewBag.SUPPLIERID = new SelectList(this.db.SUPPLIERS, "SUPPLIERID", "COMPANYNAME");

            return this.View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PRODUCTID,PRODUCTNAME,SUPPLIERID,CATEGORYID,QUANTITYPERUNIT,UNITPRICE,UNITSINSTOCK,UNITSONORDER,REORDERLEVEL,DISCONTINUED")] PRODUCT pRODUCT)
        {
            if (ModelState.IsValid)
            {
                this.db.PRODUCTS.Add(pRODUCT);
                this.db.SaveChanges();

                return this.RedirectToAction("Index");
            }

            ViewBag.CATEGORYID = new SelectList(this.db.CATEGORIES, "CATEGORYID", "CATEGORYNAME", pRODUCT.CATEGORYID);
            ViewBag.SUPPLIERID = new SelectList(this.db.SUPPLIERS, "SUPPLIERID", "COMPANYNAME", pRODUCT.SUPPLIERID);

            return this.View(pRODUCT);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var pRODUCT = this.db.PRODUCTS.Find(id);

            if (pRODUCT == null)
            {
                return this.HttpNotFound();
            }

            ViewBag.CATEGORYID = new SelectList(this.db.CATEGORIES, "CATEGORYID", "CATEGORYNAME", pRODUCT.CATEGORYID);
            ViewBag.SUPPLIERID = new SelectList(this.db.SUPPLIERS, "SUPPLIERID", "COMPANYNAME", pRODUCT.SUPPLIERID);

            return this.View(pRODUCT);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRODUCTID,PRODUCTNAME,SUPPLIERID,CATEGORYID,QUANTITYPERUNIT,UNITPRICE,UNITSINSTOCK,UNITSONORDER,REORDERLEVEL,DISCONTINUED")] PRODUCT pRODUCT)
        {
            if (ModelState.IsValid)
            {
                this.db.Entry(pRODUCT).State = EntityState.Modified;
                this.db.SaveChanges();

                return this.RedirectToAction("Index");
            }

            ViewBag.CATEGORYID = new SelectList(this.db.CATEGORIES, "CATEGORYID", "CATEGORYNAME", pRODUCT.CATEGORYID);
            ViewBag.SUPPLIERID = new SelectList(this.db.SUPPLIERS, "SUPPLIERID", "COMPANYNAME", pRODUCT.SUPPLIERID);

            return this.View(pRODUCT);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var pRODUCT = this.db.PRODUCTS.Find(id);

            if (pRODUCT == null)
            {
                return this.HttpNotFound();
            }

            return this.View(pRODUCT);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            var pRODUCT = this.db.PRODUCTS.Find(id);

            this.db.PRODUCTS.Remove(pRODUCT);
            this.db.SaveChanges();

            return this.RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
