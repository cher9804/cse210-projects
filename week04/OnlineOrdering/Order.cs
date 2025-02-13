using System;

class Order
{
    private List<Product> _products;
    private Customer _customer;
    private int _orderNumber;
    private static HashSet<int> _usedOrderNumbers = new HashSet<int>();
    private static Random random = new Random();

    private int GenerateOrderNumbers()
    {
        Random random = new Random();

        int randomNumber;
        do
        {
            randomNumber = random.Next(0, 99999); // Generate a number between 0 and 99999
        } while (_usedOrderNumbers.Contains(randomNumber)); // Ensure uniqueness

        _usedOrderNumbers.Add(randomNumber); // Store the new number
        return randomNumber;
    }

    public void GetOrderNumber()
    {
        Console.WriteLine($"Order Number: {_orderNumber}");
    }

    private void OrderNumber()
    {
        _orderNumber = GenerateOrderNumbers();
    }

    // {
    // Random random = new Random();
    //     int randomNumber = random.Next(0, 99999);
    //     List<int> usedOderNumbers = new List<int>();
    //     foreach (int OrderNumber in usedOderNumbers)
    //     {
    //         if (usedOderNumbers.Contains(randomNumber))
    //         {
    //             randomNumber = random.Next(0, 99999);
    //         }
    //         else
    //         {
    //             usedOderNumbers.Add(randomNumber);
    //         }
    //     }
    //     return randomNumber;
    // }

    public Order(List<Product> products, Customer customer)
    {
        _customer = customer;
        _products = products;
        OrderNumber();

    }

    public float TotalCost()
    {
        float total = 0;

        foreach (Product product in _products)
        {
            float item_price = product.TotalProductCost();
            total += item_price;

        }
        return total;

    }
    public void PackingLabel()
    {
        Console.WriteLine("Packing Label:\n");
        Console.WriteLine($"Products: ");
        foreach (Product product in _products)
        {
            Console.WriteLine($"Name: {product.GetProductName()}, Product ID: {product.GetProductId()}");
        }
    }
    public void ShippingLabel()
    {
        Address customer_address = _customer.GetAddress();
        string customer_name = _customer.GetName();
        Console.WriteLine("\nShipping Label:\n");
        Console.WriteLine($"Customer name: {customer_name}\n");
        Console.WriteLine(customer_address.DisplayAddress());
    }
    public void TotalPrice()
    {
        float total_cost = TotalCost();
        float shipping_cost = ShippingCost();
        float total_price = total_cost + shipping_cost;
        Console.WriteLine($"\nTotal Price: {total_price}\n");
    }
    public float ShippingCost()
    {
        //     if (_customer.CustomerInUSA())
        //     {
        //         return 5;
        //     }
        //     else
        //     {
        //         return 35;
        //     }
        return _customer.CustomerInUSA() ? 5 : 35;

    }

}