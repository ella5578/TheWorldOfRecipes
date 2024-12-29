namespace TheWorldOfRecipes.Models
{
    public class RecipeIngredient
    {
        public int RecipeIngredientID { get; set; } // מפתח ראשי
        public int IngredientID { get; set; } // 
        public int RecipeID { get; set; }
        public int Quantity {  get; set; }  //כמות
        public string Units { get; set; }  //יחידות מידה  
        public Ingredient Ingredient { get; set; }
        public Recipe Recipe { get; set; }
    }
}
