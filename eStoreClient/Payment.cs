﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eStoreClient
{
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
            CenterToParent();
        }

        private void btnInvoiceClick(object sender, EventArgs e)
        {
            this.Hide();
            Invoice invoice = new Invoice();
            invoice.Show();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {

        }
    }
}
