using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AgroVision.Dto.Models;

[DataContract]
public class LoginCredentials
{
    [Required]
    [DataMember(Name = "login")]
    public string Login { get; set; }
    
    [Required]
    [DataMember(Name = "password")]
    public string Password { get; set; }

    public LoginCredentials(string login, string password)
    {
        Login = login;
        Password = password;
    }
}