﻿namespace OnlineShop.Application.Products.Dto;
public class ProductInputDto
{
    public int Id { get; set; }
    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public int Stock { get; set; }

    public string Category { get; set; }
}
