using System;
using System.Collections.Generic;

namespace ServiceLibrary.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public required string PasswordSalt { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime RegistrationDate { get; set; }
        public override string ToString()
        {
            return $"ID:\t {this.Id}\n" +
                   $"First Name:\t {this.FirstName}\n" +
                   $"Last Name:\t {this.LastName}\n" +
                   $"Username:\t {this.UserName}\n" +
                   $"PasswordHash:\t {this.PasswordHash}\n" +
                   $"PasswordSalt:\t {this.PasswordSalt}\n" +
                   $"Email:\t {this.Email}\n" +
                   $"Is Admin:\t {this.IsAdmin}\n" +
                   $"Regitration Date:\t {this.RegistrationDate}\n";
        }

        //    public static implicit operator UserDTO(UserServiceReference.UserDTO v)
        //    {
        //        return new UserDTO
        //        {
        //            Id = v.Id,
        //            FirstName = v.FirstName,
        //            LastName = v.LastName,
        //            UserName = v.UserName,
        //            PasswordHash = v.PasswordHash,
        //            PasswordSalt = v.PasswordSalt,
        //            BirthDate = v.BirthDate,
        //            Email = v.Email,
        //            IsAdmin = v.IsAdmin,
        //            RequirePasswordChangeOnFirstLogin = v.RequirePasswordChangeOnFirstLogin
        //        };
        //    }
    }

    //public class UserDTOConverter
    //{
    //    public static List<UserDTO> ConvertAll(List<UserServiceReference.UserDTO> userDTOs)
    //    {
    //        return userDTOs.ConvertAll(user => (UserDTO)user);
    //    }
    //}
}
