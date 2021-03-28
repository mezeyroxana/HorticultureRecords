using HorticultureRecords.Database.Managers;
using HorticultureRecords.Database.Records;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Windows.Forms;

namespace HorticultureRecords
{
    public partial class NewOrderForm : Form
    {
        public NewOrderForm()
        {
            InitializeComponent();
        }

        private void NewOrderForm_Load(object sender, EventArgs e)
        {
            orderedFlowers_dgv.DefaultCellStyle.Font = new Font("Cambria", 9.75F); ;
            orderedFlowers_dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Cambria", 13.75F, FontStyle.Bold);
            List<Record> availableFlowers = new FlowerManager().SelectOnlyAvailableFlowers();
            flowerGenus_cb.DisplayMember = "Name";
            flowerGenus_cb.ValueMember = "Id";
            foreach (var flower in availableFlowers)
            {
                flowerGenus_cb.Items.Add(flower);
            }
        }

        private void flowerQuantity_tb_Leave(object sender, EventArgs e)
        {
            if (!int.TryParse(flowerQuantity_tb.Text, out int quantity))
                MessageBox.Show("Csak számokat írj be mennyiség mezőbe!");
            else if (flowerGenus_cb.SelectedItem == null)
                MessageBox.Show("Válassz ki virágfajtát!");
            else
            {
                FlowerRecord selectedFlower = (FlowerRecord)flowerGenus_cb.SelectedItem;
                int maxOrderableFlowerQuantity = new FlowerManager().SelectMarketableFlowerQuantity(selectedFlower);
                if (maxOrderableFlowerQuantity < quantity)
                {
                    MessageBox.Show("Nem érhető el ez a virágmennyiség! Elérhető: " + maxOrderableFlowerQuantity);
                    flowerQuantity_tb.Text = "";
                }
            }
        }

        private void nextFlowerOrder_btn_Click(object sender, EventArgs e)
        {
            int orderedQuantity;
            if (
                flowerGenus_cb.SelectedItem != null &&
                flowerQuantity_tb.Text != "" &&
                int.TryParse(flowerQuantity_tb.Text, out orderedQuantity) &&
                orderedQuantity != 0
            )
            {
                FlowerRecord orderedFlower = (FlowerRecord)flowerGenus_cb.SelectedItem;
                orderedFlowers_dgv.Rows.Add(
                    new object[]
                    {
                    orderedFlower.Id,
                    orderedFlower.Name,
                    orderedQuantity
                    }
                );
                flowerGenus_cb.SelectedItem = null;
                flowerQuantity_tb.Text = "";
            }
        }

        private void saveOrder_btn_Click(object sender, EventArgs e)
        {
            ListDictionary orderedFlowers = new ListDictionary();
            int orderedQuantity;
            if (
                flowerGenus_cb.SelectedItem != null &&
                flowerQuantity_tb.Text != "" &&
                int.TryParse(flowerQuantity_tb.Text, out orderedQuantity) &&
                orderedQuantity != 0
            )
                orderedFlowers.Add((FlowerRecord)flowerGenus_cb.SelectedItem, int.Parse(flowerQuantity_tb.Text));

            foreach (DataGridViewRow row in orderedFlowers_dgv.Rows)
            {
                orderedFlowers.Add(
                    new FlowerRecord(
                        int.Parse(row.Cells["FlowerId"].Value.ToString()),
                        row.Cells["FlowerGenus"].Value.ToString()),
                    int.Parse(row.Cells["FlowerQuantity"].Value.ToString()));
            }

            CustomerRecord orderingCustomer = new CustomerRecord();
            orderingCustomer.Name = customerName_tb.Text;
            orderingCustomer.PhoneNumber = customerPhoneNumber_tb.Text;
            orderingCustomer.Email = customerEmail_tb.Text;
            orderingCustomer.City = customerCity_tb.Text;
            orderingCustomer.Address = customerAddress_tb.Text;

            OrderRecord orderRecord = new OrderRecord();
            orderRecord.Customer = orderingCustomer;
            orderRecord.IsDeliveryRequested = isDelivery_chkb.Checked ? true : false;

            OrderManager orderManager = new OrderManager();
            int affectedRows = 0;
            foreach (DictionaryEntry flowersAndQuantities in orderedFlowers)
            {
                orderRecord.Flower = (FlowerRecord)flowersAndQuantities.Key;
                orderRecord.Quantity = (int)flowersAndQuantities.Value;
                affectedRows += orderManager.Insert(orderRecord);
            }
            if (affectedRows > 0)
                ClearDataFields();
        }

        private void ClearDataFields()
        {
            customerName_tb.Text = "";
            customerPhoneNumber_tb.Text = "";
            customerEmail_tb.Text = "";
            isDelivery_chkb.Checked = false;
            customerCity_tb.Text = "";
            customerAddress_tb.Text = "";
            flowerGenus_cb.SelectedIndex = -1;
            flowerQuantity_tb.Text = "";
            orderedFlowers_dgv.Rows.Clear();
        }
    }
}
