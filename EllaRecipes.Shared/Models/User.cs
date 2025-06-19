using System.ComponentModel.DataAnnotations;

namespace EllaRecipes.Shared.Models

{
    public class User
    {
        public int UserID { get; set; } // מזהה ייחודי למשתמש
        public required string Email { get; set; } // אימייל של המשתמש
        public required string UserName { get; set; } // שם משתמש
        public required string PasswordHash { get; set; } // הסיסמה בהצפנה (Hash)
        public required string PasswordSalt { get; set; } // מלח (Salt) לאבטחת סיסמה
        public bool IsAdmin { get; set; } // האם המשתמש הוא מנהל
        public required string FirstName { get; set; } // שם פרטי
        public required string LastName { get; set; } // שם משפחה
        public DateTime RegistrationDate { get; set; } // תאריך הרשמה
        public ICollection<RatingAndComment>? RatingsAndComments { get; set; } // דירוגים ותגובות של המשתמש
    }

}


