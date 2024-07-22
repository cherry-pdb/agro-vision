namespace AgroVision.Core.Models;

public class UserCore
{
    public Guid Id { get; set; }
    
    public string Login { get; set; }
    
    public string Password { get; set; }

    public UserCore(Guid id, string login, string password)
    {
        Id = id;
        Login = login;
        Password = password;
    }
}