using Microsoft.AspNetCore.Mvc;
using PL.Web.Models;
using PL.Web.Services.Interfaces;

namespace PL.Web.Services.Implements;

public class UserService : IUserService
{
    EShopDbContext _context;
    ILogger<UserService> _logger;

    public UserService(
        [FromServices] EShopDbContext context,
        [FromServices] ILogger<UserService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public bool AddUser(User user)
    {
        var transaction = _context.Database.BeginTransaction();

        try
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Не удалось добавить пользователя: {ex.Message}");
            transaction.Rollback();
        }

        transaction.Commit();
        return true;
    }

    public async Task<bool> AddUserAsync(User user)
    {
        var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Не удалось добавить пользователя: {ex.Message}");
            await transaction.RollbackAsync();
        }

        await transaction.CommitAsync();
        return true;
    }

    public bool AddUsers(IEnumerable<User> users)
    {
        var transaction = _context.Database.BeginTransaction();

        try
        {
            _context.Users.AddRange(users);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Не удалось добавить пользователей: {ex.Message}");
            transaction.Rollback();
        }

        transaction.Commit();

        return true;
    }

    public async Task<bool> AddUsersAsync(IEnumerable<User> users)
    {
        var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            await _context.Users.AddRangeAsync(users);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Не удалось добавить пользователей: {ex.Message}");
            await transaction.RollbackAsync();
        }

        await transaction.CommitAsync();
        return true;
    }

    public User GetUserById(string id)
    {
        var userId = Guid.Parse(id);

        return GetUserById(userId);
    }

    public User GetUserById(Guid id)
    {
        User user = null;

        user = _context.Users.Single(user => user.ObjectID == id);

        return user;
    }

    public async Task<User> GetUserByIdAsync(string id)
    {
        var userId = Guid.Parse(id);

        return await GetUserByIdAsync(userId);
    }

    public async Task<User> GetUserByIdAsync(Guid id)
    {
        User user = null;

        user = await _context.Users.AsQueryable().SingleAsync(user => user.ObjectID == id);

        return user;
    }

    public IEnumerable<User> GetUsersByLogin(string login)
    {
        IEnumerable<User> users;

        users = _context.Users.AsQueryable().Where(user => user.Login.Contains(login));

        return users;
    }

    public async Task<IEnumerable<User>> GetUsersByLoginAsync(string login)
    {
        IEnumerable<User> users;

        users = _context.Users.AsQueryable().Where(user => user.Login.Contains(login));

        return users;
    }

    public bool RemoveUser(User user)
    {
        var transaction = _context.Database.BeginTransaction();
        try
        {
            _context.Users.Remove(user);
        }
        catch
        {
            transaction.Rollback();
            return false;
        }
        transaction.Commit();

        return true;
    }

    public async Task<bool> RemoveUserAsync(User user)
    {
        var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            _context.Users.Remove(user);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Не удалось удалить пользователя: {ex.Message}");
            await transaction.RollbackAsync();
            return false;
        }
        await transaction.CommitAsync();

        return true;
    }

    public bool RemoveUserById(Guid id)
    {
        var user = GetUserById(id);
        return RemoveUser(user);
    }

    public async Task<bool> RemoveUserByIdAsync(Guid id)
    {
        var user = await GetUserByIdAsync(id);
        return await RemoveUserAsync(user);
    }

    public bool RemoveUsers(IEnumerable<User> users)
    {
        var transaction = _context.Database.BeginTransaction();
        try
        {
            _context.Users.RemoveRange(users);
        }
        catch(Exception ex)
        {
            _logger.LogError($"Не удалось удалить пользователей: {ex.Message}");
            transaction.Rollback();
            return false;
        }
        transaction.Commit();

        return true;
    }

    public async Task<bool> RemoveUsersAsync(IEnumerable<User> users)
    {
        var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            _context.Users.RemoveRange(users);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Не удалось удалить пользователей: {ex.Message}");
            await transaction.RollbackAsync();
            return false;
        }
        await transaction.CommitAsync();

        return true;
    }

    public bool RemoveUsersById(IEnumerable<Guid> ids)
    {
        IEnumerable<User> users = _context.Users.Where(u => ids.Contains(u.ObjectID));

        return RemoveUsers(users);
    }

    public async Task<bool> RemoveUsersByIdAsync(IEnumerable<Guid> ids)
    {
        IEnumerable<User> users = _context.Users.Where(u => ids.Contains(u.ObjectID));

        return await RemoveUsersAsync(users);
    }
}