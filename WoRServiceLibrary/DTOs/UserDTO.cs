using System;

namespace ServiceLibrary.DTOs
{
    public class UserDTO
    {
        public int UserID { get; set; } // מפתח ראשי
        public string Email { get; set; } // כתובת אימייל
        public string UserName { get; set; } // שם משתמש
        public string Password { get; set; } // סיסמה
        public bool IsAdmin { get; set; } // האם המשתמש הוא מנהל
        public string FirstName { get; set; } // שם פרטי
        public string LastName { get; set; } // שם משפחה
        public DateTime RegistrationDate { get; set; } // תאריך הרשמה
        public DateTime LastLoginDate { get; set; } // תאריך כניסה אחרונה

        public UserDTO() { }

        public UserDTO(Models.User user)
        {
            UserID = user.UserID;
            Email = user.Email;
            UserName = user.UserName;
            Password = user.Password;
            IsAdmin = user.IsAdmin;
            FirstName = user.FirstName;
            LastName = user.LastName;
            RegistrationDate = user.RegistrationDate;
            LastLoginDate = user.LastLoginDate;
        }

        public override string ToString()
        {
            return $"UserID: {UserID}, " +
                $"Email: {Email}, " +
                $"UserName: {UserName}, " +
                $"IsAdmin: {IsAdmin}, " +
                $"FirstName: {FirstName}, " +
                $"LastName: {LastName}, " +
                $"RegistrationDate: {RegistrationDate}, " +
                $"LastLoginDate: {LastLoginDate}";
        }

        //public static implicit operator UserDTO(UserServiceReference.UserDTO v)
        //{
        //    return new UserDTO
        //    {
        //        Id = v.Id,
        //        FirstName = v.FirstName,
        //        LastName = v.LastName,
        //        UserName = v.UserName,
        //        BirthDate = v.BirthDate,
        //        Email = v.Email,
        //        IsAdmin = v.IsAdmin
        //    };
        //}
    }

    //public class UserDTOConverter
    //{
    //    public static List<UserDTO> ConvertAll(List<UserServiceReference.UserDTO> userDTOs)
    //    {
    //        return userDTOs.ConvertAll(user => (UserDTO)user);
    //    }
    //}
}
