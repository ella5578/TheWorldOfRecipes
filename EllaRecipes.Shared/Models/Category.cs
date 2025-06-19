namespace EllaRecipes.Shared.Models

{
    public class Category
    {
        public int CategoryID { get; set; } // מזהה קטגוריה (מפתח ראשי)
        public required string CategoryName { get; set; } // שם הקטגוריה (למשל: קינוחים, בשרי)
        public required string ImageUrl { get; set; } // כתובת לתמונת הקטגוריה
        public ICollection<Recipe>? Recipes { get; set; } // מתכונים השייכים לקטגוריה זו
    }

}
