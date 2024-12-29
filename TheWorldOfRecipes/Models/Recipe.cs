using System.ComponentModel.DataAnnotations.Schema;

namespace TheWorldOfRecipes.Models
{
    public class Recipe
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RecipeID { get; set; } // מפתח ראשי
        public string RecipeName { get; set; } // שם המתכון
        public string Description { get; set; } // תיאור המתכון
        public string VideoURL { get; set; } // קישור לסרטון
        public int TimerMinutes { get; set; } // זמן בישול בדקות
        public int SpecificCategoryID { get; set; } // מזהה קטגוריה ספציפית
        public int LikesCount { get; set; } // מספר לייקים

        //public SpecificCategory SpecificCategory { get; set; } // ניווט לקטגוריה ספציפית
        public ICollection<RatingAndComment> RatingsAndComments { get; set; } // דירוגים ותגובות
    }

}
