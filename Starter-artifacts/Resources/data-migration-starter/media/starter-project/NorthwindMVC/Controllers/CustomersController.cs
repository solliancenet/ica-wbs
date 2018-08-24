using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using NorthwindMVC.Data;

namespace NorthwindMVC.Controllers
{
    public class CustomersController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Customers
        public ActionResult Index()
        {
            return this.View(this.db.CUSTOMERS.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var cUSTOMER = this.db.CUSTOMERS.Find(id);

            if (cUSTOMER == null)
            {
                return this.HttpNotFound();
            }

            return this.View(cUSTOMER);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return this.View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CUSTOMERID,COMPANYNAME,CONTACTNAME,CONTACTTITLE,ADDRESS,CITY,REGION,POSTALCODE,COUNTRY,PHONE,FAX")] CUSTOMER cUSTOMER)
        {
            if (ModelState.IsValid)
            {
                this.db.CUSTOMERS.Add(cUSTOMER);
                this.db.SaveChanges();

                return this.RedirectToAction("Index");
            }

            return this.View(cUSTOMER);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var cUSTOMER = this.db.CUSTOMERS.Find(id);

            if (cUSTOMER == null)
            {
                return this.HttpNotFound();
            }

            return this.View(cUSTOMER);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CUSTOMERID,COMPANYNAME,CONTACTNAME,CONTACTTITLE,ADDRESS,CITY,REGION,POSTALCODE,COUNTRY,PHONE,FAX")] CUSTOMER cUSTOMER)
        {
            if (ModelState.IsValid)
            {
                this.db.Entry(cUSTOMER).State = EntityState.Modified;
                this.db.SaveChanges();

                return this.RedirectToAction("Index");
            }

            return this.View(cUSTOMER);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var cUSTOMER = this.db.CUSTOMERS.Find(id);

            if (cUSTOMER == null)
            {
                return this.HttpNotFound();
            }

            return this.View(cUSTOMER);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            var cUSTOMER = this.db.CUSTOMERS.Find(id);

            this.db.CUSTOMERS.Remove(cUSTOMER);
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
