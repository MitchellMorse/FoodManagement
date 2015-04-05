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
using FoodManagement.ViewModels;

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

        //Working on getting the edit view to have a grid showing ingredients linked to this recipe
        //Want another grid that is sortable and filterable that shows all ingredients not linked to this recipe, should be selectable
        //Need to show cook type, cook time, and prep time
        //way to save
        // GET: Recipe/Edit/5
        public async Task<ActionResult> RecipeIngredients(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var viewModel = new RecipeIngredients();
            Recipe recipe = await db.Recipes.FindAsync(id);

            //TODO: this attempt to implement eager loading did not work.  Need to run sql profiler to see how many times this action causes us to hit the DB and see if eager loading can shrink that
            //    db.Recipes.Include(r => r.ID == id).Include(r => r.RecipeIngredients.Select(i => i.Ingredient)).Single();
            //viewModel.CurrentRecipe = db.Recipes.Include(r => r.ID == id).Include(r => r.RecipeIngredients).SingleOrDefault();

            //Recipe recipe = await db.Recipes.FindAsync(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }

            IEnumerable<int> idsOfIngredientsLinkedToThisRecipe = (from i in db.RecipeIngredients
                                                                   where i.RecipeID == id
                                                                   select i.IngredientID);

            viewModel.CurrentRecipe = recipe;
            viewModel.IngredientsForRecipe = db.Ingredients.Where(i => idsOfIngredientsLinkedToThisRecipe.Contains(i.ID));
            viewModel.UnusedIngredients = db.Ingredients.Where(i => !idsOfIngredientsLinkedToThisRecipe.Contains(i.ID));

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RecipeIngredients([Bind(Include = "ID,Name")] RecipeIngredients recipeIngredients)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Entry(recipe).State = EntityState.Modified;
            //    await db.SaveChangesAsync();
            //    return RedirectToAction("Index");
            //}
            //ViewBag.CookTimeTypeId = new SelectList(db.TimeTypes, "ID", "Name", recipe.CookTimeTypeId);
            //ViewBag.CookTypeId = new SelectList(db.CookTypes, "ID", "Name", recipe.CookTypeId);
            //ViewBag.PrepTimeTypeId = new SelectList(db.TimeTypes, "ID", "Name", recipe.PrepTimeTypeId);
            //return View(recipe);
            return View(recipeIngredients);
        }

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
