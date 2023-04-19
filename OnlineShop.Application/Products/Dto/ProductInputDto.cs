﻿using OnlineShop.Domain.Entities.Products;

namespace OnlineShop.Application.Products.Dto;
public class ProductInputDto
{
    public int Id { get; set; }
    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public int Stock { get; set; }

    public Category Category { get; set; }

    public string ImageUri { get; set; }
}
