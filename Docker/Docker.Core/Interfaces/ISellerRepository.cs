using Docker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docker.Core.Interfaces
{
    public interface ISellerRepository
    {
        Task<IEnumerable<Seller>> GetSeller();
        Task<Seller> GetSellers(int id);
        Task InsertSeller(Seller seller);
        Task<bool> UpdateSeller(Seller seller);
        Task<bool> DeleteSeller(int id);
    }
}
