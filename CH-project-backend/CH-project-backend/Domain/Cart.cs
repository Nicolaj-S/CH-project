namespace CH_project_backend.Domain
{
    public class Cart
    {
        public int Id { get; set; }
        public List <User> Users { get; set; }
        public ICollection<Shop> Shop { get; set; }
    }
}
