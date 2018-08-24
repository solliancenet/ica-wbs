using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using NorthwindMVC.Data;

namespace NorthwindMVC.Controllers
{
    public class EmployeesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Employees
        public ActionResult Index()
        {
            var eMPLOYEES = this.db.EMPLOYEES.Include(e => e.EMPLOYEE1);

            return this.View(eMPLOYEES.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var eMPLOYEE = this.db.EMPLOYEES.Find(id);

            if (eMPLOYEE == null)
            {
                return this.HttpNotFound();
            }

            return this.View(eMPLOYEE);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.REPORTSTO = new SelectList(this.db.EMPLOYEES, "EMPLOYEEID", "LASTNAME");

            return this.View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EMPLOYEEID,LASTNAME,FIRSTNAME,TITLE,TITLEOFCOURTESY,BIRTHDATE,HIREDATE,ADDRESS,CITY,REGION,POSTALCODE,COUNTRY,HOMEPHONE,EXTENSION,PHOTO,NOTES,REPORTSTO,PHOTOPATH")] EMPLOYEE eMPLOYEE)
        {
            if (ModelState.IsValid)
            {
                this.db.EMPLOYEES.Add(eMPLOYEE);
                this.db.SaveChanges();

                return this.RedirectToAction("Index");
            }

            ViewBag.REPORTSTO = new SelectList(this.db.EMPLOYEES, "EMPLOYEEID", "LASTNAME", eMPLOYEE.REPORTSTO);

            return this.View(eMPLOYEE);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var eMPLOYEE = this.db.EMPLOYEES.Find(id);

            if (eMPLOYEE == null)
            {
                return this.HttpNotFound();
            }

            ViewBag.REPORTSTO = new SelectList(this.db.EMPLOYEES, "EMPLOYEEID", "LASTNAME", eMPLOYEE.REPORTSTO);

            return this.View(eMPLOYEE);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EMPLOYEEID,LASTNAME,FIRSTNAME,TITLE,TITLEOFCOURTESY,BIRTHDATE,HIREDATE,ADDRESS,CITY,REGION,POSTALCODE,COUNTRY,HOMEPHONE,EXTENSION,PHOTO,NOTES,REPORTSTO,PHOTOPATH")] EMPLOYEE eMPLOYEE)
        {
            if (ModelState.IsValid)
            {
                this.db.Entry(eMPLOYEE).State = EntityState.Modified;
                this.db.SaveChanges();

                return this.RedirectToAction("Index");
            }

            ViewBag.REPORTSTO = new SelectList(this.db.EMPLOYEES, "EMPLOYEEID", "LASTNAME", eMPLOYEE.REPORTSTO);

            return this.View(eMPLOYEE);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var eMPLOYEE = this.db.EMPLOYEES.Find(id);

            if (eMPLOYEE == null)
            {
                return this.HttpNotFound();
            }

            return this.View(eMPLOYEE);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            var eMPLOYEE = this.db.EMPLOYEES.Find(id);

            this.db.EMPLOYEES.Remove(eMPLOYEE);
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
