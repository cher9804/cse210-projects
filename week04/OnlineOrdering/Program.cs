using System;

class Program
{
    static void Main(string[] args)
    {

        Product product1 = new Product("Monitor", 1, 400, 2);
        Product product2 = new Product("TV", 2,500, 3);

        Address address1 = new Address("1000 West", "Orem", "Utah", "USA");

        Customer customer1 = new Customer("Cristian Hernandez", address1);

        List<Product> products1 = new List<Product>{product1, product2};
        Order order1 = new Order(products1, customer1);

        order1.GetOrderNumber();
        order1.PackingLabel();
        order1.ShippingLabel();
        order1.TotalPrice();


        Product product3 = new Product("Mic", 1, 400, 2);
        Product product4 = new Product("Keyboard", 2,500, 3);

        Address address2 = new Address("Calle 132", "Bogota", "Cundinamarca", "Colombia");

        Customer customer2 = new Customer("Cristian Hernandez", address2);

        List<Product> products2 = new List<Product>{product3, product4};
        Order order2 = new Order(products2, customer2);

        order2.GetOrderNumber();
        order2.PackingLabel();
        order2.ShippingLabel();
        order2.TotalPrice();







    }
}