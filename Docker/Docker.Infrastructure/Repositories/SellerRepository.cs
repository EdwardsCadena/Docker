using Microsoft.EntityFrameworkCore;
using Docker.Core.Entities;
using Docker.Core.Interfaces;
using Docker.Infrastructure.Data;

namespace Docker.Infrastructure.Repositories
{
    public class SellerRepository : ISellerRepository
    {
        private readonly DockerContext _context;

        public SellerRepository(DockerContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Seller>> GetSeller()
        {
            var seller = await _context.Sellers.ToListAsync();
            return seller;
        }
        public async Task<Seller> GetSellers(int id)
        {
            var Seller = await _context.Sellers.FirstOrDefaultAsync(x => x.CodeSeller == id);
            return Seller;

        }
        public async Task InsertSeller(Seller seller)
        {
            _context.Sellers.Add(seller);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> UpdateSeller(Seller seller)
        {
            var result = await GetSellers(seller.CodeSeller);
            result.NameSeller = seller.NameSeller;
            result.LastNameSeller = seller.LastNameSeller;
            result.DocumentSeller = seller.DocumentSeller;
            result.CodeCitySeller = seller.CodeCitySeller;
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> DeleteSeller(int id)
        {
            var delete = await GetSellers(id);
            _context.Remove(delete);
            int row = await _context.SaveChangesAsync();
            return row > 0;
        }
    }
}
