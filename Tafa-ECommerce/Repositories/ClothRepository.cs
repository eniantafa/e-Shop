using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tafa_ECommerce.Intefaces;
using Tafa_ECommerce.Models;

namespace Tafa_ECommerce.Repositories
{
    public class ClothRepository : IClothRepository
    {
        private readonly AppDbContext _appDbContext;

        public ClothRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Cloth> Clothes => _appDbContext.Clothes.Include(c => c.Category);
        public IEnumerable<Cloth> PreferredClothes => _appDbContext.Clothes.Where(p => p.IsPreferredCloth).Include(c => c.Category);
        public Cloth GetClothById(int clothId) => _appDbContext.Clothes.FirstOrDefault(p => p.ClothesId == clothId);
    }
}
