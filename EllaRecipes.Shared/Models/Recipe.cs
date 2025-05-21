using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EllaRecipes.Shared.Models
{
    public class Recipe
    {
 //       [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RecipeID { get; set; } // מפתח ראשי
        public required string RecipeName { get; set; } // שם המתכון
        public string? Description { get; set; } // תיאור המתכון
        public string? VideoURL { get; set; } // קישור לסרטון
        public int TimerMinutes { get; set; } // זמן בישול בדקות
        public int LikesCount { get; set; } // מספר לייקים
        public int CategoryID { get; set; } // מזהה קטגוריה 
        public required Category Category { get; set; }
        //public string? ImageUrl { get; set; } // שדה חדש לתמונה

        //public SpecificCategory SpecificCategory { get; set; } // ניווט לקטגוריה ספציפית
        public ICollection<RatingAndComment> RatingsAndComments { get; set; } // דירוגים ותגובות
        public ICollection<RecipeIngredient> RecipeIngredients { get; set; }// קישור לרכיבים
    }
}
