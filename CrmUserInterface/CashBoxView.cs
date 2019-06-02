using CrmBuisnessLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrmUserInterface
{
    /// <summary>
    /// визуальное отображение модели,чучуть автогенерируемого кода
    /// </summary>
    class CashBoxView
    {
        CashDesk cashDesk;
        public Label CashDeskName { get; set; }
        public NumericUpDown Price { get; set; }

        public ProgressBar QueueLenght {get;set;}
        public Label LeaveCustomersCount { get; set; }
        /// <summary>
        /// Генерирует визуальную состовляющую (кассы)
        /// </summary>
        /// <param name="cashDesk">кассы</param>
        /// <param name="number">кол-во касс</param>
        /// <param name="x">х</param>
        /// <param name="y">у</param>
        public CashBoxView(CashDesk cashDesk,int number,int x,int y)
        {
           //инициализация
            this.cashDesk = cashDesk;
            CashDeskName = new Label();           
            Price = new NumericUpDown();
            QueueLenght = new ProgressBar();
            LeaveCustomersCount = new Label();



            // 
            // numericUpDown
            // 
            Price.Location = new System.Drawing.Point(x+70, y);
            Price.Name = "numericUpDown"+number;
            Price.Size = new System.Drawing.Size(120, 20);
            Price.TabIndex = number;
            Price.Maximum = 1000000000000000;


            // 
            // progressBar1
            // 
            QueueLenght.Location = new System.Drawing.Point(x+3, y);
            QueueLenght.Maximum = cashDesk.MaxQueueLenght;
            QueueLenght.Name = "progressBar"+number;
            QueueLenght.Size = new System.Drawing.Size(100, 23);
            QueueLenght.TabIndex = number;
            QueueLenght.Value = 0;

            // 
            // label
            // 
            LeaveCustomersCount.AutoSize = true;
            LeaveCustomersCount.Location = new System.Drawing.Point(x+400, y);
            LeaveCustomersCount.Name = "label2" + number;
            LeaveCustomersCount.Size = new System.Drawing.Size(35, 13);
            LeaveCustomersCount.TabIndex = number;
            LeaveCustomersCount.Text = "";
            //делегат
            cashDesk.CheckClosed += CashDesk_CheckClosed;
        }
        //обновление компонентов должно происхоодитьв одном и том же потоке
        private void CashDesk_CheckClosed(object sender, Check e)
        {
            //обновление формы
            //обернуть в  инвок и деллегат иначе эксппшен(доступ из другогго потока)
            Price.Invoke((Action)delegate 
            {
                Price.Value += e.Price;
                QueueLenght.Value = cashDesk.Count;
                LeaveCustomersCount.Text = cashDesk.ExitCustomer.ToString();
            });
        }
    }
}
