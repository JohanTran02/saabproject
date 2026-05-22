using System.ComponentModel.DataAnnotations;

namespace backend.types.DTO
{
    public record ResourceDTO(
        [Required]
        int Id,
        int Amount,
        string Name,
        string Type
    )
    {
        public static ResourceDTO FromEntity(ResourceGeneric resource) => new(
            Id: resource.Id,
            Name: resource.Name,
            Amount: resource.Amount,
            Type: resource.Type.ToString()
        );
    }

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
            resource.Buffer.MinReqAmount,
            resource.Buffer.OptimalReqAmount,
            resource.Buffer.MinReqAmount
            )
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