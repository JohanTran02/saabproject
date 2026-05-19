namespace backend.types
{
    public abstract class Personnel
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public PersonnelStatus Status { get; set; } = PersonnelStatus.Inactive;

        public virtual UserRole Role { get; set; }

    }

    public class Technician : Personnel
    {
        public override UserRole Role => UserRole.Technician;

        public int CurrentTaskId { get; set; }
    }

    public class Operator : Personnel
    {
        public override UserRole Role => UserRole.Operator;

        public int CurrentOrderId { get; set; }
    }

    public class Supervisor : Personnel
    {
        public override UserRole Role => UserRole.Supervisor;

        public int CurrentSiteId { get; set; }

        public List<int> CurrentOrderIds { get; set; } = [];
    }

    public enum UserRole
    {
        Technician,
        Supervisor,
        Operator
    }

    public enum PersonnelStatus
    {
        Active,
        Inactive
    }

}