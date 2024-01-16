using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
