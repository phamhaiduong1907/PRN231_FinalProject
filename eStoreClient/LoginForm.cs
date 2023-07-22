using eStoreClient.Models;
using eStoreClient.Repository;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


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
            string json = File.ReadAllText("D:\\FPT University\\Ki_8\\PRN231\\Project\\PRN231_FinalProject\\eStoreClient\\appsettings.json");

            DefaultAccount defaultAccount = JsonConvert.DeserializeObject<DefaultAccount>(json);

            string emailA = defaultAccount.Email;
            string passwordA = defaultAccount.Password;
            string role = defaultAccount.Role;

            String username, password;
            username = txtUsername.Text;
            password = txtPassword.Text;
            
            var memberAccount = GetMember(username, password);

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
