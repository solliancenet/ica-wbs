using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using NorthwindMVC.Data;

namespace NorthwindMVC.Controllers
{
    public class SuppliersController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Suppliers
        public ActionResult Index()
        {
            return this.View(this.db.SUPPLIERS.ToList());
        }

        // GET: Suppliers/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var sUPPLIER = this.db.SUPPLIERS.Find(id);

            if (sUPPLIER == null)
            {
                return this.HttpNotFound();
            }

            return this.View(sUPPLIER);
        }

        // GET: Suppliers/Create
        public ActionResult Create()
        {
            return this.View();
        }

        // POST: Suppliers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SUPPLIERID,COMPANYNAME,CONTACTNAME,CONTACTTITLE,ADDRESS,CITY,REGION,POSTALCODE,COUNTRY,PHONE,FAX,HOMEPAGE")] SUPPLIER sUPPLIER)
        {
            if (ModelState.IsValid)
            {
                this.db.SUPPLIERS.Add(sUPPLIER);
                this.db.SaveChanges();

                return this.RedirectToAction("Index");
            }

            return this.View(sUPPLIER);
        }

        // GET: Suppliers/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var sUPPLIER = this.db.SUPPLIERS.Find(id);

            if (sUPPLIER == null)
            {
                return this.HttpNotFound();
            }

            return this.View(sUPPLIER);
        }

        // POST: Suppliers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SUPPLIERID,COMPANYNAME,CONTACTNAME,CONTACTTITLE,ADDRESS,CITY,REGION,POSTALCODE,COUNTRY,PHONE,FAX,HOMEPAGE")] SUPPLIER sUPPLIER)
        {
            if (ModelState.IsValid)
            {
                this.db.Entry(sUPPLIER).State = EntityState.Modified;
                this.db.SaveChanges();

                return this.RedirectToAction("Index");
            }

            return this.View(sUPPLIER);
        }

        // GET: Suppliers/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var sUPPLIER = this.db.SUPPLIERS.Find(id);

            if (sUPPLIER == null)
            {
                return this.HttpNotFound();
            }

            return this.View(sUPPLIER);
        }

        // POST: Suppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            var sUPPLIER = this.db.SUPPLIERS.Find(id);

            this.db.SUPPLIERS.Remove(sUPPLIER);
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
