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
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eStoreClient
{
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
            CenterToParent();
            LoadMember();
            LoadOrder();
        }

        public void LoadMember()
        {
            string link = "http://localhost:5241/api/default/listmember";
            HttpClient client = new HttpClient();
            string result = client.GetAsync(link).Result.Content.ReadAsStringAsync().Result;
            Models.Member[] members = JsonSerializer.Deserialize<Models.Member[]>
                (result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true});
            dgvMemberUser.DataSource = members;
        }
        public void LoadOrder()
        {
            string link = "http://localhost:5241/api/default/listorder";
            HttpClient client = new HttpClient();
            string result = client.GetAsync(link).Result.Content.ReadAsStringAsync().Result;
            Models.Order[] orders = JsonSerializer.Deserialize<Models.Order[]>
                (result, new JsonSerializerOptions{ PropertyNameCaseInsensitive = true});
            dgvOrderMember.DataSource = orders;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string url = "http://localhost:5241/api/default/editmember";
            string content = JsonSerializer.Serialize(new
            {
                MemberId = txtMemberId.Text,
                Email = txtEmail.Text,
                CompanyName = txtCompanyName.Text,
                City = txtCity.Text,
                Country = txtCountry.Text,
                Password = txtPassword.Text
            });
            var httpClient = new HttpClient();
            string msg = httpClient.PutAsync(url, new StringContent(content, Encoding.UTF8)).Result.Content.ReadAsStringAsync().Result;
            MessageBox.Show("Editing result " + msg);
        }

        private void btnPaymentOrderClick(object sender, EventArgs e)
        {
            this.Hide();
            Payment payment = new Payment();
            payment.Show();
        }
    }
}
