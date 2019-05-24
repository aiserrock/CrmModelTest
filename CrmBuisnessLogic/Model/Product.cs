using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmBuisnessLogic.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Product
    {
        /// <summary>
        /// 333
        /// </summary>
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public virtual ICollection<Sell> Sells { get; set; }
        public override string ToString()
        {
            return Name;
        }
        public override int GetHashCode()
        {
            return ProductId;
        }
        public override bool Equals(object obj)
        {
            if(obj is Product product)
            {
                return ProductId.Equals(product.ProductId);
            }
            return false;
            
        }
    }
}
