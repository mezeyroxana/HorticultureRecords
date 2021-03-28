
namespace HorticultureRecords
{
    partial class OrdersForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ordersFlowers_dgw = new System.Windows.Forms.DataGridView();
            this.FlowerOrderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FlowerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FlowerGenus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModifyFlower = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DeleteFlower = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.orders_dgw = new System.Windows.Forms.DataGridView();
            this.OrderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderingCustomerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsDeliveryRequested = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsCompleted = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ModifyOrder = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DeleteOrder = new System.Windows.Forms.DataGridViewButtonColumn();
            this.customerEmail_tb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.customerName_tb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.customerPhoneNumber_tb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.customerCity_tb = new System.Windows.Forms.TextBox();
            this.customerAddress_tb = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.saveCustomerData_btn = new System.Windows.Forms.Button();
            this.customerData_panel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ordersFlowers_dgw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orders_dgw)).BeginInit();
            this.customerData_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ordersFlowers_dgw
            // 
            this.ordersFlowers_dgw.AllowUserToAddRows = false;
            this.ordersFlowers_dgw.AllowUserToDeleteRows = false;
            this.ordersFlowers_dgw.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(249)))), ((int)(((byte)(239)))));
            this.ordersFlowers_dgw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ordersFlowers_dgw.BackgroundColor = System.Drawing.Color.White;
            this.ordersFlowers_dgw.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.ordersFlowers_dgw.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(160)))), ((int)(((byte)(31)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(160)))), ((int)(((byte)(31)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ordersFlowers_dgw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.ordersFlowers_dgw.ColumnHeadersHeight = 45;
            this.ordersFlowers_dgw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ordersFlowers_dgw.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FlowerOrderId,
            this.FlowerId,
            this.FlowerGenus,
            this.Quantity,
            this.ModifyFlower,
            this.DeleteFlower});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(105)))), ((int)(((byte)(20)))));
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(250)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ordersFlowers_dgw.DefaultCellStyle = dataGridViewCellStyle3;
            this.ordersFlowers_dgw.EnableHeadersVisualStyles = false;
            this.ordersFlowers_dgw.GridColor = System.Drawing.Color.Black;
            this.ordersFlowers_dgw.Location = new System.Drawing.Point(621, 60);
            this.ordersFlowers_dgw.Margin = new System.Windows.Forms.Padding(4);
            this.ordersFlowers_dgw.MultiSelect = false;
            this.ordersFlowers_dgw.Name = "ordersFlowers_dgw";
            this.ordersFlowers_dgw.RowHeadersVisible = false;
            this.ordersFlowers_dgw.RowTemplate.Height = 30;
            this.ordersFlowers_dgw.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ordersFlowers_dgw.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ordersFlowers_dgw.Size = new System.Drawing.Size(550, 240);
            this.ordersFlowers_dgw.TabIndex = 1;
            this.ordersFlowers_dgw.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ordersFlowers_dgw_CellContentClick);
            // 
            // FlowerOrderId
            // 
            this.FlowerOrderId.HeaderText = "Megrendelés azonosító";
            this.FlowerOrderId.Name = "FlowerOrderId";
            this.FlowerOrderId.Visible = false;
            // 
            // FlowerId
            // 
            this.FlowerId.HeaderText = "VirágId";
            this.FlowerId.Name = "FlowerId";
            this.FlowerId.Visible = false;
            // 
            // FlowerGenus
            // 
            this.FlowerGenus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FlowerGenus.HeaderText = "Virág fajta";
            this.FlowerGenus.Name = "FlowerGenus";
            // 
            // Quantity
            // 
            this.Quantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Quantity.HeaderText = "Mennyiség";
            this.Quantity.Name = "Quantity";
            this.Quantity.Width = 106;
            // 
            // ModifyFlower
            // 
            this.ModifyFlower.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ModifyFlower.HeaderText = "";
            this.ModifyFlower.Name = "ModifyFlower";
            this.ModifyFlower.Text = "Mentés";
            this.ModifyFlower.UseColumnTextForButtonValue = true;
            // 
            // DeleteFlower
            // 
            this.DeleteFlower.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteFlower.HeaderText = "";
            this.DeleteFlower.Name = "DeleteFlower";
            this.DeleteFlower.Text = "Törlés";
            this.DeleteFlower.UseColumnTextForButtonValue = true;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(105)))), ((int)(((byte)(20)))));
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(1184, 50);
            this.label7.TabIndex = 17;
            this.label7.Text = " Megrendelések";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // orders_dgw
            // 
            this.orders_dgw.AllowUserToAddRows = false;
            this.orders_dgw.AllowUserToDeleteRows = false;
            this.orders_dgw.AllowUserToResizeColumns = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(249)))), ((int)(((byte)(239)))));
            this.orders_dgw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.orders_dgw.BackgroundColor = System.Drawing.Color.White;
            this.orders_dgw.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.orders_dgw.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(160)))), ((int)(((byte)(31)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(160)))), ((int)(((byte)(31)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.orders_dgw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.orders_dgw.ColumnHeadersHeight = 45;
            this.orders_dgw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.orders_dgw.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrderId,
            this.OrderingCustomerId,
            this.OrderName,
            this.IsDeliveryRequested,
            this.IsCompleted,
            this.ModifyOrder,
            this.DeleteOrder});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(105)))), ((int)(((byte)(20)))));
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(250)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.orders_dgw.DefaultCellStyle = dataGridViewCellStyle6;
            this.orders_dgw.EnableHeadersVisualStyles = false;
            this.orders_dgw.GridColor = System.Drawing.Color.Black;
            this.orders_dgw.Location = new System.Drawing.Point(13, 60);
            this.orders_dgw.Margin = new System.Windows.Forms.Padding(4);
            this.orders_dgw.MultiSelect = false;
            this.orders_dgw.Name = "orders_dgw";
            this.orders_dgw.RowHeadersVisible = false;
            this.orders_dgw.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.orders_dgw.RowTemplate.Height = 30;
            this.orders_dgw.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.orders_dgw.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.orders_dgw.Size = new System.Drawing.Size(586, 592);
            this.orders_dgw.TabIndex = 18;
            this.orders_dgw.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.orders_dgw_CellContentClick);
            this.orders_dgw.SelectionChanged += new System.EventHandler(this.orders_dgw_SelectionChanged);
            // 
            // OrderId
            // 
            this.OrderId.HeaderText = "RendelésId";
            this.OrderId.Name = "OrderId";
            this.OrderId.Visible = false;
            // 
            // OrderingCustomerId
            // 
            this.OrderingCustomerId.HeaderText = "MegrendelőId";
            this.OrderingCustomerId.Name = "OrderingCustomerId";
            this.OrderingCustomerId.Visible = false;
            // 
            // OrderName
            // 
            this.OrderName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.OrderName.HeaderText = "Megrendelő neve";
            this.OrderName.Name = "OrderName";
            this.OrderName.ReadOnly = true;
            // 
            // IsDeliveryRequested
            // 
            this.IsDeliveryRequested.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.IsDeliveryRequested.HeaderText = "Szállítás";
            this.IsDeliveryRequested.Name = "IsDeliveryRequested";
            this.IsDeliveryRequested.Width = 68;
            // 
            // IsCompleted
            // 
            this.IsCompleted.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.IsCompleted.HeaderText = "Teljesített";
            this.IsCompleted.Name = "IsCompleted";
            this.IsCompleted.Width = 79;
            // 
            // ModifyOrder
            // 
            this.ModifyOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ModifyOrder.HeaderText = "";
            this.ModifyOrder.Name = "ModifyOrder";
            this.ModifyOrder.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ModifyOrder.Text = "Mentés";
            this.ModifyOrder.UseColumnTextForButtonValue = true;
            // 
            // DeleteOrder
            // 
            this.DeleteOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteOrder.HeaderText = "";
            this.DeleteOrder.Name = "DeleteOrder";
            this.DeleteOrder.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DeleteOrder.Text = "Törlés";
            this.DeleteOrder.UseColumnTextForButtonValue = true;
            // 
            // customerEmail_tb
            // 
            this.customerEmail_tb.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.customerEmail_tb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(160)))), ((int)(((byte)(31)))));
            this.customerEmail_tb.Location = new System.Drawing.Point(210, 134);
            this.customerEmail_tb.Margin = new System.Windows.Forms.Padding(4);
            this.customerEmail_tb.Name = "customerEmail_tb";
            this.customerEmail_tb.Size = new System.Drawing.Size(272, 26);
            this.customerEmail_tb.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(160)))), ((int)(((byte)(31)))));
            this.label1.Location = new System.Drawing.Point(51, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 22);
            this.label1.TabIndex = 19;
            this.label1.Text = "Név:";
            // 
            // customerName_tb
            // 
            this.customerName_tb.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.customerName_tb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(160)))), ((int)(((byte)(31)))));
            this.customerName_tb.Location = new System.Drawing.Point(210, 54);
            this.customerName_tb.Margin = new System.Windows.Forms.Padding(4);
            this.customerName_tb.Name = "customerName_tb";
            this.customerName_tb.Size = new System.Drawing.Size(272, 26);
            this.customerName_tb.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(160)))), ((int)(((byte)(31)))));
            this.label2.Location = new System.Drawing.Point(51, 98);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 22);
            this.label2.TabIndex = 21;
            this.label2.Text = "Telefonszám:";
            // 
            // customerPhoneNumber_tb
            // 
            this.customerPhoneNumber_tb.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.customerPhoneNumber_tb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(160)))), ((int)(((byte)(31)))));
            this.customerPhoneNumber_tb.Location = new System.Drawing.Point(210, 94);
            this.customerPhoneNumber_tb.Margin = new System.Windows.Forms.Padding(4);
            this.customerPhoneNumber_tb.Name = "customerPhoneNumber_tb";
            this.customerPhoneNumber_tb.Size = new System.Drawing.Size(272, 26);
            this.customerPhoneNumber_tb.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(160)))), ((int)(((byte)(31)))));
            this.label3.Location = new System.Drawing.Point(51, 138);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 22);
            this.label3.TabIndex = 23;
            this.label3.Text = "Email cím:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(160)))), ((int)(((byte)(31)))));
            this.label9.Location = new System.Drawing.Point(51, 178);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 22);
            this.label9.TabIndex = 27;
            this.label9.Text = "Város:";
            // 
            // customerCity_tb
            // 
            this.customerCity_tb.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.customerCity_tb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(160)))), ((int)(((byte)(31)))));
            this.customerCity_tb.Location = new System.Drawing.Point(210, 174);
            this.customerCity_tb.Margin = new System.Windows.Forms.Padding(4);
            this.customerCity_tb.Name = "customerCity_tb";
            this.customerCity_tb.Size = new System.Drawing.Size(272, 26);
            this.customerCity_tb.TabIndex = 28;
            // 
            // customerAddress_tb
            // 
            this.customerAddress_tb.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.customerAddress_tb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(160)))), ((int)(((byte)(31)))));
            this.customerAddress_tb.Location = new System.Drawing.Point(210, 214);
            this.customerAddress_tb.Margin = new System.Windows.Forms.Padding(4);
            this.customerAddress_tb.Name = "customerAddress_tb";
            this.customerAddress_tb.Size = new System.Drawing.Size(272, 26);
            this.customerAddress_tb.TabIndex = 30;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(160)))), ((int)(((byte)(31)))));
            this.label8.Location = new System.Drawing.Point(51, 218);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 22);
            this.label8.TabIndex = 29;
            this.label8.Text = "Lakcím:";
            // 
            // saveCustomerData_btn
            // 
            this.saveCustomerData_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(160)))), ((int)(((byte)(31)))));
            this.saveCustomerData_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveCustomerData_btn.Font = new System.Drawing.Font("Cambria", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.saveCustomerData_btn.ForeColor = System.Drawing.Color.White;
            this.saveCustomerData_btn.Location = new System.Drawing.Point(210, 264);
            this.saveCustomerData_btn.Margin = new System.Windows.Forms.Padding(4);
            this.saveCustomerData_btn.Name = "saveCustomerData_btn";
            this.saveCustomerData_btn.Size = new System.Drawing.Size(160, 55);
            this.saveCustomerData_btn.TabIndex = 31;
            this.saveCustomerData_btn.Text = "Mentés";
            this.saveCustomerData_btn.UseVisualStyleBackColor = false;
            this.saveCustomerData_btn.Click += new System.EventHandler(this.saveCustomerData_btn_Click);
            // 
            // customerData_panel
            // 
            this.customerData_panel.BackColor = System.Drawing.Color.Transparent;
            this.customerData_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customerData_panel.Controls.Add(this.label5);
            this.customerData_panel.Controls.Add(this.label2);
            this.customerData_panel.Controls.Add(this.saveCustomerData_btn);
            this.customerData_panel.Controls.Add(this.label3);
            this.customerData_panel.Controls.Add(this.customerPhoneNumber_tb);
            this.customerData_panel.Controls.Add(this.label9);
            this.customerData_panel.Controls.Add(this.customerName_tb);
            this.customerData_panel.Controls.Add(this.label1);
            this.customerData_panel.Controls.Add(this.customerCity_tb);
            this.customerData_panel.Controls.Add(this.customerEmail_tb);
            this.customerData_panel.Controls.Add(this.customerAddress_tb);
            this.customerData_panel.Controls.Add(this.label8);
            this.customerData_panel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.customerData_panel.Location = new System.Drawing.Point(621, 312);
            this.customerData_panel.Name = "customerData_panel";
            this.customerData_panel.Size = new System.Drawing.Size(550, 340);
            this.customerData_panel.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(160)))), ((int)(((byte)(31)))));
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(548, 40);
            this.label5.TabIndex = 32;
            this.label5.Text = " Megrendelő adatai";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // OrdersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1184, 664);
            this.Controls.Add(this.customerData_panel);
            this.Controls.Add(this.orders_dgw);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ordersFlowers_dgw);
            this.Name = "OrdersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Megrendelések";
            this.Load += new System.EventHandler(this.OrdersForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ordersFlowers_dgw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orders_dgw)).EndInit();
            this.customerData_panel.ResumeLayout(false);
            this.customerData_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ordersFlowers_dgw;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView orders_dgw;
        private System.Windows.Forms.TextBox customerEmail_tb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox customerName_tb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox customerPhoneNumber_tb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox customerCity_tb;
        private System.Windows.Forms.TextBox customerAddress_tb;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button saveCustomerData_btn;
        private System.Windows.Forms.Panel customerData_panel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderingCustomerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsDeliveryRequested;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsCompleted;
        private System.Windows.Forms.DataGridViewButtonColumn ModifyOrder;
        private System.Windows.Forms.DataGridViewButtonColumn DeleteOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn FlowerOrderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn FlowerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn FlowerGenus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewButtonColumn ModifyFlower;
        private System.Windows.Forms.DataGridViewButtonColumn DeleteFlower;
    }
}