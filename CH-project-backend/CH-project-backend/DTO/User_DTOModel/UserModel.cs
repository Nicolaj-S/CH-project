namespace CH_project_backend.DTO.User_DTOModel
{
    public class UserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Fullname { get; set; }

        public bool Admin { get; set; }
    }
}
