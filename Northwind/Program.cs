using Northwind.Models;

namespace Northwind;

internal class Program
{
    static void Main(string[] args)
    {
        using NorthwindContext db = new NorthwindContext();

        Queries queries = new Queries(db);

        Print(queries.GetAllCustomers());
        Console.WriteLine();
        Print(queries.GetAllCustomersSorted());
        Console.WriteLine();
        Print(queries.GetAllEmployees());
        Console.WriteLine();
        Print(queries.GetAllProduct());
        Console.WriteLine();
        Print(queries.GetFilteredProductByPrice());
        Console.WriteLine();
        Print(queries.GetOrdersAfterYear());
        Console.WriteLine();
        Print(queries.GetCustomersOrders());
        Console.WriteLine();
        Print(queries.GetIncomeOrders());
        Console.WriteLine();
        Print(queries.GetCustomersWithMoreThanOrders());
        Console.WriteLine();
        Print(queries.GetTopProductsByQuantity());
    }

    public static void Print<T>(List<T> list)
    {
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
    }
}