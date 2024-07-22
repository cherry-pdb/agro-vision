namespace AgroVision.Database.Models;

public class UserDb
{
    public Guid Id { get; set; }
    
    public string Login { get; set; }
    
    public string Password { get; set; }

    public UserDb(Guid id, string login, string password)
    {
        Id = id;
        Login = login;
        Password = password;
    }
}