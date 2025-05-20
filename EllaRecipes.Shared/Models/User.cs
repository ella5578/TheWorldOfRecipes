using System.ComponentModel.DataAnnotations;

namespace EllaRecipes.Shared.Models

{
    public class User
    {
        public int UserID { get; set; } // מפתח ראשי

        [Required(ErrorMessage = "כתובת האימייל היא חובה.")]
        [EmailAddress(ErrorMessage = "כתובת האימייל אינה תקינה.")]
        public required string Email { get; set; } // כתובת אימייל

        [Required(ErrorMessage = "שם משתמש הוא חובה.")]
        [StringLength(50, ErrorMessage = "שם המשתמש חייב להיות באורך של עד 50 תווים.")]
        public required string UserName { get; set; } // שם משתמש

        [Required(ErrorMessage = "סיסמה היא חובה.")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "הסיסמה חייבת להיות בין 6 ל-20 תווים.")]
        public required string Password { get; set; } // סיסמה

        public bool IsAdmin { get; set; } // האם המשתמש הוא מנהל

        [Required(ErrorMessage = "שם פרטי הוא חובה.")]
        [StringLength(50, ErrorMessage = "שם פרטי חייב להיות באורך של עד 50 תווים.")]
        public required string FirstName { get; set; } // שם פרטי

        [Required(ErrorMessage = "שם משפחה הוא חובה.")]
        [StringLength(50, ErrorMessage = "שם משפחה חייב להיות באורך של עד 50 תווים.")]
        public required string LastName { get; set; } // שם משפחה

        [Required(ErrorMessage = "תאריך ההרשמה הוא חובה.")]
        [DataType(DataType.Date, ErrorMessage = "תאריך ההרשמה אינו תקין.")]
        public DateTime RegistrationDate { get; set; } // תאריך הרשמה

        public ICollection<RatingAndComment> RatingsAndComments { get; set; } // דירוגים ותגובות שהמשתמש יצר
    }
}


