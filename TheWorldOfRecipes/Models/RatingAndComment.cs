using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace TheWorldOfRecipes.Models
{
    public class RatingAndComment
    {
        [Key]
        public int RatingID { get; set; }  // זהו מפתח ראשי

        public int UserID { get; set; } // מפתח זר למשתמש
        public int RecipeID { get; set; } // מפתח זר למתכון

        [DisplayFormat(NullDisplayText = "No comment")]
        public string? Comment { get; set; } // תגובה טקסטואלית
        [DisplayFormat(NullDisplayText = "No rating")]
        public int? Rating { get; set; } // דירוג (1-5 כוכבים)
       
        public User User { get; set; } // ניווט למשתמש
        public Recipe Recipe { get; set; } // ניווט למתכון
    }

}
