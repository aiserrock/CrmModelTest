using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmBuisnessLogic.Model
{
    public class ShopComputerModel
    {
        Generator Generator = new Generator();
        Random random=new Random();
        public List<CashDesk> CashDesks { get; set; }= new List<CashDesk>();
        public List<Cart> Carts { get; set; } = new List<Cart>();
        public List<Check> Checks { get; set; }=new List<Check>();
        public List<Sell> Sell { get; set; } = new List<Sell>();
        public Queue<Seller> Sellers { get; set; } = new Queue<Seller>();
        public ShopComputerModel()
        {
            var sellers = Generator.GetNewSellers(20);
            Generator.GetNewProducts(1000);
            Generator.GetNewCustomers(100);
            foreach(var seller in sellers)
            {
                Sellers.Enqueue(seller);
            }
            for(int i = 0; i < 3; i++)
            {
                CashDesks.Add(new CashDesk(CashDesks.Count, Sellers.Dequeue()));

            }
            
        }
        public void Start()
        {
            var customers = Generator.GetNewCustomers(10);
            var carts = new Queue<Cart>();
            //нагружаем покупателей
            foreach(var customer in customers)
            {
                //покупателей считаем корзинами
                var cart = new Cart(customer);
                //нагружаем покупателя рандомным кол-вом продуктов
                foreach(var prod in Generator.GetRandomProducts(10, 30))
                {
                    cart.Add(prod);
                }
                carts.Enqueue(cart);
            }

           
             
            while(carts.Count>0)
            {
                var cash = CashDesks[random.Next(CashDesks.Count - 1)];//TODO:
                cash.Enqueue(carts.Dequeue()) ;

            }

            while (true)
            {
                var cash = CashDesks[ random.Next(CashDesks.Count - 1)];//TODO:
                var money =cash.Dequeue();
            }
        }
    }
}
