using Bogus;
using backend.types;
using Microsoft.EntityFrameworkCore;
using backend.data;

namespace backend
{
    public static class SeedData
    {
        public static async Task Seed(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<MaintenanceDbContext>();

            await context.Database.MigrateAsync();

            if (await context.Airplanes.AnyAsync()) return;

            var fakeTech = new Faker<Technician>()
                .RuleFor(t => t.Name, f => f.Person.FirstName + " " + f.Person.LastName)
                .RuleFor(t => t.Status, _ => PersonnelStatus.Inactive)
                .RuleFor(t => t.Role, _ => UserRole.Technician);

            var fakeOperator = new Faker<Operator>()
                .RuleFor(o => o.Name, f => f.Person.FirstName + " " + f.Person.LastName)
                .RuleFor(o => o.Status, _ => PersonnelStatus.Inactive)
                .RuleFor(o => o.Role, _ => UserRole.Operator);

            var fakeSupervisor = new Faker<Supervisor>()
                .RuleFor(s => s.Name, f => f.Person.FirstName + " " + f.Person.LastName)
                .RuleFor(s => s.Status, _ => PersonnelStatus.Inactive)
                .RuleFor(s => s.Role, _ => UserRole.Supervisor);

            var fakeFuel = new Faker<Fuel>()
                .RuleFor(f => f.Sku, f => $"FUEL-{f.Random.Int(0, 100000)}")
                .RuleFor(f => f.Name, f => f.Commerce.ProductName())
                .RuleFor(f => f.Amount, f => f.Random.Int(100, 5000));

            var fakeAmmo = new Faker<Ammunition>()
                .RuleFor(a => a.Sku, f => $"AMMO-{f.Random.Int(0, 100000)}")
                .RuleFor(a => a.Name, f => f.Commerce.ProductName())
                .RuleFor(a => a.Amount, f => f.Random.Int(100, 2000));

            var fakeBattery = new Faker<Battery>()
                .RuleFor(b => b.Sku, f => $"BAT-{f.Random.Int(0, 100000)}")
                .RuleFor(b => b.Name, f => f.Commerce.ProductName())
                .RuleFor(b => b.Amount, f => f.Random.Int(1, 10));

            var fakeSite = new Faker<MaintenanceSite>();

            var fakeOrder = new Faker<MaintenanceOrder>()
                .RuleFor(o => o.OrderTitle, f => $"Order #{f.Random.Int(0, 100000)}")
                .RuleFor(o => o.Status, f => f.PickRandom<MaintenanceGenericStatus>())
                .RuleFor(o => o.Description, f => f.Lorem.Sentence())
                .RuleFor(t => t.Comments, f => f.Lorem.Sentence())
                .RuleFor(o => o.StartedAt, f => f.Date.Soon().ToUniversalTime())
                .RuleFor(o => o.CreatedAt, f => f.Date.Past().ToUniversalTime())
                .RuleFor(o => o.UpdatedAt, f => f.Date.Recent().ToUniversalTime());

            var fakeTask = new Faker<MaintenanceTask>()
                .RuleFor(t => t.Status, f => f.PickRandom<MaintenanceGenericStatus>())
                .RuleFor(t => t.Description, f => f.Lorem.Sentence())
                .RuleFor(t => t.Comments, f => f.Lorem.Sentence())
                .RuleFor(t => t.StartedAt, f => f.Date.Soon().ToUniversalTime())
                .RuleFor(t => t.CreatedAt, f => f.Date.Past().ToUniversalTime())
                .RuleFor(t => t.UpdatedAt, f => f.Date.Recent().ToUniversalTime())
                .RuleFor(t => t.Type, f => f.PickRandom<TaskType>())
                .RuleFor(t => t.Duration, f => f.Date.Timespan())
                .RuleFor(t => t.Deadline, f => f.Date.Future().ToUniversalTime());

            var fakeAirplanes = new Faker<Airplane>()
                .RuleFor(a => a.Resources, f => [
                    .. fakeAmmo.Generate(1),
                    .. fakeFuel.Generate(1),
                    .. fakeBattery.Generate(1)
                ]);

            var fakeResource = new Faker<TaskResourceRequirement>()
                .RuleFor(r => r.Amount, f => f.Random.Int(1, 10))
                .RuleFor(r => r.Buffer, f => new ResourceBuffer
                {
                    MaxReqAmount = f.Random.Int(10, 50),
                    OptimalReqAmount = f.Random.Int(5, 30),
                    MinReqAmount = f.Random.Int(1, 15)
                });

            var airplanes = fakeAirplanes.Generate(4);
            var orders = new List<MaintenanceOrder>();
            var tasks = new List<MaintenanceTask>();
            var resourceRequirements = new List<TaskResourceRequirement>();
            var resources = new List<ResourceGeneric>();
            for (int i = 0; i < airplanes.Count; i++)
            {
                var order = fakeOrder.Generate();
                var task = fakeTask.Generate();
                var resource = fakeFuel.Generate();
                var resourceRequirement = fakeResource.Generate();

                var airplane = airplanes[i];

                task.MaintenanceOrder = order;
                task.Airplane = airplane;

                resourceRequirement.Task = task;
                resourceRequirement.Resource = resource;

                order.Tasks.Add(task);

                orders.Add(order);
                tasks.Add(task);

                resources.Add(resource);
                resourceRequirements.Add(resourceRequirement);
            }

            var sites = fakeSite.Generate(5);
            var operators = fakeOperator.Generate(2);
            var supervisors = fakeSupervisor.Generate(2);
            var techs = fakeTech.Generate(2);

            context.Sites.AddRange(sites);
            context.Airplanes.AddRange(airplanes);
            context.Orders.AddRange(orders);
            context.Tasks.AddRange(tasks);
            context.Resources.AddRange(resources);
            context.ResourceRequirements.AddRange(resourceRequirements);
            context.Personnel.AddRange(operators);
            context.Personnel.AddRange(supervisors);
            context.Personnel.AddRange(techs);

            await context.SaveChangesAsync();
        }
    }
}