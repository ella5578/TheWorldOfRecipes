using System.ComponentModel.DataAnnotations;

namespace EllaRecipes.Shared.Models

{
    public class User
    {
        public int UserID { get; set; }
        public required string Email { get; set; }
        public required string UserName { get; set; }
        public required string PasswordHash { get; set; } 
        public required string PasswordSalt { get; set; } 
        public bool IsAdmin { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateTime RegistrationDate { get; set; }
        public ICollection<RatingAndComment>? RatingsAndComments { get; set; }
    }
}


