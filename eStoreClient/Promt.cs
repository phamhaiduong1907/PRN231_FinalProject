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
    public partial class Promt : Form
    {
        public DateTime RequiredDate { get; set; }
        public Promt()
        {
            InitializeComponent();
            CenterToParent();
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(dpkRequiredDate.Value != null)
            {
                RequiredDate = dpkRequiredDate.Value;
            }
            else
            {
                MessageBox.Show("Please select required date!");
            }
        }
    }
}
