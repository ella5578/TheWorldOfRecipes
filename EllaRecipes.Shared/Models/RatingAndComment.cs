
using EllaRecipes.Shared.Models;
using System.ComponentModel.DataAnnotations;

public class RatingAndComment
{
    [Key]
    public int RatingAndCommentID { get; set; }

    public int UserID { get; set; }
    public int RecipeID { get; set; }

    [DisplayFormat(NullDisplayText = "No comment")]
    [StringLength(300, MinimumLength = 5, ErrorMessage = "התגובה חייבת להיות בין 5 ל-300 תווים")]
    public string? Comment { get; set; }

    [DisplayFormat(NullDisplayText = "No rating")]
    public int? Rating { get; set; }

    public User? User { get; set; }
    public Recipe? Recipe { get; set; }
}

