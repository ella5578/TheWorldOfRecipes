namespace EllaRecipes.Shared.Models

{
    public class RecipeIngredient
    {
        public int RecipeIngredientID { get; set; } // מפתח ראשי
        public int IngredientID { get; set; } // מזהה רכיב
        public int RecipeID { get; set; } // מזהה מתכון
        public int Quantity { get; set; } // כמות
        public required string Units { get; set; } // יחידות מידה (למשל: גרם, כוסות)
        public required Ingredient Ingredient { get; set; } // הרכיב עצמו (אובייקט)
        public required Recipe Recipe { get; set; } // המתכון אליו שייך הרכיב
    }

}
