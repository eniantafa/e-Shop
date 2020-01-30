using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tafa_ECommerce.Models;

namespace Tafa_ECommerce.ViewModels
{
    public class ClothListViewModel
    {
        public IEnumerable<Cloth> Clothes { get; set; }
        public string CurrentCategory { get; set; }
    }
}
