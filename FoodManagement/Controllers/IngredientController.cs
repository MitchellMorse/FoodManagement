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
    public class IngredientController : Controller
    {
        private FoodManagementContext db = new FoodManagementContext();

        // GET: Ingredient
        public async Task<ActionResult> Index()
        {
            var ingredients = db.Ingredients.Include(i => i.IngredientType);
            return View(await ingredients.ToListAsync());
        }

        // GET: Ingredient/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingredient ingredient = await db.Ingredients.FindAsync(id);
            if (ingredient == null)
            {
                return HttpNotFound();
            }
            return View(ingredient);
        }

        // GET: Ingredient/Create
        public ActionResult Create()
        {
            ViewBag.IngredientTypeID = new SelectList(db.IngredientTypes, "ID", "Name");
            return View();
        }

        // POST: Ingredient/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name,IngredientTypeID,Description")] Ingredient ingredient)
        {
            if (ModelState.IsValid)
            {
                db.Ingredients.Add(ingredient);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IngredientTypeID = new SelectList(db.IngredientTypes, "ID", "Name", ingredient.IngredientTypeID);
            return View(ingredient);
        }

        // GET: Ingredient/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingredient ingredient = await db.Ingredients.FindAsync(id);
            if (ingredient == null)
            {
                return HttpNotFound();
            }
            ViewBag.IngredientTypeID = new SelectList(db.IngredientTypes, "ID", "Name", ingredient.IngredientTypeID);
            return View(ingredient);
        }

        // POST: Ingredient/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,IngredientTypeID,Description")] Ingredient ingredient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ingredient).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IngredientTypeID = new SelectList(db.IngredientTypes, "ID", "Name", ingredient.IngredientTypeID);
            return View(ingredient);
        }

        // GET: Ingredient/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingredient ingredient = await db.Ingredients.FindAsync(id);
            if (ingredient == null)
            {
                return HttpNotFound();
            }
            return View(ingredient);
        }

        // POST: Ingredient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Ingredient ingredient = await db.Ingredients.FindAsync(id);
            db.Ingredients.Remove(ingredient);
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
