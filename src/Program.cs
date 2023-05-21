using API_Dotnet6.Endpoints.Categories;
using API_Dotnet6.Endpoints.Employees;
using API_Dotnet6.Infra.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSqlServer<ApplicationDbContext>(
    builder.Configuration["ConnectionString:ApiDb"]);
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 3;
}).AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapMethods(CategoryPost.Template, CategoryPost.Methods, CategoryPost.Handle);
app.MapMethods(CategoryGetAll.Template, CategoryGetAll.Methods, CategoryGetAll.Handle);
app.MapMethods(CategoryPut.Template, CategoryPut.Methods, CategoryPut.Handle);
app.MapMethods(EmployeesPost.Template, EmployeesPost.Methods, EmployeesPost.Handle);

app.Run();
