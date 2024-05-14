using NoteExam.Models;

namespace NoteExam.Persistence.Repositories;

public interface IUserRepository
{
    /// <summary>
    /// Add a new user to the database
    /// </summary>
    /// <param name="user">User to add</param>
    /// <returns>Returns the added user or null if the user already exists</returns>
    Task<User?> AddUserAsync(User user);
    /// <summary>
    /// Get a user by their Id
    /// </summary>
    /// <param name="id">Id of the user</param>
    /// <returns>Returns the user or null if the user does not exist</returns>
    Task<User?> GetUserByIdAsync(Guid id);
    /// <summary>
    /// Get a user by their username
    /// </summary>
    /// <param name="username">Username of the user</param>
    /// <returns>Returns the user or null if the user does not exist</returns>
    Task<User?> GetUserByUsernameAsync(string username);
    /// <summary>
    /// Get a specific number of users from the database
    /// </summary>
    /// <param name="skip">Number of users to skip</param>
    /// <param name="take">Number of users to take</param>
    /// <returns>Returns a list of users</returns>
    Task<IEnumerable<User>> GetUsersAsync(int skip, int take);
    /// <summary>
    /// Update a user in the database
    /// </summary>
    /// <param name="user">User to update</param>
    /// <returns>Returns the updated user or null if the user does not exist</returns>
    Task<User?> UpdateUserAsync(User user);
    /// <summary>
    /// Delete a user from the database
    /// </summary>
    /// <param name="id">Id of the user to delete</param>
    /// <returns>Returns true if the user was deleted, false if the user does not exist</returns>
    Task<bool> DeleteUserAsync(Guid id);
}
