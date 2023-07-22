using eStoreClient.Repository;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eStoreClient
{
    public partial class eStoreClient : Form
    {
 
        public eStoreClient()
        {
            InitializeComponent();
            CenterToParent();
            //CenterToScreen();             
        }
        public void HttpWeb(string link,out WebResponse res)
        {
            HttpWebRequest req = HttpWebRequest.CreateHttp(link);
            res = req.GetResponse();
        }
        public void LoadMember()
        {
            string link = "http://localhost:5241/api/default/listmember";
            HttpClient client = new HttpClient();
            string result = client.GetAsync(link).Result.Content.ReadAsStringAsync().Result;
            Models.Member[] members = JsonSerializer.Deserialize<Models.Member[]>
                (result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            dgvListMember.DataSource = members;
        }

        public void LoadProduct()
        {
            string link = "http://localhost:5241/api/default/listProduct";
            HttpClient client = new HttpClient();
            string result = client.GetAsync(link).Result.Content.ReadAsStringAsync().Result;
            Models.Product[] products = JsonSerializer.Deserialize<Models.Product[]>
                (result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            dgvListProduct.DataSource = products;
        }

        public void LoadOrder()
        {          
            string link = "http://localhost:5241/api/default/listorder";
            HttpClient client = new HttpClient();
            string result = client.GetAsync(link).Result.Content.ReadAsStringAsync().Result;
            Models.Order[] orders = JsonSerializer.Deserialize<Models.Order[]>
                (result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            dgvListOrder.DataSource = orders;
        }

        private void btnListClick_Click(object sender, EventArgs e)
        {
            LoadMember();           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadMember();
            LoadProduct();
            LoadOrder();
        }

        private void btnEndClick_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSearchClick_Click(object sender, EventArgs e)
        {
            string str = string.Format("?MemberId={0}", txtMemberId.Text);
            string link = "http://localhost:5241/api/default/searchid" + str;
            HttpClient client = new HttpClient();
            string result = client.GetAsync(link).Result.Content.ReadAsStringAsync().Result;
            Models.Member member = JsonSerializer.Deserialize<Models.Member>
                (result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (member != null)
            {
                txtMemberId.Text = member.MemberId.ToString();
                txtEmail.Text = member.Email;
                txtCompanyName.Text = member.CompanyName;
                txtCity.Text = member.City;
                txtCountry.Text = member.Country;
                txtPassword.Text = member.Password;
            }
            else
            {
                MessageBox.Show("Member is not found " + txtMemberId.Text, "ERROR");
            }
        }
        private void btnAddClick_Click(object sender, EventArgs e)
        {
            string url = "http://localhost:5241/api/default/addmember";
            var client = new WebClient();
            var member = new NameValueCollection();
            member["Email"] = txtEmail.Text;
            member["CompanyName"] = txtCompanyName.Text;
            member["City"] = txtCity.Text;
            member["Country"] = txtCountry.Text;
            member["Password"] = txtPassword.Text;
            var respone = client.UploadValues(url, member);
            string msg = Encoding.UTF8.GetString(respone);
            MessageBox.Show("Adding result " + msg);
        }

        private void btnUpdateClick_Click(object sender, EventArgs e)
        {
            string url = "http://localhost:5241/api/default/editmember";
            var client = new WebClient();
            var member = new NameValueCollection();
            member["MemberId"] = txtMemberId.Text;
            member["Email"] = txtEmail.Text;
            member["CompanyName"] = txtCompanyName.Text;
            member["City"] = txtCity.Text;
            member["Country"] = txtCountry.Text;
            member["Password"] = txtPassword.Text;
            var respone = client.UploadValues(url, "PUT",member);
            string msg = Encoding.UTF8.GetString(respone);
            MessageBox.Show("Editing result " + msg);
        }

        private void btnDeleteClick_Click(object sender, EventArgs e)
        {
            string str = string.Format("?MemberId={0}", txtMemberId.Text);
            string url = "http://localhost:5241/api/default/deletemember" + str;
            WebRequest req = WebRequest.CreateHttp(url);
            req.Method = "DELETE";
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            if (res.StatusCode == HttpStatusCode.OK)
            {
                MessageBox.Show("Delete Succesful MemberId: " + txtMemberId.Text);
            }
            else
            {
                MessageBox.Show("Delete Unsuccesful MemberId: " + txtMemberId.Text);
            }
        }     

        private void btnLoadListProduct_Click(object sender, EventArgs e)
        {
            LoadProduct();
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            string url = "http://localhost:5241/api/default/addproduct";
            HttpClient httpClient = new HttpClient();
            string content = JsonSerializer.Serialize(new
            {
                ProductId = txtProductId.Text,
                CategoryId = txtCategoryId.Text,
                ProductName = txtProductName.Text,
                Weight = txtWeight.Text,
                UnitPrice = txtUnitPrice.Text,
                UnitsInStock = txtUnitInStock.Text
            });
            string msg = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8)).Result.Content.ReadAsStringAsync().Result;
            MessageBox.Show("Adding result " + msg);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string str = string.Format("?ProductName={0}", txtProductName.Text);
            string link = "http://localhost:5241/api/default/searchproductname" + str;
            HttpClient client = new HttpClient();
            string result = client.GetAsync(link).Result.Content.ReadAsStringAsync().Result;
            Models.Product product = JsonSerializer.Deserialize<Models.Product>
                (result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (product != null)
            {
                txtProductId.Text = product.ProductId.ToString();
                txtCategoryId.Text = product.CategoryId.ToString();
                txtProductName.Text = product.ProductName;
                txtWeight.Text = product.weight.ToString();
                txtUnitPrice.Text = product.UnitPrice.ToString();
                txtUnitInStock.Text = product.UnitsInStock.ToString();
            }
            else
            {
                MessageBox.Show("Product is not found " + txtProductId.Text, "ERROR");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string url = "http://localhost:5241/api/default/editproduct";
            HttpClient httpClient = new HttpClient();
            string content = JsonSerializer.Serialize(new
            {
                ProductId = txtProductId.Text,
                CategoryId = txtCategoryId.Text,
                ProductName = txtProductName.Text,
                Weight = txtWeight.Text,
                UnitPrice = txtUnitPrice.Text,
                UnitsInStock = txtUnitInStock.Text
            });
            string msg = httpClient.PutAsync(url, new StringContent(content, Encoding.UTF8)).Result.Content.ReadAsStringAsync().Result;
            MessageBox.Show("Update result " + msg);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string str = string.Format("?ProductId={0}", txtProductId.Text);
            string url = "http://localhost:5241/api/default/deleteproduct" + str;
            HttpClient client = new HttpClient();
            Task<HttpResponseMessage> resp = client.DeleteAsync(url);
            if (resp.Result.IsSuccessStatusCode)
            {
                MessageBox.Show("Delete Succesful Product: " + txtProductName.Text);
            }
            else
            {
                MessageBox.Show("Delete Unsuccesful Product: " + txtProductName.Text);
            }
        }

        private void btnLoadOrder_Click(object sender, EventArgs e)
        {
            LoadOrder();
        }

        private void btnCloseOrder_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            string url = "http://localhost:5241/api/default/addorder";
            HttpClient httpClient = new HttpClient();
            string content = JsonSerializer.Serialize(new
            {
                OrderId = txtOrderId.Text,
                MemberId = txtMemberId.Text,
                OrderDate = txtOrderDate.Text,
                Required = txtRequired.Text,
                ShippedDate = txtShippedDate.Text,
                Freight = txtFreight.Text
            });
            string msg = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8)).Result.Content.ReadAsStringAsync().Result;
            MessageBox.Show("Adding result " + msg);
        }

        private void btnSearchOrder_Click(object sender, EventArgs e)
        {
            string str = string.Format("?OrderId={0}", txtOrderId.Text);
            string link = "http://localhost:5241/api/default/searchorderid" + str;
            HttpClient client = new HttpClient();
            string result = client.GetAsync(link).Result.Content.ReadAsStringAsync().Result;
            Models.Order order = JsonSerializer.Deserialize<Models.Order>
                (result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (order != null)
            {
                txtOrderId.Text = order.OrderId.ToString();
                txtMemberIdOrder.Text = order.MemberId.ToString();
                txtOrderDate.Text = order.OrderDate;
                txtRequired.Text = order.Required;
                txtShippedDate.Text = order.ShippedDate;
                txtFreight.Text = order.Freight.ToString();
            }
            else
            {
                MessageBox.Show("Order is not found " + txtOrderId.Text, "ERROR");
            }
        }

        private void btnUpdateOrder_Click(object sender, EventArgs e)
        {
            string url = "http://localhost:5241/api/default/editorder";
            HttpClient httpClient = new HttpClient();
            string content = JsonSerializer.Serialize(new
            {
                OrderId = txtOrderId.Text,
                MemberId = txtMemberId.Text,
                OrderDate = txtOrderDate.Text,
                Required = txtRequired.Text,
                ShippedDate = txtShippedDate.Text,
                Freight = txtFreight.Text
            });
            string msg = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8)).Result.Content.ReadAsStringAsync().Result;
            MessageBox.Show("Adding result " + msg);
        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            string str = string.Format("?OrderId={0}", txtOrderId.Text);
            string link = "http://localhost:5241/api/default/deleteorder" + str;
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage res = httpClient.DeleteAsync(link).Result;
            if (res.IsSuccessStatusCode)
            {
                MessageBox.Show("Delete Succesful Order: " + txtOrderId.Text);
            }
            else
            {
                MessageBox.Show("Delete Unsuccesful Order: " + txtOrderId.Text);
            }
        }

    
    }
}
