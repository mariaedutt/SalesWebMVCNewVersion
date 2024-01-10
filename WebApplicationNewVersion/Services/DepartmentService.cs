using WebApplicationNewVersion.Data;
using WebApplicationNewVersion.Models;

namespace WebApplicationNewVersion.Services
{
    public class DepartmentService
    {
        private readonly WebApplicationNewVersionContext _context;

        public DepartmentService(WebApplicationNewVersionContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
