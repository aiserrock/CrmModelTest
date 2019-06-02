using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrmBuisnessLogic.Model;

namespace CrmUserInterface
{
    public partial class Main : Form
    {
        CrmContext db;  
        public Main()
        {
            InitializeComponent();
            db = new CrmContext();
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogProduct = new Catalog<Product>(db.Products,db);
            catalogProduct.Show();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogCustomer = new Catalog<Customer>(db.Customers,db);
            catalogCustomer.Show();
        }

        private void sellerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogSeller = new Catalog<Seller>(db.Sellers,db);
            catalogSeller.Show();
        }

        private void checkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogCheck = new Catalog<Check>(db.Checks,db);
            catalogCheck.Show();
        }

        private void customerAddToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var form = new CustomerForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                db.Customers.Add(form.Customer);
                db.SaveChanges();
            }
        }

        private void sellerAddToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = new SellerForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                db.Sellers.Add(form.Seller);
                db.SaveChanges();
            }
        }

        private void productAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ProductForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                db.Products.Add(form.Product);
                db.SaveChanges();
            }
        }

        private void modelingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ModelForm();
            form.Show();
        }
    }
}
