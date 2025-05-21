using System.Collections.Generic;

namespace EllaRecipes.Shared.Models

{
    public class Ingredient
    {
        public int IngredientID { get; set; } // מפתח ראשי
        public required string IngredientName { get; set; } // שם המתכון
        public ICollection<RecipeIngredient>? RecipeIngredients { get; set; }// קישור לרכיבים
    }
}
