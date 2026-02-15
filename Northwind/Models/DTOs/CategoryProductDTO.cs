using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Models.DTOs;

public class CategoryProductDTO
{
    public string ProductName { get; set; }
    public string CategoryName {  get; set; }

    public override string ToString()
    {
        return $"{ProductName} - {CategoryName}";
    }
}
