using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

public class UserAuth
{
    public string Username { get; set; } = "";
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";
    public string Roles { get; set; } = "";

    // Parameterless constructor
    public UserAuth()
    {
    }

    public ClaimsPrincipal ToClaimsPrincipal() => new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
    {
        new(ClaimTypes.Name, Username),
        new(ClaimTypes.Hash, Password),
        new(ClaimTypes.Email, Email),
        new(ClaimTypes.Role, Roles)
    },"EducationGuide"));

    public static UserAuth FromClaimsPrincipal(ClaimsPrincipal principal) => new UserAuth
    {
        Username = principal.FindFirst(ClaimTypes.Name)?.Value ?? "",
        Password = principal.FindFirst(ClaimTypes.Hash)?.Value ?? "",
        Email = principal.FindFirst(ClaimTypes.Email)?.Value ?? "",
        Roles = principal.FindFirst(ClaimTypes.Role)?.Value ?? ""
    };
}
