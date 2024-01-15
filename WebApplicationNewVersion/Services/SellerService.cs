using WebApplicationNewVersion.Data;
using WebApplicationNewVersion.Models;
using Microsoft.EntityFrameworkCore;
using WebApplicationNewVersion.Services.Exceptions;

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

        public Seller FindById(int id)
        {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(x => x.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Seller obj)
        {
            if(!_context.Seller.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id not found");
            }

            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new DbConcurrencyException(ex.Message);
                //Intercepto uma exceção do nível de acesso a dados e relanço ela com uma exceção do nível de serviço.
                //Isso é muito importante para segregar as camadas da minha aplicação
                //A minha camada de serviço ela não vai propagar uma exceção do nível de acesso a dados
                //Assim o controlador só terá que lidar com exceções da camada de serviço
            }
        }
    }
}
