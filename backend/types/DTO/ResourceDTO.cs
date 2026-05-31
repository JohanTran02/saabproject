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
            Buffer: new ResourceBufferDTO(
            resource.Buffer.Id,
            resource.Buffer.MinReqAmount,
            resource.Buffer.OptimalReqAmount,
            resource.Buffer.MinReqAmount
            )
        );
    }

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