using HorticultureRecords.Database.Managers;
using HorticultureRecords.Database.Records;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace HorticultureRecords
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            flowersInStock_dgw.DefaultCellStyle.Font = new Font("Cambria", 11.75F); ;
            flowersInStock_dgw.ColumnHeadersDefaultCellStyle.Font = new Font("Cambria", 15.75F, FontStyle.Bold);
        }

        private void reload_btn_Click(object sender, EventArgs e)
        {
            FillFlowerDataGridView();
        }

        private void newOrder_btn_Click(object sender, EventArgs e)
        {
            NewOrderForm newOrderForm = new NewOrderForm();
            newOrderForm.Show();
        }

        private void orders_btn_Click(object sender, EventArgs e)
        {
            OrdersForm ordersForm = new OrdersForm();
            ordersForm.Show();
        }

        private void addNewSells_btn_Click(object sender, EventArgs e)
        {
            AddSellsForm addSellsForm = new AddSellsForm();
            addSellsForm.Show();
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            FillFlowerDataGridView();
        }

        private void FillFlowerDataGridView()
        {
            flowersInStock_dgw.Rows.Clear();
            flowersInStock_dgw.Refresh();
            List<Record> records = new List<Record>();
            try
            {
                records = new FlowerManager().Select();
            }
            catch (DatabaseException e)
            {
                MessageBox.Show(e.Message);
            }

            foreach (FlowerRecord actualRecord in records)
            {
                flowersInStock_dgw.Rows.Add(
                    new object[]
                    {
                        actualRecord.Id,
                        actualRecord.Name,
                        actualRecord.Genus,
                        actualRecord.Quantity,
                        actualRecord.AvailableQuantity
                    }
                );
            }
        }
    }
}
