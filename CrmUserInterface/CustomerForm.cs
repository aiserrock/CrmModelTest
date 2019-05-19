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
    public partial class CustomerForm : Form
    {

        public Customer customer { get; set; }
        public CustomerForm()
        {
            InitializeComponent();
        }

    
        private void CustomerForm_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            customer = new Customer()
            {
                Name = textBox1.Text
            };
            Close();
        }
    }
}
