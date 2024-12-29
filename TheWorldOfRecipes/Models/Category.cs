namespace TheWorldOfRecipes.Models
{
    public class Category
    {
        public int CategoryID { get; set; } // מזהה קטגורייה כללית (מפתח ראשי)
        public string CategoryName { get; set; } // שם קטגורייה (לדוגמה: קינוחים, בשרי, ארוחת ערב)

        // קשר בין קטגוריות כלליות לקטגוריות ספציפיות
        public ICollection<Recipe> Recipes { get; set; }
    }
}
