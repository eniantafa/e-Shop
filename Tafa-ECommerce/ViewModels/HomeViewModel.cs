using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tafa_ECommerce.Models;

namespace Tafa_ECommerce.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Cloth> PreferredClothes { get; set; }
    }
}
