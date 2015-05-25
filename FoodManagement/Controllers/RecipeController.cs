using FoodManagement.DAL;
using FoodManagement.ExtensionMethods;
using FoodManagement.Models;
using FoodManagement.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

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
        public async Task<ActionResult> RecipeIngredients(int? id, string unusedIngredientSort, string currentUnusedFilter, string ingredientsForRecipeSort, string currentIngredientsForRecipeFilter)
        {
            ViewBag.UnusedNameSort = string.IsNullOrWhiteSpace(unusedIngredientSort) ? Ingredient._strDescNameSort : "";
            ViewBag.UnusedTypeSort = unusedIngredientSort == Ingredient._strAscTypeSort ? Ingredient._strDescTypeSort : Ingredient._strAscTypeSort;
            ViewBag.CurrentUnusedFilter = currentUnusedFilter;

            ViewBag.UsedNameSort = string.IsNullOrWhiteSpace(ingredientsForRecipeSort) ? Ingredient._strDescNameSort : "";
            ViewBag.UsedTypeSort = ingredientsForRecipeSort == Ingredient._strAscTypeSort ? Ingredient._strDescTypeSort : Ingredient._strAscTypeSort;
            ViewBag.CurrentUsedFilter = currentIngredientsForRecipeFilter;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var viewModel = new RecipeIngredients();
            Recipe recipe = await db.Recipes.FindAsync(id);

            if (recipe == null)
            {
                return HttpNotFound();
            }

            IEnumerable<int> idsOfIngredientsLinkedToThisRecipe = (from i in db.RecipeIngredients
                                                                   where i.RecipeID == id
                                                                   select i.IngredientID);

            viewModel.CurrentRecipe = recipe;
            viewModel.IngredientsForRecipe = db.Ingredients.Where(i => idsOfIngredientsLinkedToThisRecipe.Contains(i.ID)).ApplyFilter(currentIngredientsForRecipeFilter).SortList(ingredientsForRecipeSort);
            viewModel.UnusedIngredients = db.Ingredients.Where(i => !idsOfIngredientsLinkedToThisRecipe.Contains(i.ID)).ApplyFilter(currentUnusedFilter).SortList(unusedIngredientSort);

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

        [HttpPost, ActionName("AddIngredientToRecipe")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddIngredientToRecipe(int recipeId, int ingredientId)
        {
            //check to see if this relationship already exists.  If so, we are done
            int existingId = (from ri in db.RecipeIngredients
                              where ri.RecipeID == recipeId && ri.IngredientID == ingredientId
                              select ri.ID).FirstOrDefault();

            if (existingId > 0)
            {
                return RedirectToAction("RecipeIngredients", new { id = recipeId });
            }

            RecipeIngredient recipeIngredient = new RecipeIngredient()
            {
                IngredientID = ingredientId,
                RecipeID = recipeId,
                Quantity = 1,
                QuantityTypeID = 1 //TODO: modify the UI so that this can be set when adding the ingredient
            };

            db.RecipeIngredients.Add(recipeIngredient);
            await db.SaveChangesAsync();
            return RedirectToAction("RecipeIngredients", new { id = recipeId });
        }

        [HttpPost, ActionName("RemoveIngredientFromRecipe")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RemoveIngredientFromRecipe(int recipeId, int ingredientId)
        {
            //check to see if this relationship already exists.  If not, we are done
            RecipeIngredient link = (from ri in db.RecipeIngredients
                              where ri.RecipeID == recipeId && ri.IngredientID == ingredientId
                              select ri).FirstOrDefault();

            if (link == null)
            {
                return RedirectToAction("RecipeIngredients", new { id = recipeId });
            }

            db.RecipeIngredients.Remove(link);
            await db.SaveChangesAsync();
            return RedirectToAction("RecipeIngredients", new { id = recipeId });
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
