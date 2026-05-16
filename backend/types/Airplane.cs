namespace backend.types
{
    public class Airplane
    {
        public int Id { get; set; }
        public List<Ammunition>? Ammunition { get; set; }
        public List<Fuel>? Fuel { get; set; }
        public List<Battery>? Battery { get; set; }
    }

}