using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EllaRecipes.Shared.Models
{
    public class Recipe
    {

        public int RecipeID { get; set; } // מפתח ראשי
        public required string RecipeName { get; set; } // שם המתכון
        public string? Description { get; set; } // תיאור המתכון
        public string? VideoURL { get; set; } // קישור לסרטון
        public int TimerMinutes { get; set; } // זמן בישול בדקות
        public int LikesCount { get; set; } // מספר לייקים
        public int CategoryID { get; set; } // מזהה קטגוריה 
        public required Category Category { get; set; } // קטגוריה שהמתכון שייך אליה
        public string? ImageUrl { get; set; } // כתובת URL לתמונה
        public ICollection<RatingAndComment> RatingsAndComments { get; set; } // דירוגים ותגובות למתכון
        public ICollection<RecipeIngredient> RecipeIngredients { get; set; } // רכיבי המתכון

    }

}
