using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmBuisnessLogic.Model
{
    //логика продажи тут!!!!
    //кассовая стойка
    //создаем как виртуальный обьект для моделирования загруженности кассе
    //не присутствует бд
    public class CashDesk
    {
        //контекст базы данных
        CrmContext db;
        //далее понадобиться чтобы определять очередь с наименьшим кол-вом
        public int Count => Queue.Count;
        /// <summary>
        /// был ли закрыт чек
        /// </summary>
        public event EventHandler<Check> CheckClosed;
        public int MaxQueueLenght { get; set; }
        //счетчик для учета не ставших ждатьл очередь очередь customer
        public int ExitCustomer { get; set; }
        //номер кассы
        public int Number { get; set; }
        public Seller Seller { get; set; }
        //считаем в очереди корзины,к каждой корзине привязан свой customer
        public Queue<Cart> Queue { get; set; }
        // флаг отвечает за то будет ли это тестовое моделирование(не вносим в бд)
 //или это настоящая продажа(вносим в бд) 
 //поумолчанию в базу данных не сохраняем faasle
        public bool IsModel { get; set; }

        public CashDesk(int number,Seller seller,CrmContext db)
        {
            Number = number;
            Seller = seller;
            Queue = new Queue<Cart>();
            IsModel = true;
            MaxQueueLenght = 10;
            this.db = db ?? new CrmContext();
        }
        //встал в  очередь человек
        public void Enqueue(Cart cart)
        {
            if (Queue.Count < MaxQueueLenght)
            {
                Queue.Enqueue(cart);
            }
            else
            {
                ExitCustomer++;
            }
        }
        //выход из очереди
        //возвращаем сумму товара из функции очереди
        public decimal Dequeue()
        {
            decimal sum = 0;
            if (Queue.Count == 0)
            {
                return 0;
            }
            var card = Queue.Dequeue();
            if (card != null)
            {
                //создание чека
                var check = new Check()
                {
                    Seller = Seller,
                    Customer = card.Customer,
                    SellerId = Seller.SellerId,
                    CustomerId = card.Customer.CustomerId,
                    Created = DateTime.Now
                };

                if (!IsModel)
                {
                    db.Checks.Add(check);
                    db.SaveChanges();
              
                }
                else
                {
                    check.CheckId = 0;
                }
                var sells = new List<Sell>();
                //проходка по всем продуктам
                foreach (Product product in card)
                {
                    //если продукта на складе нет ничего не продаем
                    if (product.Count > 0)
                    {
                        //создание продажи
                        var sell = new Sell()
                        {
                            CheckId = check.CheckId,
                            Check = check,
                            ProductId = product.ProductId,
                            Product = product
                        };

                        //транзакция -группа операций действий обьединеным логическим принципом,если сбой откатить до предыдущего(например банкомат 1.списать деньги со счета
                        //2.выдать наличные если списать не удалось возвращаем на предыдущее состояние как будто деньги не выдавали ,или сли нет необходимых купюр возвращаем состояние на предыдущее)
                        //добавлю позже!!!!
                        sells.Add(sell);

                        if (!IsModel)
                        {
                            //сохранение в локальное хранилище
                            db.Sells.Add(sell);
                        }
                        product.Count--;
                        sum += product.Price;
                    }
                }
                check.Price = sum;
                if (!IsModel)
                {
                    //засунуть в базу
                    db.SaveChanges();
                }
                //рассыылка о событии всем подписчикамоооо
                CheckClosed?.Invoke(this, check);
                //if (CheckClosed != null)
                //{
                //    CheckClosed(this, check);
                //}

            }
            return sum;
        }
        public override string ToString()
        {
            return $"Cashbox №{Number}";
        }
    }
}
