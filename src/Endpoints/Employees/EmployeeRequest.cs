namespace API_Dotnet6.Endpoints.Employees;

public record EmployeeRequest(string Email, string Password, string Name)
{
}
