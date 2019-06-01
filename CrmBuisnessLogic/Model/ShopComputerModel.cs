﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CrmBuisnessLogic.Model
{
    public class ShopComputerModel
    {
        bool isWorking = false;//флаг нужен для метода CreateCarts(там бесконечный цикл,условие выхода из цикла)
        //переключается в методе Start()
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
        //генерирование и обработка классов
        public void Start()
        {
            isWorking = true;//запустили метод CreateCarts в отдельном потоке на выполнение
            //метод будет работать до тех пор пока мы его самостоятельно не остановим
            Task.Run(() => CreateCarts(10, 1000));
            //для каждого потока отдельно запускаем выполнение метода CashDeskWork
            //создание коллекции задач,внутри каждой задачи находится касса которая бесконечно работает в своем собственном потоке
            var cashDeskTasks = CashDesks.Select(c => new Task(() => CashDeskWork(c,1000)));
            foreach(var task in cashDeskTasks)
            {
                task.Start();
            }
        }

        public void Stop()
        {
            isWorking = false;
        }
        /// <summary>
        /// Обработка (работа кассы)
        /// </summary>
        /// <param name="cashDesk">касса</param>
        /// <param name="sleep">время удержания потока</param>
        private void CashDeskWork(CashDesk cashDesk,int sleep)
        {
            while (isWorking)
            {
                if (cashDesk.Count > 0)
                {
                    cashDesk.Dequeue();
                    Thread.Sleep(sleep);
                }
            }
           
        }
      
        /// <summary>
        ///Функция создания потока клиентов и раскидывание их по очередям рабоатет в отдельном п отоке
        /// </summary>
        /// <param name="customerCounts">параметро отвечает за ко-во клиентов</param>
        /// <param name="sleep">Thread.Sleep(sleep)</param>
        private void CreateCarts(int customerCounts,int sleep)
        {
            while (isWorking)
            {
                //генерация клиентов
                var customers = Generator.GetNewCustomers(customerCounts);
                

                foreach (var customer in customers)
                {
                    var cart = new Cart(customer);
                    foreach(var product in Generator.GetRandomProducts(10, 30))
                    {
                        cart.Add(product);
                    }
                    var cash = CashDesks[random.Next(CashDesks.Count - 1)];
                    cash.Enqueue(cart);

                }
                Thread.Sleep(sleep);
            }
            
           

        }
    }
}
