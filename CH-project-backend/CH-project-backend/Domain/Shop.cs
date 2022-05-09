namespace CH_project_backend.Domain
{
    public class Shop
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public List <Cart> Cart { get; set; }
    }
}
