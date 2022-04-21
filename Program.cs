using AppPostgreSQL;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {
        using (testdb3Context db = new testdb3Context())
        {
            // получаем товары из БД и выводим на консоль
            var products = db.Products.ToList();
            Console.WriteLine("\nСписок товаров:");
            foreach (var p in products)
            {
                Console.WriteLine($"{p.Id} {p.Productname,-15} {p.Company,-10} {p.Productcount,-5} {p.Price,10}");
            }
            // получаем клиентов из БД и выводим на консоль
            var customers = db.Customers.ToList();
            Console.WriteLine("\nСписок клиентов:");
            foreach (var c in customers)
            {
                Console.WriteLine($"{c.Id} {c.Firstname} ");
            }
            // получаем заказы из БД и выводим на консоль
            var orders = db.Orders
            .Include(p => p.Product)
            .Include(c => c.Customer)
            .ToList();
            Console.WriteLine("\nСписок заказов:");
            foreach (var o in orders)
            {
                Console.WriteLine($"{o.Id} {o.Product.Productname,-10} {o.Customer.Firstname,- 10} {o.Price,10}");
            }
        }
        Console.ReadLine();
    }
}