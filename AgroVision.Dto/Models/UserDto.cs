using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AgroVision.Dto.Models;

[DataContract]
public class UserDto
{
    [Required]
    [DataMember(Name = "id")]
    public Guid Id { get; set; }
    
    [Required]
    [DataMember(Name = "login")]
    public string Login { get; set; }
    
    [Required]
    [DataMember(Name = "password")]
    public string Password { get; set; }

    public UserDto(Guid id, string login, string password)
    {
        Id = id;
        Login = login;
        Password = password;
    }
}