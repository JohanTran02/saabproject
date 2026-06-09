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
        public static ResourceDTO FromEntity(ResourceGeneric resource) => new(
            Id: resource.Id,
            Name: resource.Name,
            Amount: resource.Amount,
            Sku: resource.Sku,
            Type: resource.Type,
            Unit: resource.Unit
        );

        public static ResourceGeneric FromDTO(CreateResourceDTO dto)
        {
            var uniqueSKU = GenerateUniqueSKU(dto.Type);

            return dto.Type switch
            {
                ResourceType.Fuel => new Fuel { Name = dto.Name, Amount = dto.Amount, Sku = uniqueSKU },
                ResourceType.Ammunition => new Ammunition { Name = dto.Name, Amount = dto.Amount, Sku = uniqueSKU },
                ResourceType.Battery => new Battery { Name = dto.Name, Amount = dto.Amount, Sku = uniqueSKU },
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

            string unitPrefix = type switch
            {
                ResourceType.Fuel => UnitType.L.ToString(),
                ResourceType.Ammunition => UnitType.rounds.ToString(),
                ResourceType.Battery => UnitType.kWh.ToString(),
                _ => ""
            };

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
    int Amount
    );

    public record TaskResourceRequirementDTO(
        [Required]
        int Id,
        int Amount,
        ResourceBufferDTO Buffer
    )
    {
        public static TaskResourceRequirementDTO FromEntity(TaskResourceRequirement resource) => new(
            Id: resource.Id,
            Amount: resource.Amount,
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
        int Amount,
        CreateResourceBufferDTO Buffer
    );

    public record UpdateTaskResourceRequirementDTO(
        int? TaskId,
        int? ResourceId,
        int? Amount,
        UpdateResourceBufferDTO? Buffer
    );

    public record UpdateResourceBufferDTO(
        int MaxReqAmount,
        int OptimalReqAmount,
        int MinReqAmount
    );

    public record CreateResourceBufferDTO(
        int MaxReqAmount,
        int OptimalReqAmount,
        int MinReqAmount
    );

    public record ResourceBufferDTO(
        int Id,
        int MaxReqAmount,
        int OptimalReqAmount,
        int MinReqAmount
    )
    {
        public static ResourceBufferDTO FromEntity(ResourceBuffer buffer) => new(
            Id: buffer.Id,
            MaxReqAmount: buffer.MaxReqAmount,
            OptimalReqAmount: buffer.OptimalReqAmount,
            MinReqAmount: buffer.MinReqAmount
        );
    }
}