using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Models.DTOs;

public class EmployeeDTO
{
    public string FirstName {  get; set; }
    public string LastName { get; set; } 
    public string Title {  get; set; }

    public override string ToString()
    {
        return $"{FirstName} - {LastName} - {Title}";
    }
}
