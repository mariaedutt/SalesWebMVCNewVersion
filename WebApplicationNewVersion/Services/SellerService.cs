﻿using WebApplicationNewVersion.Data;
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

        public Seller FindById(int id)
        {
            return _context.Seller.FirstOrDefault(x => x.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }
    }
}
