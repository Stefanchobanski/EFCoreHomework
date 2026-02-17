using Northwind.Models;
using Northwind.Models.DTOs;

namespace Northwind;

public class Queries
{
    private readonly NorthwindContext _db;

    public Queries(NorthwindContext db)
    {
        _db = db;
    }

    public List<CustomerDTO> GetAllCustomers()
    {
        return _db.Customers.Select(c =>
        new CustomerDTO()
        {
            CompanyName = c.CompanyName,
            Country = c.Country,
            CustomerId = c.CustomerId
        })
            .ToList();
    }

    public List<CustomerDTO> GetAllCustomersSorted()
    {
        return _db.Customers.Select(c =>
        new CustomerDTO()
        {
            CompanyName = c.CompanyName,
            Country = c.Country
        })
            .OrderBy(c => c.Country)
            .ThenBy(c => c.CompanyName)
            .ToList();
    }

    public List<EmployeeDTO> GetAllEmployees()
    {
        return _db.Employees.Select(e =>
        new EmployeeDTO()
        {
            FirstName = e.FirstName,
            LastName = e.LastName,
            Title = e.Title
        })
            .ToList();
    }

    public List<CategoryProductDTO> GetAllProduct()
    {
        return _db.Products.Select(p =>
        new CategoryProductDTO()
        {
            CategoryName = p.Category.CategoryName,
            ProductName = p.ProductName
        })
            .Where(cp => cp.CategoryName == "Beverages")
            .ToList();
    }

    public  List<ProductDTO> GetFilteredProductByPrice(decimal price = 30)
    {
        return _db.Products.Where(p => p.UnitPrice > price)
            .Select(p =>
        new ProductDTO()
        {
            ProductName = p.ProductName,
            UnitPrice = p.UnitPrice
        })
            .ToList();
    }

    public List<OrderDTO> GetOrdersAfterYear(int year = 1997)
    {
        return _db.Orders.Where(o => o.OrderDate.Value.Year > year)
            .Select(o =>
        new OrderDTO()
        {
            OrderId = o.OrderId,
            OrderDate = o.OrderDate,
            CustomerId = o.CustomerId
        })
            .ToList();
    }

    public List<CustomerOrderDTO> GetCustomersOrders(int count = 10)
    {
        return _db.Customers.Select(c =>
        new CustomerOrderDTO()
        {
            CustomerId = c.CustomerId,
            OrdersCount = c.Orders.Count
        })
            .OrderByDescending(c => c.OrdersCount)
            .Take(count)
            .ToList();
    }

    public List<OrderTotalDTO> GetIncomeOrders(int count = 10)
    {
        return _db.Orders.Select(o =>
        new OrderTotalDTO()
        {
            OrderId = o.OrderId,
            Total = o.OrderDetails.Sum(od => od.UnitPrice * od.Quantity * (1 - (decimal)od.Discount))
        })
            .OrderByDescending(o => o.Total)
            .Take(count)
            .ToList();
    }

    public List<CustomerOrderDTO> GetCustomersWithMoreThanOrders(int count = 10)
    {
        return _db.Customers.Select(c => 
        new CustomerOrderDTO()
        {
            CustomerId = c.CustomerId,
            OrdersCount = c.Orders.Count
        })
            .Where(c => c.OrdersCount > count)
            .OrderByDescending(c => c.OrdersCount)
            .ToList();
    }

    public List<ProductOrderDTO> GetTopProductsByQuantity(int count = 5)
    {
        return _db.Products.Select(p =>  
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
