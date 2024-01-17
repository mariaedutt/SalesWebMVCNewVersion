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

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        public async Task InsertAsync(Seller obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Seller.FindAsync(id);
                _context.Seller.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException("Can't delete seller because he/she has sales");
            }
        }

        public async Task UpdateAsync(Seller obj)
        {
            bool hasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }

            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
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
