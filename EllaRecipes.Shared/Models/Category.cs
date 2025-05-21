namespace EllaRecipes.Shared.Models

{
    public class Category
    {
        public int CategoryID { get; set; } // מזהה קטגורייה כללית (מפתח ראשי)
        public required string CategoryName { get; set; } // שם קטגורייה (לדוגמה: קינוחים, בשרי, ארוחת ערב)

        public required string ImageUrl { get; set; }  // הוספת השדה ImageUrl

        // קשר בין קטגוריות כלליות לקטגוריות ספציפיות
        public ICollection<Recipe>? Recipes { get; set; }
    }
}
