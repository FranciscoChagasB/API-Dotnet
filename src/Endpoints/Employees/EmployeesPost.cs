using API_Dotnet6.Infra.Data;
using API_Dotnet6.Domain.Products;
using Microsoft.AspNetCore.Identity;

namespace API_Dotnet6.Endpoints.Employees;

public class EmployeesPost
{
    public static string Template => "/employees";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;
    public static IResult Action(EmployeeRequest employeeRequest, UserManager<IdentityUser> userManager)
    {
        var user = new IdentityUser { UserName = employeeRequest.Email, Email = employeeRequest.Email };
        var result = userManager.CreateAsync(user, employeeRequest.Password).Result;

        if (!result.Succeeded)
            return Results.BadRequest(result.Errors.First());

        return Results.Created($"/employees/{user.Id}", user.Id);
    }
}
