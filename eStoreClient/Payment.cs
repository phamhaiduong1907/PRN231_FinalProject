using eStoreClient.Models;
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
            dgvPayment.Columns[0].Width = 0;
        }

        private void LoadCarts(IEnumerable<Cart> carts)
        {
            List<Cart> cartItems = new List<Cart>();
            cartItems.AddRange(carts);
            dgvCart.DataSource = cartItems.Select(c => new
            {
                ProductName = c.Product.ProductName,
                Quantity = c.Quantity
            }).ToList();
        }

        private async void btnAddItem_Click(object sender, EventArgs e)
        {
            if(dgvPayment.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a product first!");
            }
            else
            {
                List<Cart> cartNewItems = new List<Cart>();
                foreach(DataGridViewRow row in dgvPayment.SelectedRows)
                {
                   
                }
                string url = "http://localhost:5241/api/default/addtocart";
                HttpClient httpClient = new HttpClient();
                var content = JsonSerializer.Serialize(cartNewItems.Select(c => new
                {
                    MemberId = DefaultAccount.MemberId,
                    ProductId = c.ProductId,
                    Quantity = c.Quantity
                }).ToList());
                await httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8));
            }
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {

        }
    }
}
