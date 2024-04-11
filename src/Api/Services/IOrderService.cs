namespace OrderManagement.Api.Services;

public interface IOrderService
{
    IEnumerable<Order> GetOrdersFast();

    IEnumerable<Order> GetOrdersSlow();
}