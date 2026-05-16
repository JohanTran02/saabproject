namespace backend.types
{
    public class Personnel
    {
        public int Id { get; set; }

        public enum PersonnelStatus
        {
            Active,
            Inactive
        }

        public PersonnelStatus Status { get; set; }

        public int? CurrentMaintenanceTaskId { get; set; }
    }

    public abstract class ResourceGeneric
    {
        public int? Id { get; set; }

        public virtual UnitType Unit { get; }

        public string? Name { get; set; }

        public int Amount { get; set; }

        public virtual ResourceType Type { get; set; }

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