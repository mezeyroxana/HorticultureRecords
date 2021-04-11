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

            try
            {
                List<Record> availableFlowers = new FlowerManager().SelectAvailableFlowers();
                flowerGenus_cb.DisplayMember = "Name";
                flowerGenus_cb.ValueMember = "Id";
                foreach (var flower in availableFlowers)
                {
                    flowerGenus_cb.Items.Add(flower);
                }
            }
            catch (DatabaseException)
            {
                MessageBox.Show("Nem tudta betölteni a viráglistát!");
            }
        }

        private void nextFlowerOrder_btn_Click(object sender, EventArgs e)
        {
            if (CheckFlowerOrder())
            {
                orderedFlowers_dgv.Rows.Add(
                    new object[]
                    {
                    ((FlowerRecord)flowerGenus_cb.SelectedItem).Id,
                    ((FlowerRecord)flowerGenus_cb.SelectedItem).Name,
                    int.Parse(flowerQuantity_tb.Text)
                    }
                );
                flowerGenus_cb.SelectedItem = null;
                flowerQuantity_tb.Text = "";
                flowerGenus_cb.Focus();
            }
        }

        private void saveOrder_btn_Click(object sender, EventArgs e)
        {
            if (customerName_tb.Text == "")
                MessageBox.Show("Írd be a megrendelő nevét!");
            else if (flowerGenus_cb.SelectedItem == null && flowerQuantity_tb.Text == "")
                SaveFlowerOrder(true);
            else if (CheckFlowerOrder())
                SaveFlowerOrder(false);
        }

        private void ClearDataFields()
        {
            customerName_tb.Text = "";
            customerPhoneNumber_tb.Text = "";
            customerEmail_tb.Text = "";
            isDelivery_chkb.Checked = false;
            customerCity_tb.Text = "";
            customerAddress_tb.Text = "";
            comment_tb.Text = "";
            flowerGenus_cb.SelectedIndex = -1;
            flowerQuantity_tb.Text = "";
            orderedFlowers_dgv.Rows.Clear();
        }

        private bool CheckFlowerOrder()
        {
            bool isOrderCorrect = false;
            if (flowerGenus_cb.SelectedItem == null)
                MessageBox.Show("Válassz ki virágfajtát!");
            else if (flowerQuantity_tb.Text == "")
                MessageBox.Show("Töltsd ki a mennyiséget!");
            else if (!int.TryParse(flowerQuantity_tb.Text, out int orderedQuantity))
                MessageBox.Show("Csak számokat írj be mennyiség mezőbe!");
            else if (orderedQuantity <= 0)
                MessageBox.Show("Nullánál nagyobb értéket írj be mennyiségnek!");
            else
            {
                try
                {
                    FlowerRecord selectedFlower = (FlowerRecord)flowerGenus_cb.SelectedItem;
                    int maxOrderableFlowerQuantity = new FlowerManager().SelectAvailableFlowers(selectedFlower);
                    if (maxOrderableFlowerQuantity < orderedQuantity)
                    {
                        MessageBox.Show("Nem érhető el ez a virágmennyiség! Elérhető: " + maxOrderableFlowerQuantity);
                        flowerQuantity_tb.Text = "";
                    }
                    else isOrderCorrect = true;
                }
                catch (DatabaseException)
                {
                    MessageBox.Show("Nem tudta leellenőrizni, hogy lehetséges e ennyi virág rendelése!");
                    isOrderCorrect = true;
                }

            }
            return isOrderCorrect;
        }

        private void SaveFlowerOrder(bool onlyFromGrid)
        {
            ListDictionary orderedFlowers = new ListDictionary();

            if (!onlyFromGrid)
                orderedFlowers.Add((FlowerRecord)flowerGenus_cb.SelectedItem, int.Parse(flowerQuantity_tb.Text));

            foreach (DataGridViewRow row in orderedFlowers_dgv.Rows)
            {
                orderedFlowers.Add(
                    new FlowerRecord(
                        int.Parse(row.Cells["FlowerId"].Value.ToString()),
                        row.Cells["FlowerGenus"].Value.ToString()),
                    int.Parse(row.Cells["FlowerQuantity"].Value.ToString()));
            }

            if (orderedFlowers.Count == 0)
                MessageBox.Show("Adj hozzá megrendeléseket!");
            else
            {
                CustomerRecord orderingCustomer = new CustomerRecord();
                orderingCustomer.Name = customerName_tb.Text;
                orderingCustomer.PhoneNumber = customerPhoneNumber_tb.Text;
                orderingCustomer.Email = customerEmail_tb.Text;
                orderingCustomer.City = customerCity_tb.Text;
                orderingCustomer.Address = customerAddress_tb.Text;

                OrderRecord orderRecord = new OrderRecord();
                orderRecord.Customer = orderingCustomer;
                orderRecord.IsDeliveryRequested = isDelivery_chkb.Checked ? true : false;
                orderRecord.Comment = comment_tb.Text;

                try
                {
                    OrderManager orderManager = new OrderManager();
                    int affectedRows = 0;
                    foreach (DictionaryEntry flowersAndQuantities in orderedFlowers)
                    {
                        orderRecord.Flower = (FlowerRecord)flowersAndQuantities.Key;
                        orderRecord.Quantity = (int)flowersAndQuantities.Value;
                        affectedRows += orderManager.Insert(orderRecord);
                    }
                    if (affectedRows >= orderedFlowers.Count)
                    {
                        ClearDataFields();
                        customerName_tb.Focus();
                    }
                    else MessageBox.Show("Nem sikerült a rendelés rögzítése!");
                }
                catch (DatabaseException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
