using CH_project_backend.Repository.BlogRepo;

namespace CH_project_backend.Services.BolgServices
{
    public class BlogService
    {
        private readonly IBlogRepo Repo;

        public BlogService(IBlogRepo _Repo)
        {
            Repo = _Repo;
        }
    }
}
