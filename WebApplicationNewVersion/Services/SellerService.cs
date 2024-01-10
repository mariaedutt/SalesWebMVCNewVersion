using WebApplicationNewVersion.Data;
using WebApplicationNewVersion.Models;

namespace WebApplicationNewVersion.Services
{
    public class SellerService
    {
        private readonly WebApplicationNewVersionContext _context;

        public SellerService(WebApplicationNewVersionContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
