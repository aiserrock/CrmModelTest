﻿using CrmBuisnessLogic.Model;
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
        DbSet<T> set;
        public Catalog(DbSet<T> set,CrmContext db)
        {
            InitializeComponent();
            this.db = db;
            this.set = set;
            set.Load();
            dataGridView1.DataSource = set.Local.ToBindingList();
            if (typeof(T) == typeof(Check))
            {
                add.Visible = false;
                change.Visible = false;
                delete.Visible = false;
            }
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
                var form = new ProductForm();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    db.Products.Add(form.Product);
                    db.SaveChanges();
                }
            }
            else if (typeof(T) == typeof(Seller))
            {
                var form = new SellerForm();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    db.Sellers.Add(form.Seller);
                    db.SaveChanges();
                }

            }
            else if (typeof(T) == typeof(Customer))
            {
                var form = new CustomerForm();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    db.Customers.Add(form.Customer);
                    db.SaveChanges();
                }

            }
        }

        private void change_Click(object sender, EventArgs e)
        {

            var id = dataGridView1.SelectedRows[0].Cells[0].Value;

            if (typeof(T) == typeof(Product))
            {
                var product = set.Find(id) as Product;
                if (product != null)
                {
                    var form = new ProductForm(product);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        product = form.Product;
                        db.SaveChanges();
                        dataGridView1.Update();
                    }
                }

            }
            else if (typeof(T) == typeof(Seller))
            {
                var seller = set.Find(id) as Seller;
                if (seller != null)
                {
                    var form = new SellerForm(seller);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        seller = form.Seller;
                        db.SaveChanges();
                        dataGridView1.Update();
                    }
                }

            }
            else if (typeof(T) == typeof(Customer))
            {
                var customer = set.Find(id) as Customer;
                if (customer != null)
                {
                    var form = new CustomerForm(customer);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        customer = form.Customer;
                        db.SaveChanges();
                        dataGridView1.Update();
                    }
                }

            }
        }

        private void delete_Click(object sender, EventArgs e)
        {

            var id = dataGridView1.SelectedRows[0].Cells[0].Value;

            if (typeof(T) == typeof(Product))
            {
                var product = set.Find(id) as Product;
                if (product != null)
                {

                    db.Products.Remove(product);
                    db.SaveChanges();
                    dataGridView1.Update();

                }

            }
            else if (typeof(T) == typeof(Seller))
            {
                var seller = set.Find(id) as Seller;
                if (seller != null)
                {

                    db.Sellers.Remove(seller);
                    db.SaveChanges();
                    dataGridView1.Update();

                }

            }
            else if (typeof(T) == typeof(Customer))
            {
                var customer = set.Find(id) as Customer;
                if (customer != null)
                {
                    var form = new CustomerForm(customer);
                    db.Customers.Remove(customer);
                    db.SaveChanges();
                    dataGridView1.Update();
                }

            }

        }

    }
}
