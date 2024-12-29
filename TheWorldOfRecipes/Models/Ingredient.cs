namespace TheWorldOfRecipes.Models
{
    public class Ingredient
    {
        public int IngredientID { get; set; } // מפתח ראשי
        public string IngredientName { get; set; } // שם המתכון
        public ICollection<RecipeIngredient> RecipeIngredients { get; set; }// קישור לרכיבים
    }
}
