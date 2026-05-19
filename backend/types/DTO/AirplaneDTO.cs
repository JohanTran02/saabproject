using System.ComponentModel.DataAnnotations;

namespace backend.types.DTO
{
    public record AirplaneDTO(
        [Required]
        int Id,
        IReadOnlyList<ResourceDTO> Ammunition,
        IReadOnlyList<ResourceDTO> Fuel,
        IReadOnlyList<ResourceDTO> Battery
    )
    {
        public static AirplaneDTO FromEntity(Airplane airplane) => new(
            Id: airplane.Id,
            Ammunition: [.. airplane.Ammunition.Select(ResourceDTO.FromEntity)],
            Fuel: [.. airplane.Fuel.Select(ResourceDTO.FromEntity)],
            Battery: [.. airplane.Battery.Select(ResourceDTO.FromEntity)]
        );
    }
}