using eStoreClient.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
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
            string link = "http://localhost/sales/api/default/listmember";
            WebResponse res;
            HttpWeb(link, out res);
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Models.Member[]));
            object data = js.ReadObject(res.GetResponseStream());
            Models.Member[] members = data as Models.Member[];
            dgvListMember.DataSource = members;
        }

        public void LoadProduct()
        {
            string link = "http://localhost/sales/api/default/listProduct";
            WebResponse res;
            HttpWeb(link, out res);
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Models.Product[]));
            object data = js.ReadObject(res.GetResponseStream());
            Models.Product[] products = data as Models.Product[];
            dgvListProduct.DataSource = products;
        }

        public void LoadOrder()
        {          
            string link = "http://localhost/sales/api/default/listorder";
            WebResponse res;
            HttpWeb(link, out res);
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Models.Order[]));
            object data = js.ReadObject(res.GetResponseStream());           
            Models.Order[] orders = data as Models.Order[];
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
            string link = "http://localhost/sales/api/default/searchid" + str;
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(link);
            WebResponse res = req.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Models.Member));
            Stream responseStream = res.GetResponseStream();
            object data = js.ReadObject(responseStream);
            Models.Member member = (Models.Member)data;
            responseStream.Close();
            res.Close();

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
            string url = "http://localhost/sales/api/default/addmember";
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
            string url = "http://localhost/sales/api/default/editmember";
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
            string url = "http://localhost/sales/api/default/deletemember" + str;
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
            string url = "http://localhost/sales/api/default/addproduct";
            var client = new WebClient();
            var product = new NameValueCollection();
            product["ProductId"] = txtProductId.Text;
            product["CategoryId"] = txtCategoryId.Text;
            product["ProductName"] = txtProductName.Text;
            product["weight"] = txtWeight.Text;
            product["UnitPrice"] = txtUnitPrice.Text;
            product["UnitsInStock"] = txtUnitInStock.Text;
            var respone = client.UploadValues(url, product);
            string msg = Encoding.UTF8.GetString(respone);
            MessageBox.Show("Adding result " + msg);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string str = string.Format("?ProductName={0}", txtProductName.Text);
            string link = "http://localhost/sales/api/default/searchproductname" + str;
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(link);
            WebResponse res = req.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Models.Product));
            Stream responseStream = res.GetResponseStream();
            object data = js.ReadObject(responseStream);
            Models.Product product = (Models.Product)data;
            responseStream.Close();
            res.Close();

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
            string url = "http://localhost/sales/api/default/editproduct";
            var client = new WebClient();
            var product = new NameValueCollection();
            product["ProductId"] = txtProductId.Text;
            product["CategoryId"] = txtCategoryId.Text;
            product["ProductName"] = txtProductName.Text;
            product["weight"] = txtWeight.Text;
            product["UnitPrice"] = txtUnitPrice.Text;
            product["UnitsInStock"] = txtUnitInStock.Text;
            var respone = client.UploadValues(url, "PUT",product);
            string msg = Encoding.UTF8.GetString(respone);
            MessageBox.Show("Update result " + msg);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string str = string.Format("?ProductId={0}", txtProductId.Text);
            string url = "http://localhost/sales/api/default/deleteproduct" + str;
            WebRequest req = WebRequest.CreateHttp(url);
            req.Method = "DELETE";
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            if (res.StatusCode == HttpStatusCode.OK)
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
            string url = "http://localhost/sales/api/default/addorder";
            var client = new WebClient();
            var order = new NameValueCollection();
            order["OrderId"] = txtOrderId.Text;
            order["MemberId"] = txtMemberId.Text;
            order["OrderDate"] = txtOrderDate.Text;
            order["Required"] = txtRequired.Text;
            order["ShippedDate"] = txtShippedDate.Text;
            order["Freight"] = txtFreight.Text;
            var respone = client.UploadValues(url, order);
            string msg = Encoding.UTF8.GetString(respone);
            MessageBox.Show("Adding result " + msg);
        }

        private void btnSearchOrder_Click(object sender, EventArgs e)
        {
            string str = string.Format("?OrderId={0}", txtOrderId.Text);
            string link = "http://localhost/sales/api/default/searchorderid" + str;
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(link);
            WebResponse res = req.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Models.Order));
            Stream responseStream = res.GetResponseStream();
            object data = js.ReadObject(responseStream);
            Models.Order order = (Models.Order)data;
            responseStream.Close();
            res.Close();

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
            string url = "http://localhost/sales/api/default/editorder";
            var client = new WebClient();
            var order = new NameValueCollection();
            order["OrderId"] = txtOrderId.Text;
            order["MemberId"] = txtMemberId.Text;
            order["OrderDate"] = txtOrderDate.Text;
            order["Required"] = txtRequired.Text;
            order["ShippedDate"] = txtShippedDate.Text;
            order["Freight"] = txtFreight.Text;
            var respone = client.UploadValues(url, "PUT",order);
            string msg = Encoding.UTF8.GetString(respone);
            MessageBox.Show("Adding result " + msg);
        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            string str = string.Format("?OrderId={0}", txtOrderId.Text);
            string link = "http://localhost/sales/api/default/deleteorder" + str;
            WebRequest req = WebRequest.CreateHttp(link);
            req.Method = "DELETE";
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            if (res.StatusCode == HttpStatusCode.OK)
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
