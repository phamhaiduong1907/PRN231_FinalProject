using eStoreClient.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Windows.Forms;
using System.Text.Json;

namespace eStoreClient
{
    public partial class LoginForm : Form
    {
        private readonly IAuthRepository _authRepository;
        public LoginForm()
        {         
            InitializeComponent();
            CenterToParent();
           
            _authRepository = new AuthRepository();
        }

        private void btnCloseClick_Click(object sender, EventArgs e)
        {
            Close();
        }

        private Models.Member GetMember(string username, string password)
        {
          
            try
            {
                Models.Member member = _authRepository.CheckLogin(username, password);
                return member;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while getting member: " + ex.Message);
            }
        }
        private void btnLoginClick_Click(object sender, EventArgs e)
        {
            eStoreClient eStoreClient = new eStoreClient();
            UserForm userForm = new UserForm();
            //string json = File.ReadAllText("D:\\FPT University\\Ki_8\\PRN231\\Project\\PRN231_FinalProject\\eStoreClient\\appsettings.json");

            //DefaultAccount defaultAccount = JsonConvert.DeserializeObject<DefaultAccount>(json);

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            string emailA = config["admin:email"];
            string passwordA = config["admin:password"];
            string role = config["admin:role"];

            string username, password;
            username = txtUsername.Text;
            password = txtPassword.Text;

            string link = $"http://localhost:5241/api/default/searchmemberbyemail/{username}/{password}";
            HttpClient client = new HttpClient();
            string result = client.GetAsync(link).Result.Content.ReadAsStringAsync().Result;
            Models.Member memberAccount = JsonSerializer.Deserialize<Models.Member>
                (result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            MessageBox.Show(result);

            if (memberAccount != null) {
                this.Hide();
                userForm.Show();
            }else if(username.Equals(emailA) && password.Equals(passwordA))
            {
                this.Hide();
                eStoreClient.Show();
            }
            else if (!username.Equals(emailA) && !password.Equals(passwordA))
            {
                MessageBox.Show("Login admin fail, This user does not exist or username, password not true!", "Notificaiton");
            }else{
                MessageBox.Show("Login fail , This user does not exist or username, password not true!", "Notificaiton");
                this.Show();               
            }
        }
    }
}
