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
            List<Record> availableFlowers = new List<Record>();
            try
            {
                availableFlowers = new FlowerManager().SelectFlowersInStock();
            }
            catch (DatabaseException)
            {
                MessageBox.Show("Nem sikerült betölteni a viráglistát!");
            }

            flowerGenus_cb.DisplayMember = "Name";
            flowerGenus_cb.ValueMember = "Id";
            foreach (var flower in availableFlowers)
            {
                flowerGenus_cb.Items.Add(flower);
            }
        }

        private void saveSelledFlowerQuantity_btn_Click(object sender, EventArgs e)
        {
            if (flowerGenus_cb.SelectedItem == null)
                MessageBox.Show("Válassz ki virágfajtát!");
            else if (flowerQuantity_tb.Text == "")
                MessageBox.Show("Töltsd ki a mennyiség értéket!");
            else if (!int.TryParse(flowerQuantity_tb.Text, out int selledQuantity))
                MessageBox.Show("Csak számokat írj be mennyiség mezőbe!");
            else if (selledQuantity < 1)
                MessageBox.Show("0-nál nagyobb értéket írj be mennyiségnek!");
            else
            {
                FlowerRecord selectedFlower = (FlowerRecord)flowerGenus_cb.SelectedItem;
                int maxOrderableFlowerQuantity = 0;
                try
                {
                    maxOrderableFlowerQuantity = new FlowerManager().SelectAvailableFlowers(selectedFlower);
                }
                catch (DatabaseException)
                {
                    MessageBox.Show("Nem sikerült ellenőrizni az eladható virágmennyiséget!");
                }

                if (maxOrderableFlowerQuantity < selledQuantity)
                {
                    MessageBox.Show("Nem vehető fel eladásra ez a mennyiség. Maximum eladhatott: " + maxOrderableFlowerQuantity);
                    flowerQuantity_tb.Text = "";
                }
                else
                {
                    try
                    {
                        Record flowerRecord = new FlowerManager().Select(selectedFlower);
                        int flowerQuantity = (flowerRecord as FlowerRecord).Quantity;
                        (flowerRecord as FlowerRecord).Quantity = flowerQuantity - selledQuantity;
                        int affectedRows = new FlowerManager().Update(flowerRecord);

                        if (affectedRows > 0)
                            MessageBox.Show("Sikeres módosítás!");
                        else MessageBox.Show("Sikertelen módosítás!");
                    }
                    catch (DatabaseException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
    }
}
