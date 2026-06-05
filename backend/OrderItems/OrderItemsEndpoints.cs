using backend.types.DTO;

namespace backend.OrderItems
{
    public static class OrderItemsEndpoints
    {
        public static void RegisterOrderItemsEndpoints(this WebApplication app)
        {
            var orders = app.MapGroup("/orders");

            orders.MapGet("/", GetAllOrders);
            orders.MapGet("/{id}", GetOrderById);
            orders.MapDelete("/{id}", DeleteOrderById);
            orders.MapPatch("/{id}", UpdateOrderById);
            orders.MapPost("/", CreateOrder);
        }
        static async Task<IResult> GetAllOrders(IOrderService orderService)
        {
            List<MaintenanceOrderDTO> orders = await orderService.GetAllAsync();

            return TypedResults.Ok(orders);
        }

        static async Task<IResult> GetOrderById(int id, IOrderService orderService)
        {
            return await orderService.GetByIdAsync(id)
                is MaintenanceOrderDTO order
                ? TypedResults.Ok(order)
                : TypedResults.NotFound();
        }

        static async Task<IResult> DeleteOrderById(int id, IOrderService orderService)
        {
            try
            {
                if (await orderService.DeleteByIdAsync(id) is true) return TypedResults.NoContent();

                return TypedResults.NotFound();
            }
            catch (InvalidOperationException error)
            {
                return TypedResults.Conflict(error.Message);
            }

        }

        static async Task<IResult> UpdateOrderById(int id, UpdateMaintenanceOrderDTO incoming, IOrderService orderService)
        {
            if (await orderService.UpdateByIdAsync(id, incoming) is true) return TypedResults.NoContent();

            return TypedResults.NotFound();
        }

        static async Task<IResult> CreateOrder(CreateMaintenanceOrderDTO incoming, IOrderService orderService)
        {
            MaintenanceOrderDTO order = await orderService.CreateAsync(incoming);

            return TypedResults.Created($"Created order/{order.Id}", order);
        }
    }
}