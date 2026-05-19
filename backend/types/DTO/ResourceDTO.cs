using System.ComponentModel.DataAnnotations;

namespace backend.types.DTO
{
    public record ResourceDTO(
        [Required]
        int Id,
        string Name,
        string Type,
        int Amount,
        ResourceBufferDTO Buffer
    )
    {
        public static ResourceDTO FromEntity(ResourceGeneric resource) => new(
            Id: resource.Id,
            Name: resource.Name,
            Amount: resource.Amount,
            Type: resource.Type.ToString(),
            Buffer: ResourceBufferDTO.FromEntity(resource.Buffer)
        );
    }

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