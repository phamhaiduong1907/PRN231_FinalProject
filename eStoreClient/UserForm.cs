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
            string link = "http://localhost/sales/api/default/listmember";
            HttpWebRequest req = HttpWebRequest.CreateHttp(link);
            WebResponse res = req.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Models.Member[]));
            object data = js.ReadObject(res.GetResponseStream());
            Models.Member[] members = data as Models.Member[];
            dgvMemberUser.DataSource = members;
        }
        public void LoadOrder()
        {
            string link = "http://localhost/sales/api/default/listorder";
            HttpWebRequest req = HttpWebRequest.CreateHttp(link);
            WebResponse res = req.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Models.Order[]));
            object data = js.ReadObject(res.GetResponseStream());
            Models.Order[] orders = data as Models.Order[];
            dgvOrderMember.DataSource = orders;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
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
            var respone = client.UploadValues(url, "PUT", member);
            string msg = Encoding.UTF8.GetString(respone);
            MessageBox.Show("Editing result " + msg);
        }
    }
}
