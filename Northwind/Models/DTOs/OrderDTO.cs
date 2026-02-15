using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Models.DTOs;

public class OrderDTO
{
    public int OrderId { get; set; }
    public string CustomerId {  get; set; }
    public DateTime? OrderDate {  get; set; }

    public override string ToString()
    {
        return $"{OrderId} - {CustomerId} - {OrderDate}";
    }
}
