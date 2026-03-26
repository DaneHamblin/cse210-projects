using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Springfield", "IL", "USA");
        Address address2 = new Address("456 Queen St", "Toronto", "ON", "Canada");
        Address address3 = new Address("789 High St", "London", "England", "UK");

        Customer customer1 = new Customer("John Smith", address1);
        Customer customer2 = new Customer("Maria Garcia", address2);
        Customer customer3 = new Customer("William Jones", address3);

        Product product1 = new Product("Laptop", "LAP001", 899.99m, 1);
        Product product2 = new Product("Mouse", "MOU002", 24.99m, 2);
        Product product3 = new Product("Keyboard", "KEY003", 59.99m, 1);
        Product product4 = new Product("Monitor", "MON004", 199.99m, 1);
        Product product5 = new Product("USB Cable", "USB005", 9.99m, 3);
        Product product6 = new Product("Headphones", "HED006", 79.99m, 1);

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product5);
        
        Order order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product4);
        order2.AddProduct(product6);
        
        Order order3 = new Order(customer3);
        order3.AddProduct(product1);
        order3.AddProduct(product6);
        order3.AddProduct(product2);
        
        Console.WriteLine("ORDER 1");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.CalculateTotalCost():F2}\n");
        
        Console.WriteLine("ORDER 2");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.CalculateTotalCost():F2}\n");
        
        Console.WriteLine("ORDER 3");
        Console.WriteLine(order3.GetPackingLabel());
        Console.WriteLine(order3.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order3.CalculateTotalCost():F2}\n");
    }
}