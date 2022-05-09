namespace CH_project_backend.Domain
{
    public class Blog
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public List <User> Users { get; set;}
    }
}
