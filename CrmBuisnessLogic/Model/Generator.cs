using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmBuisnessLogic.Model
{
    /// <summary>
    /// Класс генератор,нужен для генерации обьектов в очереди
    /// используется при моделировании
    /// </summary>
    public class Generator
    {
        /// <summary>
        /// В Customers уже существующие клиенты
        /// </summary>
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<Product> Products { get; set; } = new List<Product>();
        public List<Seller> Sellers { get; set; } = new List<Seller>();
        Random random = new Random();
        /// <summary>
        /// генерация новых клиентов
        /// </summary>
        /// <param name="count">Входной параметр,кол-во покупателей которое надо сгенерировать</param>
        /// <returns>Возвращает список пользователей</returns>

        public List<Customer> GetNewCustomers(int count)
        {
            var result = new List<Customer>();
            for (int i = 0; i < count; i++)
            {
                var customer = new Customer()
                {
                    Name = GetRandomText(),
                    CustomerId = Customers.Count,
                };
                Customers.Add(customer);
                result.Add(customer);
            }
            return result;
        }

        public List<Seller> GetNewSellers(int count)
        {
            var result = new List<Seller>();
            for (int i = 0; i < count; i++)
            {
                var seller = new Seller()
                {
                    Name = GetRandomText(),
                    SellerId = Sellers.Count,
                };
                Sellers.Add(seller);
                result.Add(seller);
            }
            return result;
        }

        public List<Product> GetNewProducts(int count)
        {
            var result = new List<Product>();
            for (int i = 0; i < count; i++)
            {
                var product = new Product()
                {
                    Count = random.Next(10,1000),
                    Name = GetRandomText(),
                    ProductId = Products.Count,
                    Price=Convert.ToDecimal(random.Next(5,100000)+random.NextDouble())
                };
                Products.Add(product);
                result.Add(product);
            }
            return result;
        }

        public List<Product> GetRandomProducts(int min,int max)
        {
            var result = new List<Product>();
            var count = random.Next(min, max);
            for(int i = 0; i < count; i++)
            {
                result.Add(Products[random.Next(Products.Count - 1)]);
            }
            return result;
        }
        /// <summary>
        /// Получаем случайный текст
        /// </summary>
        /// <returns>случайный текст</returns>
        private static string GetRandomText()
        {
            return Guid.NewGuid().ToString().Substring(0, 5);
        }
    }
        
    
}
