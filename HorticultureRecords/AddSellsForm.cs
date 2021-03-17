using HorticultureRecords.Database.Managers;
using HorticultureRecords.Database.Records;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HorticultureRecords
{
    public partial class AddSellsForm : Form
    {
        public AddSellsForm()
        {
            InitializeComponent();
        }

        private void AddSellsForm_Load(object sender, EventArgs e)
        {
            List<Record> availableFlowers = new FlowerManager().SelectOnlyAvailableFlowers();
            flowerGenus_cb.DisplayMember = "Name";
            flowerGenus_cb.ValueMember = "Id";
            foreach (var flower in availableFlowers)
            {
                flowerGenus_cb.Items.Add(flower);
            }
        }

        private void flowerQuantity_tb_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(flowerQuantity_tb.Text, out int quantity))
                MessageBox.Show("Csak számokat írj be mennyiség mezőbe!");
        }

        private void saveSelledFlowerQuantity_btn_Click(object sender, EventArgs e)
        {

        }

        private void flowerQuantity_tb_Leave(object sender, EventArgs e)
        {
            if (!int.TryParse(flowerQuantity_tb.Text, out int selledQuantity))
                MessageBox.Show("Csak számokat írj be mennyiség mezőbe!");
            else if (flowerGenus_cb.SelectedItem == null)
                MessageBox.Show("Válassz ki virágfajtát!");
            else
            {
                FlowerRecord selectedFlower = (FlowerRecord)flowerGenus_cb.SelectedItem;
                int maxOrderableFlowerQuantity = new FlowerManager().SelectMarketableFlowerQuantity(selectedFlower);
                if (maxOrderableFlowerQuantity < selledQuantity)
                {
                    MessageBox.Show("Nem vehető fel eladásra ez a mennyiség. Maximum eladhatott: " + maxOrderableFlowerQuantity);
                    flowerQuantity_tb.Text = "";
                }
                else
                {
                    Record flowerRecord = new FlowerManager().Select(selectedFlower);
                    int flowerQuantity = (flowerRecord as FlowerRecord).Quantity;
                    (flowerRecord as FlowerRecord).Quantity = flowerQuantity - selledQuantity;
                    int affectedRows = new FlowerManager().Update(flowerRecord);
                }


            }
        }
    }
}
