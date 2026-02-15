using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Models.DTOs;

public class CustomerDTO
{
    public string CustomerId {  get; set; }
    public string CompanyName { get; set; }
    public string Country {  get; set; }

    public override string ToString()
    {
        if(CustomerId == null)
        {
            return $"{CompanyName} - {Country}";
        }
        return $"{CustomerId} - {CompanyName} - {Country}";
    }
}
