
namespace HorticultureRecords
{
    partial class AddSellsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddSellsForm));
            this.label1 = new System.Windows.Forms.Label();
            this.flowerQuantity_tb = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.saveSelledFlowerQuantity_btn = new System.Windows.Forms.Button();
            this.flowerGenus_cb = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(105)))), ((int)(((byte)(20)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(551, 50);
            this.label1.TabIndex = 4;
            this.label1.Text = " Eladások hozzáadása";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowerQuantity_tb
            // 
            this.flowerQuantity_tb.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.flowerQuantity_tb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(160)))), ((int)(((byte)(31)))));
            this.flowerQuantity_tb.Location = new System.Drawing.Point(234, 125);
            this.flowerQuantity_tb.Margin = new System.Windows.Forms.Padding(4);
            this.flowerQuantity_tb.Name = "flowerQuantity_tb";
            this.flowerQuantity_tb.Size = new System.Drawing.Size(160, 26);
            this.flowerQuantity_tb.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(160)))), ((int)(((byte)(31)))));
            this.label6.Location = new System.Drawing.Point(36, 128);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(175, 22);
            this.label6.TabIndex = 3;
            this.label6.Text = "Eladott mennyiség:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(160)))), ((int)(((byte)(31)))));
            this.label5.Location = new System.Drawing.Point(36, 83);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 22);
            this.label5.TabIndex = 1;
            this.label5.Text = "Virág fajta:";
            // 
            // saveSelledFlowerQuantity_btn
            // 
            this.saveSelledFlowerQuantity_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(160)))), ((int)(((byte)(31)))));
            this.saveSelledFlowerQuantity_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveSelledFlowerQuantity_btn.Font = new System.Drawing.Font("Cambria", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.saveSelledFlowerQuantity_btn.ForeColor = System.Drawing.Color.White;
            this.saveSelledFlowerQuantity_btn.Location = new System.Drawing.Point(234, 178);
            this.saveSelledFlowerQuantity_btn.Margin = new System.Windows.Forms.Padding(4);
            this.saveSelledFlowerQuantity_btn.Name = "saveSelledFlowerQuantity_btn";
            this.saveSelledFlowerQuantity_btn.Size = new System.Drawing.Size(160, 55);
            this.saveSelledFlowerQuantity_btn.TabIndex = 5;
            this.saveSelledFlowerQuantity_btn.Text = "Mentés";
            this.saveSelledFlowerQuantity_btn.UseVisualStyleBackColor = false;
            this.saveSelledFlowerQuantity_btn.Click += new System.EventHandler(this.saveSelledFlowerQuantity_btn_Click);
            // 
            // flowerGenus_cb
            // 
            this.flowerGenus_cb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.flowerGenus_cb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.flowerGenus_cb.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.flowerGenus_cb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(160)))), ((int)(((byte)(31)))));
            this.flowerGenus_cb.FormattingEnabled = true;
            this.flowerGenus_cb.Location = new System.Drawing.Point(234, 79);
            this.flowerGenus_cb.Margin = new System.Windows.Forms.Padding(4);
            this.flowerGenus_cb.Name = "flowerGenus_cb";
            this.flowerGenus_cb.Size = new System.Drawing.Size(272, 27);
            this.flowerGenus_cb.TabIndex = 2;
            // 
            // AddSellsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(551, 246);
            this.Controls.Add(this.flowerGenus_cb);
            this.Controls.Add(this.saveSelledFlowerQuantity_btn);
            this.Controls.Add(this.flowerQuantity_tb);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddSellsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Eladások hozzáadása";
            this.Load += new System.EventHandler(this.AddSellsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox flowerQuantity_tb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button saveSelledFlowerQuantity_btn;
        private System.Windows.Forms.ComboBox flowerGenus_cb;
    }
}