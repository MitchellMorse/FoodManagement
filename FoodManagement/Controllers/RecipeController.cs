using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FoodManagement.DAL;
using FoodManagement.Models;

namespace FoodManagement.Controllers
{
    public class RecipeController : Controller
    {
        private FoodManagementContext db = new FoodManagementContext();

        // GET: Recipe
        public async Task<ActionResult> Index()
        {
            var recipes = db.Recipes.Include(r => r.CookTimeType).Include(r => r.CookType).Include(r => r.PrepTimeType);
            return View(await recipes.ToListAsync());
        }

        // GET: Recipe/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = await db.Recipes.FindAsync(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // GET: Recipe/Create
        public ActionResult Create()
        {
            ViewBag.CookTimeTypeId = new SelectList(db.TimeTypes, "ID", "Name");
            ViewBag.CookTypeId = new SelectList(db.CookTypes, "ID", "Name");
            ViewBag.PrepTimeTypeId = new SelectList(db.TimeTypes, "ID", "Name");
            return View();
        }

        // POST: Recipe/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name,CountUsed,PrepTime,PrepTimeTypeId,CookTime,CookTimeTypeId,CookTypeId")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                db.Recipes.Add(recipe);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CookTimeTypeId = new SelectList(db.TimeTypes, "ID", "Name", recipe.CookTimeTypeId);
            ViewBag.CookTypeId = new SelectList(db.CookTypes, "ID", "Name", recipe.CookTypeId);
            ViewBag.PrepTimeTypeId = new SelectList(db.TimeTypes, "ID", "Name", recipe.PrepTimeTypeId);
            return View(recipe);
        }

        // GET: Recipe/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = await db.Recipes.FindAsync(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            ViewBag.CookTimeTypeId = new SelectList(db.TimeTypes, "ID", "Name", recipe.CookTimeTypeId);
            ViewBag.CookTypeId = new SelectList(db.CookTypes, "ID", "Name", recipe.CookTypeId);
            ViewBag.PrepTimeTypeId = new SelectList(db.TimeTypes, "ID", "Name", recipe.PrepTimeTypeId);
            return View(recipe);
        }

        // POST: Recipe/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,CountUsed,PrepTime,PrepTimeTypeId,CookTime,CookTimeTypeId,CookTypeId")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recipe).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CookTimeTypeId = new SelectList(db.TimeTypes, "ID", "Name", recipe.CookTimeTypeId);
            ViewBag.CookTypeId = new SelectList(db.CookTypes, "ID", "Name", recipe.CookTypeId);
            ViewBag.PrepTimeTypeId = new SelectList(db.TimeTypes, "ID", "Name", recipe.PrepTimeTypeId);
            return View(recipe);
        }

        // GET: Recipe/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = await db.Recipes.FindAsync(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // POST: Recipe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Recipe recipe = await db.Recipes.FindAsync(id);
            db.Recipes.Remove(recipe);
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
