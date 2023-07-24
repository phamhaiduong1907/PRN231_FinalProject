namespace eStoreClient
{
    partial class Payment
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvPayment = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
<<<<<<< HEAD
=======
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.btnInvoice = new System.Windows.Forms.Button();
            this.btnPayment = new System.Windows.Forms.Button();
>>>>>>> d41c41faedc246ca3471cf207cb5c5a0e856d38f
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSubtractionItem = new System.Windows.Forms.Button();
            this.btnPayment = new System.Windows.Forms.Button();
            this.btnInvoice = new System.Windows.Forms.Button();
            this.btnPlusItem = new System.Windows.Forms.Button();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.btnAddItem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPayment
            // 
            this.dgvPayment.AllowUserToAddRows = false;
            this.dgvPayment.AllowUserToDeleteRows = false;
            this.dgvPayment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPayment.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvPayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPayment.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvPayment.Location = new System.Drawing.Point(-5, 0);
            this.dgvPayment.Name = "dgvPayment";
            this.dgvPayment.RowHeadersWidth = 51;
            this.dgvPayment.RowTemplate.Height = 24;
            this.dgvPayment.Size = new System.Drawing.Size(978, 339);
            this.dgvPayment.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "CategoryID";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Product Name";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Weight";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 125;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Unit Price";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 125;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Unit InStock";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 125;
            // 
<<<<<<< HEAD
=======
            // btnAddItem
            // 
            this.btnAddItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddItem.Location = new System.Drawing.Point(979, 133);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(116, 53);
            this.btnAddItem.TabIndex = 1;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveItem.Location = new System.Drawing.Point(318, 633);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(141, 53);
            this.btnRemoveItem.TabIndex = 2;
            this.btnRemoveItem.Text = "Remove Item";
            this.btnRemoveItem.UseVisualStyleBackColor = true;
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);
            // 
            // btnInvoice
            // 
            this.btnInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInvoice.Location = new System.Drawing.Point(608, 633);
            this.btnInvoice.Name = "btnInvoice";
            this.btnInvoice.Size = new System.Drawing.Size(116, 53);
            this.btnInvoice.TabIndex = 4;
            this.btnInvoice.Text = "Invoice";
            this.btnInvoice.UseVisualStyleBackColor = true;
            this.btnInvoice.Click += new System.EventHandler(this.btnInvoiceClick);
            // 
            // btnPayment
            // 
            this.btnPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayment.Location = new System.Drawing.Point(474, 633);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(116, 53);
            this.btnPayment.TabIndex = 5;
            this.btnPayment.Text = "Payment";
            this.btnPayment.UseVisualStyleBackColor = true;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
>>>>>>> d41c41faedc246ca3471cf207cb5c5a0e856d38f
            // dgvCart
            // 
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AllowUserToDeleteRows = false;
            this.dgvCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCart.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column7});
            this.dgvCart.Location = new System.Drawing.Point(-5, 358);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.RowHeadersWidth = 51;
            this.dgvCart.RowTemplate.Height = 24;
            this.dgvCart.Size = new System.Drawing.Size(1110, 269);
            this.dgvCart.TabIndex = 7;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Product";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Quantity";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            // 
            // btnSubtractionItem
            // 
            this.btnSubtractionItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubtractionItem.Image = global::eStoreClient.Properties.Resources.minus;
            this.btnSubtractionItem.Location = new System.Drawing.Point(292, 633);
            this.btnSubtractionItem.Name = "btnSubtractionItem";
            this.btnSubtractionItem.Size = new System.Drawing.Size(65, 53);
            this.btnSubtractionItem.TabIndex = 6;
            this.btnSubtractionItem.UseVisualStyleBackColor = true;
            // 
            // btnPayment
            // 
            this.btnPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayment.Image = global::eStoreClient.Properties.Resources.cashless_payment;
            this.btnPayment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPayment.Location = new System.Drawing.Point(618, 633);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(116, 53);
            this.btnPayment.TabIndex = 5;
            this.btnPayment.Text = "Payment";
            this.btnPayment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPayment.UseVisualStyleBackColor = true;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // btnInvoice
            // 
            this.btnInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInvoice.Image = global::eStoreClient.Properties.Resources.bill;
            this.btnInvoice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInvoice.Location = new System.Drawing.Point(740, 633);
            this.btnInvoice.Name = "btnInvoice";
            this.btnInvoice.Size = new System.Drawing.Size(116, 53);
            this.btnInvoice.TabIndex = 4;
            this.btnInvoice.Text = "Invoice";
            this.btnInvoice.UseVisualStyleBackColor = true;
            this.btnInvoice.Click += new System.EventHandler(this.btnInvoiceClick);
            // 
            // btnPlusItem
            // 
            this.btnPlusItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlusItem.Image = global::eStoreClient.Properties.Resources.plus2;
            this.btnPlusItem.Location = new System.Drawing.Point(205, 633);
            this.btnPlusItem.Name = "btnPlusItem";
            this.btnPlusItem.Size = new System.Drawing.Size(65, 53);
            this.btnPlusItem.TabIndex = 3;
            this.btnPlusItem.UseVisualStyleBackColor = true;
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveItem.Image = global::eStoreClient.Properties.Resources.remove;
            this.btnRemoveItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemoveItem.Location = new System.Drawing.Point(471, 633);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(141, 53);
            this.btnRemoveItem.TabIndex = 2;
            this.btnRemoveItem.Text = "Remove Item";
            this.btnRemoveItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRemoveItem.UseVisualStyleBackColor = true;
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAddItem.Image = global::eStoreClient.Properties.Resources.plus;
            this.btnAddItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddItem.Location = new System.Drawing.Point(979, 133);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(116, 53);
            this.btnAddItem.TabIndex = 1;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // Payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 689);
            this.Controls.Add(this.dgvCart);
            this.Controls.Add(this.btnPayment);
            this.Controls.Add(this.btnInvoice);
            this.Controls.Add(this.btnRemoveItem);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.dgvPayment);
            this.Name = "Payment";
            this.Text = "Payment";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPayment;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.Button btnInvoice;
        private System.Windows.Forms.Button btnPayment;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    }
}