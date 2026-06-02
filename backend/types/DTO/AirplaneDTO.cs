using System.ComponentModel.DataAnnotations;

namespace backend.types.DTO
{
    public record AirplaneDTO(
        [Required]
        int Id,
        IReadOnlyList<ResourceDTO> Resources
    )
    {
        public static AirplaneDTO FromEntity(Airplane airplane) => new(
            Id: airplane.Id,
            Resources: [.. airplane.Resources.Select(ResourceDTO.FromEntity)]
        );
    }
}