using OrderManagement.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/orders-slow", async ([FromServices] IOrderService _orderService, CancellationToken cancellationToken) =>
{
    return await Task.FromResult(_orderService.GetOrdersSlow());
})
.WithOpenApi();

app.MapGet("/orders-fast", async ([FromServices] IOrderService _orderService, CancellationToken cancellationToken) =>
{
    return await Task.FromResult(_orderService.GetOrdersFast());
})
.WithOpenApi();

app.UseHttpsRedirection();

app.Run();

public record Order(int Id, string Name);