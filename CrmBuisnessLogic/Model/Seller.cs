using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmBuisnessLogic.Model
{
   public class Seller
    {
        public int SellerId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Check> Checks { get; set; }

        public override string ToString()
        {
            return Name;
        }
        
    }
}
  