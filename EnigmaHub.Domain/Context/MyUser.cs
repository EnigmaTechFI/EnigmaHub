using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace EnigmaHub.Domain.Context;

public class MyUser : IdentityUser
{
    [MaxLength(30)]
    public string FirstName { get; set; }
    [MaxLength(30)]
    public string LastName { get; set; }

    public string FullName => FirstName + " " + LastName;
    
    [MaxLength(10)]
    public string? Language { get; set; }
}