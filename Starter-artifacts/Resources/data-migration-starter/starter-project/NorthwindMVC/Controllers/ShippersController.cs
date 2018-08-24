using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using NorthwindMVC.Data;

namespace NorthwindMVC.Controllers
{
    public class ShippersController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Shippers
        public ActionResult Index()
        {
            return this.View(this.db.SHIPPERS.ToList());
        }

        // GET: Shippers/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var sHIPPER = this.db.SHIPPERS.Find(id);

            if (sHIPPER == null)
            {
                return this.HttpNotFound();
            }

            return this.View(sHIPPER);
        }

        // GET: Shippers/Create
        public ActionResult Create()
        {
            return this.View();
        }

        // POST: Shippers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SHIPPERID,COMPANYNAME,PHONE")] SHIPPER sHIPPER)
        {
            if (ModelState.IsValid)
            {
                this.db.SHIPPERS.Add(sHIPPER);
                this.db.SaveChanges();

                return this.RedirectToAction("Index");
            }

            return this.View(sHIPPER);
        }

        // GET: Shippers/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var sHIPPER = this.db.SHIPPERS.Find(id);

            if (sHIPPER == null)
            {
                return this.HttpNotFound();
            }

            return this.View(sHIPPER);
        }

        // POST: Shippers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SHIPPERID,COMPANYNAME,PHONE")] SHIPPER sHIPPER)
        {
            if (ModelState.IsValid)
            {
                this.db.Entry(sHIPPER).State = EntityState.Modified;
                this.db.SaveChanges();

                return this.RedirectToAction("Index");
            }

            return this.View(sHIPPER);
        }

        // GET: Shippers/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var sHIPPER = this.db.SHIPPERS.Find(id);

            if (sHIPPER == null)
            {
                return this.HttpNotFound();
            }

            return this.View(sHIPPER);
        }

        // POST: Shippers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            var sHIPPER = this.db.SHIPPERS.Find(id);

            this.db.SHIPPERS.Remove(sHIPPER);
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
