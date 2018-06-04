using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TNAShop.Data;
using TNAShop.Domain;

namespace TNAShop.Areas.Admin.Controllers
{
    public class PriceFilteringController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/PriceFiltering
        public async Task<ActionResult> Index()
        {
            return View(await db.PriceFilterings.ToListAsync());
        }

        // GET: Admin/PriceFiltering/Details/5
        public async Task<ActionResult> Details(double? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PriceFiltering priceFiltering = await db.PriceFilterings.FindAsync(id);
            if (priceFiltering == null)
            {
                return HttpNotFound();
            }
            return View(priceFiltering);
        }

        // GET: Admin/PriceFiltering/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/PriceFiltering/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Min,Max,Name")] PriceFiltering priceFiltering)
        {
            if (ModelState.IsValid)
            {
                db.PriceFilterings.Add(priceFiltering);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(priceFiltering);
        }

        // GET: Admin/PriceFiltering/Edit/5
        public async Task<ActionResult> Edit(double? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PriceFiltering priceFiltering = await db.PriceFilterings.FindAsync(id);
            if (priceFiltering == null)
            {
                return HttpNotFound();
            }
            return View(priceFiltering);
        }

        // POST: Admin/PriceFiltering/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Min,Max,Name")] PriceFiltering priceFiltering)
        {
            if (ModelState.IsValid)
            {
                db.Entry(priceFiltering).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(priceFiltering);
        }

        // GET: Admin/PriceFiltering/Delete/5
        public async Task<ActionResult> Delete(double? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PriceFiltering priceFiltering = await db.PriceFilterings.FindAsync(id);
            if (priceFiltering == null)
            {
                return HttpNotFound();
            }
            return View(priceFiltering);
        }

        // POST: Admin/PriceFiltering/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(double id)
        {
            PriceFiltering priceFiltering = await db.PriceFilterings.FindAsync(id);
            db.PriceFilterings.Remove(priceFiltering);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
