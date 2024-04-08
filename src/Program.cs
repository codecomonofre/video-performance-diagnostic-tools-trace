var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/orders-slow", (CancellationToken cancellationToken) =>
{
    return OrderService.GetOrdersSlowAsync();
})
.WithOpenApi();

app.MapGet("/orders-fast", (CancellationToken cancellationToken) =>
{
    return OrderService.GetOrdersFastAsync();
})
.WithOpenApi();

app.UseHttpsRedirection();

app.Run();

internal sealed class OrderService
{
    public static IEnumerable<Order> GetOrdersSlowAsync()
    {
        var orders = new List<Order>();

        for (int count = 0; count < 100; count++)
        {
            orders.Add(new Order(count, $"{count}"));
        }

        return orders;
    }

    public static IEnumerable<Order> GetOrdersFastAsync()
    {
        for (int count = 0; count < 100; count++)
        {
            yield return new Order(count, $"{count}");
        }
    }
}

public record Order(int Id, string Name);