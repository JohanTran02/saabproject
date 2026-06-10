using Microsoft.EntityFrameworkCore;

namespace backend.types
{
    public class Resource
    {
        private ResourceType _type;

        public int Id { get; set; }

        public string Sku { get; set; } = "";
        public string Name { get; set; } = "";

        public int Amount { get; set; }

        public UnitType Unit { get; set; }
        public ResourceType Type
        {
            get => _type;
            set
            {
                _type = value;
                if (ResourceConfig.AllowedUnits.TryGetValue(value, out UnitType unitType))
                {
                    Unit = unitType;
                }
            }
        }
    }

    public class TaskResourceRequirement
    {
        public int Id { get; set; }

        public int TaskId { get; set; }
        public MaintenanceTask Task { get; set; } = null!;

        public int ResourceId { get; set; }
        public Resource Resource { get; set; } = null!;

        public int Amount { get; set; }
        public ResourceBuffer Buffer { get; set; } = new ResourceBuffer();
    }

    [Owned]
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

    public static class ResourceConfig
    {
        public static readonly Dictionary<ResourceType, UnitType> AllowedUnits = new()
    {
        { ResourceType.Fuel, UnitType.L },
        { ResourceType.Ammunition, UnitType.rounds },
        { ResourceType.Battery, UnitType.kWh }
    };
    }
}