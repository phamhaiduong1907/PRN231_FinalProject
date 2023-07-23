﻿using eStoreClient.Models;
using eStoreClient.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eStoreClient
{
    public partial class Payment : Form
    {
        static List<Cart> Carts = new List<Cart>();
        public Payment()
        {
            InitializeComponent();
            CenterToParent();
            LoadData();
        }

        private void btnInvoiceClick(object sender, EventArgs e)
        {
            this.Hide();
            Invoice invoice = new Invoice();
            invoice.Show();
        }

        private void LoadData()
        {
            LoadProducts();
            string link = $"http://localhost:5241/api/default/getcart/{DefaultAccount.MemberId}";
            HttpClient client = new HttpClient();
            string result = client.GetAsync(link).Result.Content.ReadAsStringAsync().Result;
            Carts = JsonSerializer.Deserialize<List<Cart>>
                (result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            LoadCarts(Carts);
        }

        private void LoadProducts()
        {
            string link = "http://localhost:5241/api/default/listProduct";
            HttpClient client = new HttpClient();
            string result = client.GetAsync(link).Result.Content.ReadAsStringAsync().Result;
            Models.Product[] products = JsonSerializer.Deserialize<Models.Product[]>
                (result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            dgvPayment.DataSource = products.Select(p => new
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                UnitPrice = p.UnitPrice,
                UnitsInStock = p.UnitsInStock,
                weight = p.weight
            }).ToList();
            dgvPayment.Columns["ProductId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvPayment.Columns["ProductId"].Width = 0; 
        }

        private void LoadCarts(IEnumerable<Cart> carts)
        {
            List<Cart> cartItems = new List<Cart>();
            cartItems.AddRange(carts);
            dgvCart.Columns.Clear();
            dgvCart.DataSource = cartItems.Select(c => new
            {
                ProductName = c.ProductRef.ProductName,
                Quantity = c.Quantity
            }).ToList();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if(dgvPayment.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a product first!");
            }
            else
            {

                List<Cart> cartNewItems = new List<Cart>();
                List<Cart> cartUpdateItems = new List<Cart>();
                foreach(DataGridViewRow row in dgvPayment.SelectedRows)
                {
                    int productId = (int)row.Cells["ProductId"].Value;
                    string productName = (string)row.Cells["ProductName"].Value;
                    if(Carts.Select(c => c.ProductId).Contains(productId))
                    {
                        Cart cartFound = Carts.Find(c => c.ProductId == productId);
                        int newQuantity = ++cartFound.Quantity;
                        Cart cart = new Cart
                        {
                            MemberId = DefaultAccount.MemberId,
                            ProductId = productId,
                            Quantity = newQuantity
                        };
                        cartUpdateItems.Add(cart);
                    }
                    else
                    {
                        Models.Product product = new Models.Product
                        {
                            ProductId = productId,
                            ProductName = productName
                        };
                        Cart cart = new Cart
                        {
                            MemberId = DefaultAccount.MemberId,
                            ProductId = productId,
                            ProductRef = product,
                            Quantity = 1
                        };
                        cartNewItems.Add(cart);
                        Carts.Add(cart);
                    }
                }
                LoadCarts(Carts);
                string addUrl = "http://localhost:5241/api/default/addtocart";
                string updateUrl = "http://localhost:5241/api/default/updatecart";
                HttpClient client = new HttpClient();
                if(cartUpdateItems.Count > 0)
                {
                    var content = JsonSerializer.Serialize(cartUpdateItems.Select(c => new CartDTO
                    {
                        MemberId = c.MemberId,
                        ProductId = c.ProductId,
                        Quantity= c.Quantity
                    }).ToList());
                    HttpResponseMessage httpResponseMessage = client.PutAsync
                        (updateUrl, new StringContent(content, Encoding.UTF8, "application/json")).Result;
                    MessageBox.Show(httpResponseMessage.Content.ReadAsStringAsync().Result);
                }
                if (cartNewItems.Count > 0)
                {
                    var content = JsonSerializer.Serialize(cartNewItems.Select(c => new CartDTO
                    {
                        MemberId = c.MemberId,
                        ProductId = c.ProductId,
                        Quantity = c.Quantity
                    }).ToList());
                    HttpResponseMessage httpResponseMessage = client.PostAsync
                        (updateUrl, new StringContent(content, Encoding.UTF8, "application/json")).Result;
                    MessageBox.Show(httpResponseMessage.Content.ReadAsStringAsync().Result);
                }
            }
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {

        }
    }
}
