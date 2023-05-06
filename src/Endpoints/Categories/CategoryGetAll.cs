using API_Dotnet6.Infra.Data;
using API_Dotnet6.Domain.Products;

namespace API_Dotnet6.Endpoints.Categories;

public class CategoryGetAll
{
    public static string Template => "/categories";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;
    public static IResult Action(ApplicationDbContext context)
    {
        var categories = context.Categories.ToList();
        var response = categories.Select(c => new CategoryResponse { Id = c.Id, Name = c.Name, Active = c.Active });

        return Results.Ok(response);
    }
}
