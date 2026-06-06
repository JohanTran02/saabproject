using System.ComponentModel.DataAnnotations;

namespace backend.types.DTO
{
    public record PersonnelDTO(
        [Required]
        int Id,
        string Name,
        PersonnelStatus Status,
        UserRole Role,
        int? CurrentTaskId = null,
        int? CurrentOrderId = null
    )
    {
        public static PersonnelDTO FromEntity(Personnel personnel) => new(
            Id: personnel.Id,
            Name: personnel.Name,
            Status: personnel.Status,
            Role: personnel.Role
        );

        public static PersonnelDTO MapToDto(Personnel personnel) => personnel switch
        {
            Technician t => new PersonnelDTO(t.Id, t.Name, t.Status, t.Role, t.CurrentTaskId),
            Supervisor s => new PersonnelDTO(s.Id, s.Name, s.Status, s.Role, s.CurrentTaskId),
            Operator o => new PersonnelDTO(o.Id, o.Name, o.Status, o.Role, CurrentOrderId: o.CurrentOrderId),
            _ => throw new ArgumentException("Unknown personnel type")
        };

        public static Personnel MapFromDto(CreatePersonnelDTO personnel) => personnel.Role switch
        {
            UserRole.Technician => new Technician
            { Name = personnel.Name, },
            UserRole.Supervisor => new Supervisor
            { Name = personnel.Name, },
            UserRole.Operator => new Operator
            { Name = personnel.Name, },
            _ => throw new ArgumentException($"Unknown personnel role: {personnel.Role}")
        };
    }

    public record CreatePersonnelDTO(
        string Name,
        UserRole Role
    );

    public record UpdatePersonnelDTO(
        string? Name,
        PersonnelStatus? Status,
        UserRole? Role //Only with permission
    );
}