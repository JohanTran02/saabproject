using System.ComponentModel.DataAnnotations;
using Bogus;
namespace backend.types.DTO
{
    public record ResourceDTO(
        [Required]
        int Id,
        int Amount,
        string Sku,
        string Name,
        ResourceType Type,
        UnitType Unit
    )
    {
        public static ResourceDTO FromEntity(Resource resource) => new(
            Id: resource.Id,
            Name: resource.Name,
            Amount: resource.Amount,
            Sku: resource.Sku,
            Type: resource.Type,
            Unit: resource.Unit
        );

        public static Resource FromDTO(CreateResourceDTO dto)
        {
            var uniqueSKU = GenerateUniqueSKU(dto.Type);

            return dto.Type switch
            {
                ResourceType.Fuel => new Resource { Name = dto.Name, Amount = dto.Amount, Sku = uniqueSKU, Type = ResourceType.Fuel },
                ResourceType.Ammunition => new Resource { Name = dto.Name, Amount = dto.Amount, Sku = uniqueSKU, Type = ResourceType.Ammunition },
                ResourceType.Battery => new Resource { Name = dto.Name, Amount = dto.Amount, Sku = uniqueSKU, Type = ResourceType.Battery },
                _ => throw new ArgumentException($"Unknown resource type: {dto.Type}")
            };

        }
        private static string GenerateUniqueSKU(ResourceType type)
        {
            string skuPrefix = type switch
            {
                ResourceType.Fuel => "FUEL",
                ResourceType.Ammunition => "AMMO",
                ResourceType.Battery => "BAT",
                _ => "RES"
            };

            string unitPrefix = ResourceConfig.AllowedUnits[type].ToString();

            var randomizer = new Randomizer();
            return $"{skuPrefix}-{randomizer.Int(0, 100000)}-{unitPrefix}";
        }
    }

    public record CreateResourceDTO(
        int Amount,
        string Name,
        ResourceType Type
    );

    public record UpdateResourceDTO(
    int Amount,
    string Name
    );

    public record TaskResourceRequirementDTO(
        [Required]
        int Id,
        int Amount,
        int ResourceId,
        ResourceBufferDTO Buffer
    )
    {
        public static TaskResourceRequirementDTO FromEntity(TaskResourceRequirement resource) => new(
            Id: resource.Id,
            Amount: resource.Amount,
            ResourceId: resource.ResourceId,
            Buffer: ResourceBufferDTO.FromEntity(resource.Buffer)
        );

        public static TaskResourceRequirement FromDTO(CreateTaskResourceRequirementDTO resource)
        {
            return new TaskResourceRequirement
            {
                TaskId = resource.TaskId,
                ResourceId = resource.ResourceId,
                Amount = resource.Amount,
                Buffer = new ResourceBuffer
                {
                    MaxReqAmount = resource.Buffer.MaxReqAmount,
                    OptimalReqAmount = resource.Buffer.OptimalReqAmount,
                    MinReqAmount = resource.Buffer.MinReqAmount
                }
            };
        }
    }

    public record CreateTaskResourceRequirementDTO(
        int TaskId,
        int ResourceId,
        int AirplaneId,
        int Amount,
        CreateResourceBufferDTO Buffer
    );

    public record UpdateTaskResourceRequirementDTO(
        int? TaskId,
        int? ResourceId,
        int? AirplaneId,
        int? Amount,
        UpdateResourceBufferDTO? Buffer
    );

    public record UpdateResourceBufferDTO(
        int? MaxReqAmount,
        int? OptimalReqAmount,
        int? MinReqAmount
    );

    public record CreateResourceBufferDTO(
        int MaxReqAmount,
        int OptimalReqAmount,
        int MinReqAmount
    );

    public record ResourceBufferDTO(
        int MaxReqAmount,
        int OptimalReqAmount,
        int MinReqAmount
    )
    {
        public static ResourceBufferDTO FromEntity(ResourceBuffer buffer) => new(
            MaxReqAmount: buffer.MaxReqAmount,
            OptimalReqAmount: buffer.OptimalReqAmount,
            MinReqAmount: buffer.MinReqAmount
        );
    }
}