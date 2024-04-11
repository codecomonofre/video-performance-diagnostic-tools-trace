namespace OrderManagement.Api.Services;

public class OrderService : IOrderService
{
    public IEnumerable<Order> GetOrdersSlow()
    {
        var orders = new List<Order>(100);

        for (int count = 0; count < 100; count++)
        {
            orders.Add(new Order(count, "Slow"));
        }

        return orders;
    }

    public IEnumerable<Order> GetOrdersFast()
    {
        for (int count = 0; count < 100; count++)
        {
            yield return new Order(count, "fast");
        }
    }
}