namespace PL.Web.Services.Interfaces;

public interface IUserService
{
    #region GET

    public User GetUserById(string id);
    public Task<User> GetUserByIdAsync(string id);
    public User GetUserById(Guid id);
    public Task<User> GetUserByIdAsync(Guid id);
    public User GetUserByLogin(string login);
    public Task<User> GetUserByLoginAsync(string login);

    #endregion

    #region ADD

    public bool AddUser(User user);
    public Task<bool> AddUserAsync(User user);

    public User AddUsers(IEnumerable<User> users);
    public Task<User> AddUsersAsync(IEnumerable<User> users);

    #endregion

    #region REMOVE
    // User
    public bool RemoveUser(User user);
    public Task<bool> RemoveUserAsync(User user);
    public bool RemoveUserById(Guid id);
    public Task<bool> RemoveUserByIdAsync(Guid id);
    // Users
    public bool RemoveUsers(IEnumerable<User> users);
    public Task<bool> RemoveUsersAsync(IEnumerable<User> users);
    public bool RemoveUsersById(IEnumerable<Guid> ids);
    public Task<bool> RemoveUsersByIdAsync(IEnumerable<Guid> ids);

    #endregion
}