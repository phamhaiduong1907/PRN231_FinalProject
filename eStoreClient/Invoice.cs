﻿using Server.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eStoreClient
{
    public partial class Invoice : Form
    {
        private ResponseOrderDTO order; // Tạo một đối tượng Order để sử dụng

        public Invoice()
        {
            InitializeComponent();
            CenterToParent();
        }

        public Invoice(ResponseOrderDTO order)
        {
            InitializeComponent();
            CenterToParent();
            this.order = order;
            if(order.ShippedDate == null)
            {
                btnExport.Enabled = false;
            }
            txtMemberName.Text = order.MemberName;
            txtOrderDate.Text = order.OrderDate.ToShortDateString();
            txtOrderId.Text = order.OrderId.ToString();
            txtTotal.Text = order.Total.ToString();
            dgvBillIvoice.Columns.Clear();
            dgvBillIvoice.DataSource = order.OrderDetails;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // Tạo nội dung Invoice trước khi in
            string invoiceContent = "Hello Viet Nam";
            //$"Invoice-{order.OrderId}-{order.OrderDate}";

            // Tạo một đối tượng PrintDocument để in nội dung
            System.Drawing.Printing.PrintDocument doc = new System.Drawing.Printing.PrintDocument();
            doc.PrintPage += (s, ev) =>
            {
                ev.Graphics.DrawString(invoiceContent, new Font("Arial", 12), Brushes.Black, ev.MarginBounds.Left, ev.MarginBounds.Top);
            };

            // Hiển thị PrintDialog và in nội dung nếu người dùng chọn in
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                doc.Print();
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            UserForm userForm = new UserForm();
            userForm.Show();
            this.Close();
        }
    }
}
