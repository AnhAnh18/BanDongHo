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
using TNAShop.Filters;

namespace TNAShop.Areas.Admin.Controllers
{
    [AdminFilter]
    public class StrapController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Strap
        public async Task<ActionResult> Index()
        {
            return View(await db.Straps.ToListAsync());
        }

        // GET: Admin/Strap/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Strap strap = await db.Straps.FindAsync(id);
            if (strap == null)
            {
                return HttpNotFound();
            }
            return View(strap);
        }

        // GET: Admin/Strap/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Strap/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,StrapName")] Strap strap)
        {
            if (ModelState.IsValid)
            {
                db.Straps.Add(strap);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(strap);
        }

        // GET: Admin/Strap/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Strap strap = await db.Straps.FindAsync(id);
            if (strap == null)
            {
                return HttpNotFound();
            }
            return View(strap);
        }

        // POST: Admin/Strap/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,StrapName")] Strap strap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(strap).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(strap);
        }

        // GET: Admin/Strap/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Strap strap = await db.Straps.FindAsync(id);
            if (strap == null)
            {
                return HttpNotFound();
            }
            return View(strap);
        }

        // POST: Admin/Strap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Strap strap = await db.Straps.FindAsync(id);
            db.Straps.Remove(strap);
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
