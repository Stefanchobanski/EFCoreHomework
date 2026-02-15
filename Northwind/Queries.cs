using Northwind.Models;
using Northwind.Models.DTOs;

namespace Northwind;

public static class Queries
{
    public static List<CustomerDTO> GetAllCustomers(NorthwindContext db)
    {
        return db.Customers.Select(c =>
        new CustomerDTO()
        {
            CompanyName = c.CompanyName,
            Country = c.Country,
            CustomerId = c.CustomerId
        })
            .ToList();
    }

    public static List<CustomerDTO> GetAllCustomersSorted(NorthwindContext db)
    {
        return db.Customers.Select(c =>
        new CustomerDTO()
        {
            CompanyName = c.CompanyName,
            Country = c.Country
        })
            .OrderBy(c => c.Country)
            .ThenBy(c => c.CompanyName)
            .ToList();
    }

    public static List<EmployeeDTO> GetAllEmployees(NorthwindContext db)
    {
        return db.Employees.Select(e =>
        new EmployeeDTO()
        {
            FirstName = e.FirstName,
            LastName = e.LastName,
            Title = e.Title
        })
            .ToList();
    }

    public static List<CategoryProductDTO> GetAllProduct(NorthwindContext db)
    {
        return db.Products.Select(p =>
        new CategoryProductDTO()
        {
            CategoryName = p.Category.CategoryName,
            ProductName = p.ProductName
        })
            .Where(cp => cp.CategoryName == "Beverages")
            .ToList();
    }

    public static List<ProductDTO> GetFilteredProductByPrice(NorthwindContext db, decimal price = 30)
    {
        return db.Products.Where(p => p.UnitPrice > price)
            .Select(p =>
        new ProductDTO()
        {
            ProductName = p.ProductName,
            UnitPrice = p.UnitPrice
        })
            .ToList();
    }

    public static List<OrderDTO> GetOrdersAfterYear(NorthwindContext db, int year = 1997)
    {
        return db.Orders.Where(o => o.OrderDate.Value.Year > year)
            .Select(o =>
        new OrderDTO()
        {
            OrderId = o.OrderId,
            OrderDate = o.OrderDate,
            CustomerId = o.CustomerId
        })
            .ToList();
    }

    public static List<CustomerOrderDTO> GetCustomersOrders(NorthwindContext db, int count = 10)
    {
        return db.Customers.Select(c =>
        new CustomerOrderDTO()
        {
            CustomerId = c.CustomerId,
            OrdersCount = c.Orders.Count
        })
            .OrderByDescending(c => c.OrdersCount)
            .Take(count)
            .ToList();
    }

    public static List<OrderTotalDTO> GetIncomeOrders(NorthwindContext db, int count = 10)
    {
        return db.Orders.Select(o =>
        new OrderTotalDTO()
        {
            OrderId = o.OrderId,
            Total = o.OrderDetails.Sum(od => od.UnitPrice * od.Quantity * (1 - (decimal)od.Discount))
        })
            .OrderByDescending(o => o.Total)
            .Take(count)
            .ToList();
    }

    public static List<CustomerOrderDTO> GetCustomersWithMoreThanOrders(NorthwindContext db, int count = 10)
    {
        return db.Customers.Select(c => 
        new CustomerOrderDTO()
        {
            CustomerId = c.CustomerId,
            OrdersCount = c.Orders.Count
        })
            .Where(c => c.OrdersCount > count)
            .OrderByDescending(c => c.OrdersCount)
            .ToList();
    }

    public static List<ProductOrderDTO> GetTopProductsByQuantity(NorthwindContext db, int count = 5)
    {
        return db.Products.Select(p =>  
        new ProductOrderDTO()
        {
            ProductName = p.ProductName,
            ProductQuantity = p.OrderDetails.Sum(od => od.Quantity)
        })
            .OrderByDescending(p => p.ProductQuantity)
            .Take(count)
            .ToList();
    }
}
