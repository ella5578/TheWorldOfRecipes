using EllaRecipes.Shared.Data;
using ServiceLibrary.Contracts;
using ServiceLibrary.DTOs;
using ServiceLibrary.Helpers;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using EllaRecipes.Shared.Models; // Add this using directive for EF Core async methods

namespace ServiceLibrary.Implementations
{
    public static class DatabaseHelper
    {
        private static readonly IConfiguration _configuration;

        static DatabaseHelper()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            _configuration = builder.Build();
        }

        public static SqlConnection GetSqlConnection()
        {
            string? connStr = _configuration.GetConnectionString("DbConnection");
            if (string.IsNullOrEmpty(connStr))
            {
                throw new InvalidOperationException("Connection string 'DbConnection' is not configured.");
            }
            return new SqlConnection(connStr); // Use Microsoft.Data.SqlClient.SqlConnection
        }
    }

    public class UserService : IUserService
    {
        private readonly TheWorldOfRecipesContext _db;

        public UserService(TheWorldOfRecipesContext db)
        {
            _db = db;
        }

        public async Task<UserDTO> LoginAsync(string username, string password)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.UserName == username);
            if (user == null)
                throw new InvalidOperationException("User not found");

            if (PasswordHelper.VerifyPassword(password, user.PasswordHash, user.PasswordSalt))
            {
                return new UserDTO
                {
                    Id = user.UserID,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    Email = user.Email,
                    IsAdmin = user.IsAdmin,
                    PasswordHash = user.PasswordHash,
                    PasswordSalt = user.PasswordSalt
                };
            }
            throw new UnauthorizedAccessException("Invalid password");
        }

        public async Task<List<UserDTO>> GetAllUsersAsync()
        {
            return await _db.Users
                .Select(u => new UserDTO
                {
                    Id = u.UserID,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    UserName = u.UserName,
                    Email = u.Email,
                    IsAdmin = u.IsAdmin,
                    PasswordHash = u.PasswordHash, // Fix for CS9035
                    PasswordSalt = u.PasswordSalt  // Fix for CS9035
                })
                .ToListAsync();
        }

        public async Task<UserDTO> RegisterUserAsync(UserDTO userDTO)
        {
            try
            {
                var user = new User
                {
                    FirstName = userDTO.FirstName,
                    LastName = userDTO.LastName,
                    UserName = userDTO.UserName,
                    Email = userDTO.Email,
                    PasswordHash = userDTO.PasswordHash,
                    PasswordSalt = userDTO.PasswordSalt,
                    IsAdmin = userDTO.IsAdmin,
                };
                _db.Users.Add(user);
                await _db.SaveChangesAsync();

                userDTO.Id = user.UserID;
                userDTO.RequirePasswordChangeOnFirstLogin = false;
                return userDTO;
            }
            catch (Exception ex)
            {
                LogError("RegisterUserAsync failed", ex);
                throw; // Re-throw the exception to ensure the method does not return null
            }
        }

        private void LogError(string message, Exception ex)
        {
            string logFilePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "error_log.txt");
            System.IO.File.AppendAllText(logFilePath, $"{DateTime.Now}: {message}\n{ex.StackTrace}\n");
        }

        public async Task<bool> UpdateUserAsync(UserDTO user)
        {
            var dbUser = await _db.Users.FindAsync(user.Id);
            if (dbUser == null) return false;

            dbUser.FirstName = user.FirstName;
            dbUser.LastName = user.LastName;
            dbUser.Email = user.Email;
            dbUser.IsAdmin = user.IsAdmin;

            try
            {
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                LogError("UpdateUserAsync failed", ex);
                return false;
            }
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            var dbUser = await _db.Users.FindAsync(userId);
            if (dbUser == null) return false;

            _db.Users.Remove(dbUser);
            try
            {
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                LogError("DeleteUserAsync failed", ex);
                return false;
            }
        }

        public async Task<bool> ResetPasswordAsync(int userId, string newPassword)
        {
            var dbUser = await _db.Users.FindAsync(userId);
            if (dbUser == null) return false;

            var passwordHashSalt = PasswordHelper.HashPassword(newPassword);
            dbUser.PasswordHash = passwordHashSalt.hash;
            dbUser.PasswordSalt = passwordHashSalt.salt;

            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<UserDTO> GetUserByIdAsync(int userId)
        {
            var user = await _db.Users.FindAsync(userId);
            if (user == null)
            {
                throw new InvalidOperationException("User not found");
            }

            return new UserDTO
            {
                Id = user.UserID,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                IsAdmin = user.IsAdmin,
                PasswordHash = user.PasswordHash,
                PasswordSalt = user.PasswordSalt,
            };
        }

        public UserDTO GetUserByUsername(string userName)
        {
            var user = _db.Users.FirstOrDefault(u => u.UserName == userName);
            if (user == null)
            {
                throw new InvalidOperationException("User not found");
            }

            return new UserDTO
            {
                Id = user.UserID,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
                PasswordSalt = user.PasswordSalt,
                IsAdmin = user.IsAdmin,
            };
        }
    }
}