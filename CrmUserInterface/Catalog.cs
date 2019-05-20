using CrmBuisnessLogic.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrmUserInterface
{
    public partial class Catalog<T> : Form where T :class
    {
        CrmContext db;
       
        public Catalog(DbSet<T> set,CrmContext db)
        {
            InitializeComponent();
            this.db = db;
            set.Load();
            dataGridView1.DataSource = set.Local.ToBindingList();
        }
        private void Catalog_Load(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void add_Click(object sender, EventArgs e)
        {
            if (typeof(T) == typeof(Product))
            {
                //var form = new ProductForm();
                //if (form.ShowDialog() == DialogResult.OK)
                //{
                //    db.Sellers.Add(form.seller);
                //    db.SaveChanges();
                //}
            }
            else if(typeof(T) == typeof(Seller))
            {

            }
            else if (typeof(T) == typeof(Customer))
            {

            }
        }

        private void change_Click(object sender, EventArgs e)
        {
            var id = dataGridView1.SelectedRows[0].Cells[0].Value;
        }

        private Form
    }
}
