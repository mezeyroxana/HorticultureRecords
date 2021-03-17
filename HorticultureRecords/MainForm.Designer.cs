
namespace HorticultureRecords
{
    partial class MainForm
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
            this.flowersInStock_dgw = new System.Windows.Forms.DataGridView();
            this.newOrder_btn = new System.Windows.Forms.Button();
            this.orders_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.addNewSells_btn = new System.Windows.Forms.Button();
            this.IdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GenusColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MarketableQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.flowersInStock_dgw)).BeginInit();
            this.SuspendLayout();
            // 
            // flowersInStock_dgw
            // 
            this.flowersInStock_dgw.AllowUserToAddRows = false;
            this.flowersInStock_dgw.AllowUserToDeleteRows = false;
            this.flowersInStock_dgw.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(249)))), ((int)(((byte)(239)))));
            this.flowersInStock_dgw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.flowersInStock_dgw.BackgroundColor = System.Drawing.Color.White;
            this.flowersInStock_dgw.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.flowersInStock_dgw.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(160)))), ((int)(((byte)(31)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(160)))), ((int)(((byte)(31)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.flowersInStock_dgw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.flowersInStock_dgw.ColumnHeadersHeight = 45;
            this.flowersInStock_dgw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.flowersInStock_dgw.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdColumn,
            this.NameColumn,
            this.GenusColumn,
            this.QuantityColumn,
            this.MarketableQuantity});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(105)))), ((int)(((byte)(20)))));
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(250)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.flowersInStock_dgw.DefaultCellStyle = dataGridViewCellStyle3;
            this.flowersInStock_dgw.EnableHeadersVisualStyles = false;
            this.flowersInStock_dgw.GridColor = System.Drawing.Color.Black;
            this.flowersInStock_dgw.Location = new System.Drawing.Point(13, 61);
            this.flowersInStock_dgw.Margin = new System.Windows.Forms.Padding(4);
            this.flowersInStock_dgw.MultiSelect = false;
            this.flowersInStock_dgw.Name = "flowersInStock_dgw";
            this.flowersInStock_dgw.ReadOnly = true;
            this.flowersInStock_dgw.RowHeadersVisible = false;
            this.flowersInStock_dgw.RowTemplate.Height = 30;
            this.flowersInStock_dgw.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.flowersInStock_dgw.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.flowersInStock_dgw.Size = new System.Drawing.Size(969, 535);
            this.flowersInStock_dgw.TabIndex = 0;
            // 
            // newOrder_btn
            // 
            this.newOrder_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(160)))), ((int)(((byte)(31)))));
            this.newOrder_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newOrder_btn.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.newOrder_btn.ForeColor = System.Drawing.Color.White;
            this.newOrder_btn.Location = new System.Drawing.Point(1010, 101);
            this.newOrder_btn.Margin = new System.Windows.Forms.Padding(4);
            this.newOrder_btn.Name = "newOrder_btn";
            this.newOrder_btn.Size = new System.Drawing.Size(160, 55);
            this.newOrder_btn.TabIndex = 1;
            this.newOrder_btn.Text = "Új megrendelés";
            this.newOrder_btn.UseVisualStyleBackColor = false;
            this.newOrder_btn.Click += new System.EventHandler(this.newOrder_btn_Click);
            // 
            // orders_btn
            // 
            this.orders_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(160)))), ((int)(((byte)(31)))));
            this.orders_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.orders_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.orders_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.orders_btn.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.orders_btn.ForeColor = System.Drawing.Color.White;
            this.orders_btn.Location = new System.Drawing.Point(1010, 174);
            this.orders_btn.Margin = new System.Windows.Forms.Padding(4);
            this.orders_btn.Name = "orders_btn";
            this.orders_btn.Size = new System.Drawing.Size(160, 55);
            this.orders_btn.TabIndex = 2;
            this.orders_btn.Text = "Megrendelések";
            this.orders_btn.UseVisualStyleBackColor = false;
            this.orders_btn.Click += new System.EventHandler(this.orders_btn_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(105)))), ((int)(((byte)(20)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1195, 50);
            this.label1.TabIndex = 3;
            this.label1.Text = " Virág nyilvántartás";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // addNewSells_btn
            // 
            this.addNewSells_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(160)))), ((int)(((byte)(31)))));
            this.addNewSells_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.addNewSells_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addNewSells_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addNewSells_btn.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.addNewSells_btn.ForeColor = System.Drawing.Color.White;
            this.addNewSells_btn.Location = new System.Drawing.Point(1010, 248);
            this.addNewSells_btn.Margin = new System.Windows.Forms.Padding(4);
            this.addNewSells_btn.Name = "addNewSells_btn";
            this.addNewSells_btn.Size = new System.Drawing.Size(160, 55);
            this.addNewSells_btn.TabIndex = 4;
            this.addNewSells_btn.Text = "Eladások hozzáadása";
            this.addNewSells_btn.UseVisualStyleBackColor = false;
            this.addNewSells_btn.Click += new System.EventHandler(this.addNewSells_btn_Click);
            // 
            // IdColumn
            // 
            this.IdColumn.HeaderText = "Id";
            this.IdColumn.Name = "IdColumn";
            this.IdColumn.ReadOnly = true;
            this.IdColumn.Visible = false;
            // 
            // NameColumn
            // 
            this.NameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NameColumn.HeaderText = "Név";
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.ReadOnly = true;
            // 
            // GenusColumn
            // 
            this.GenusColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.GenusColumn.HeaderText = "Fajta";
            this.GenusColumn.Name = "GenusColumn";
            this.GenusColumn.ReadOnly = true;
            this.GenusColumn.Width = 65;
            // 
            // QuantityColumn
            // 
            this.QuantityColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.QuantityColumn.HeaderText = "Mennyiség";
            this.QuantityColumn.Name = "QuantityColumn";
            this.QuantityColumn.ReadOnly = true;
            this.QuantityColumn.Width = 106;
            // 
            // MarketableQuantity
            // 
            this.MarketableQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.MarketableQuantity.HeaderText = "Értékesíthető";
            this.MarketableQuantity.Name = "MarketableQuantity";
            this.MarketableQuantity.ReadOnly = true;
            this.MarketableQuantity.Width = 124;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1195, 623);
            this.Controls.Add(this.addNewSells_btn);
            this.Controls.Add(this.flowersInStock_dgw);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.orders_btn);
            this.Controls.Add(this.newOrder_btn);
            this.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Virág nyilvántartás";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.flowersInStock_dgw)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView flowersInStock_dgw;
        private System.Windows.Forms.Button newOrder_btn;
        private System.Windows.Forms.Button orders_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addNewSells_btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn GenusColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantityColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MarketableQuantity;
    }
}