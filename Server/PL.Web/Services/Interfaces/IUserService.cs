namespace PL.Web.Services.Interfaces;

public interface IUserService
{
    #region GET

    public User GetUserById(string id);
    public Task<User> GetUserByIdAsync(string id);
    public User GetUserById(Guid id);
    public Task<User> GetUserByIdAsync(Guid id);
    public IEnumerable<User> GetUsersByLogin(string login);
    public Task<IEnumerable<User>> GetUsersByLoginAsync(string login);

    #endregion

    #region ADD

    public bool AddUser(User user);
    public Task<bool> AddUserAsync(User user);

    public bool AddUsers(IEnumerable<User> users);
    public Task<bool> AddUsersAsync(IEnumerable<User> users);

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