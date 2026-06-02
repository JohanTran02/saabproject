namespace backend.types
{
    public class Airplane
    {
        public int Id { get; set; }

        public List<ResourceGeneric> Resources { get; set; } = [];
    }
}