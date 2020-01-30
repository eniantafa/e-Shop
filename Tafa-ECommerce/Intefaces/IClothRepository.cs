using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tafa_ECommerce.Models;

namespace Tafa_ECommerce.Intefaces
{
    public interface IClothRepository
    {
        IEnumerable<Cloth> Clothes { get; }
        IEnumerable<Cloth> PreferredClothes { get;}
        Cloth GetClothById(int clothId);
    }
}
