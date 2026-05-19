using System.ComponentModel.DataAnnotations;

namespace backend.types.DTO
{
    public record PersonnelDTO(
        [Required]
        int Id,
        string Name,
        string Status,
        string Role,
        int? CurrentTaskId = null,
        int? CurrentOrderId = null,
        int? CurrentSiteId = null
    )
    {
        public static PersonnelDTO FromEntity(Personnel personnel) => new(
            Id: personnel.Id,
            Name: personnel.Name,
            Status: personnel.Status.ToString(),
            Role: personnel.Role.ToString()
        );

        public PersonnelDTO MapToDto(Personnel personnel) => personnel switch
        {
            Technician t => new PersonnelDTO(t.Id, t.Name, t.Status.ToString(), t.Role.ToString(), t.CurrentTaskId),
            Supervisor s => new PersonnelDTO(s.Id, s.Name, s.Status.ToString(), s.Role.ToString(), s.CurrentSiteId, CurrentSiteId: s.CurrentSiteId),
            Operator o => new PersonnelDTO(o.Id, o.Name, o.Status.ToString(), o.Role.ToString(), CurrentOrderId: o.CurrentOrderId),
            _ => throw new ArgumentException("Unknown personnel type")
        };
    }
}