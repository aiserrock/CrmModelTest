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

        public Product product { get; set; }
        public ProductForm()
        {
            InitializeComponent();
        }

    
        private void CustomerForm_Load(object sender, EventArgs e)
        {
           
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            product = new Product()
            {
                Name = inputNameTextBox.Text,
                Price=numericUpDown1.Value,
                Count=Convert.ToInt32(numericUpDown2.Value)
            };
            Close();
        }

       
    }
}
