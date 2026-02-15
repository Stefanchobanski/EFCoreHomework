using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Models.DTOs;

public class CustomerOrderDTO
{
    public string CustomerId { get; set; }
    public int OrdersCount {  get; set; }

    public override string ToString()
    {
        return $"{CustomerId} - {OrdersCount}";
    }
}
