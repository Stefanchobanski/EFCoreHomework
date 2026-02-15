using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Northwind.Models.DTOs;

public class OrderTotalDTO
{
    public int OrderId {  get; set; }
    public decimal Total { get; set; }

    public override string ToString()
    {
        return $"{OrderId} - {Total}";
    }
}
