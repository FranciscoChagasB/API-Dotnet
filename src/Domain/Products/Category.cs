﻿namespace API_Dotnet6.Domain.Products;

public class Category : Entity
{
    public string Name { get; set; }
    public bool Active { get; set; } = true;

}
