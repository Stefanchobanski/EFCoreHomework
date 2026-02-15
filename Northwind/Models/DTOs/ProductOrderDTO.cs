using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Models.DTOs;

public class ProductOrderDTO
{
    public string ProductName {  get; set; }
    public int ProductQuantity {  get; set; }

    public override string ToString()
    {
        return $"{ProductName} - {ProductQuantity}";
    }
}
