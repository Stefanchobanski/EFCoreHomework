using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Models.DTOs;

public class ProductDTO
{
    public string ProductName {  get; set; }
    public decimal? UnitPrice { get; set; }

    public override string ToString()
    {
        return $"{ProductName} - {UnitPrice}";
    }
}
