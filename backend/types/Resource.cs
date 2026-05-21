namespace backend.types
{
    public abstract class ResourceGeneric
    {
        public int Id { get; set; }

        public string Sku { get; set; } = "";
        public string Name { get; set; } = "";

        public virtual UnitType Unit { get; }
        public virtual ResourceType Type { get; set; }
    }

    public class TaskResourceRequirement
    {
        public int Id { get; set; }

        public int MaintenanceTaskId { get; set; }
        public MaintenanceTask MaintenanceTask { get; set; } = null!;

        public int ResourceId { get; set; }
        public ResourceGeneric Resource { get; set; } = null!;

        public int Amount { get; set; }
        public ResourceBuffer Buffer { get; set; } = new ResourceBuffer();
    }

    public class Fuel : ResourceGeneric
    {
        public override ResourceType Type => ResourceType.Fuel;
        public override UnitType Unit => UnitType.L;
    }

    public class Ammunition : ResourceGeneric
    {
        public override ResourceType Type => ResourceType.Ammunition;
        public override UnitType Unit => UnitType.rounds;
    }

    public class Battery : ResourceGeneric
    {
        public override ResourceType Type => ResourceType.Battery;
        public override UnitType Unit => UnitType.kWh;
    }

    public class ResourceBuffer
    {
        public int MaxReqAmount { get; set; }
        public int OptimalReqAmount { get; set; }
        public int MinReqAmount { get; set; }
    }

    public enum UnitType
    {
        kWh,
        L,
        rounds
    }

    public enum ResourceType
    {
        Fuel,
        Ammunition,
        Battery
    }
}