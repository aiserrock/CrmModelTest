using CrmBuisnessLogic.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrmUserInterface
{
    public partial class ProductForm : Form
    {

        public Product Product { get; set; }
        public ProductForm()
        {
            InitializeComponent();
        }
        public ProductForm(Product product):this()
        {
            Product = product ?? new Product();
            inputNameTextBox.Text = Product.Name;
            numericUpDown1.Value = Product.Price;
            numericUpDown2.Value = Product.Count;
        }


        private void CustomerForm_Load(object sender, EventArgs e)
        {
           
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Product = Product ?? new Product();
            
            Product.Name = inputNameTextBox.Text;
            Product.Price = numericUpDown1.Value;
            Product.Count = Convert.ToInt32(numericUpDown2.Value);
            
            Close();
        }

       
    }
}
