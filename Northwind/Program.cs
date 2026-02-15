using Northwind.Models;

namespace Northwind;

internal class Program
{
    static void Main(string[] args)
    {
        using NorthwindContext db = new NorthwindContext();

        Print(Queries.GetAllCustomers(db));
        Console.WriteLine();
        Print(Queries.GetAllCustomersSorted(db));
        Console.WriteLine();
        Print(Queries.GetAllEmployees(db));
        Console.WriteLine();
        Print(Queries.GetAllProduct(db));
        Console.WriteLine();
        Print(Queries.GetFilteredProductByPrice(db));
        Console.WriteLine();
        Print(Queries.GetOrdersAfterYear(db));
        Console.WriteLine();
        Print(Queries.GetCustomersOrders(db));
        Console.WriteLine();
        Print(Queries.GetIncomeOrders(db));
        Console.WriteLine();
        Print(Queries.GetCustomersWithMoreThanOrders(db));
        Console.WriteLine();
        Print(Queries.GetTopProductsByQuantity(db));
    }

    public static void Print<T>(List<T> list)
    {
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
    }
}