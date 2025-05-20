namespace EllaRecipes.Shared.Models

{
    public class RecipeIngredient
    {
        public int RecipeIngredientID { get; set; } // מפתח ראשי
        public int IngredientID { get; set; } // 
        public int RecipeID { get; set; }
        public int Quantity {  get; set; }  //כמות
        public required string Units { get; set; }  //יחידות מידה  
        public required Ingredient Ingredient { get; set; }
        public required Recipe Recipe { get; set; }
    }
}
