using HorticultureRecords.Database.Managers;
using HorticultureRecords.Database.Records;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HorticultureRecords
{
    public partial class OrdersForm : Form
    {
        public OrdersForm()
        {
            InitializeComponent();
        }

        private void OrdersForm_Load(object sender, EventArgs e)
        {
            LoadOrdersForm();
        }

        private void orders_dgw_SelectionChanged(object sender, EventArgs e)
        {
            ordersFlowers_dgw.Rows.Clear();
            ordersFlowers_dgw.Refresh();
            ClearCustomerRecords();

            DataGridViewRow selectedRow = orders_dgw.CurrentRow;
            OrderRecord orderRecord = new OrderRecord(int.Parse(selectedRow.Cells["OrderId"].Value.ToString()));

            try
            {
                bool isCompleted = bool.Parse(orders_dgw.CurrentRow.Cells["IsCompleted"].Value.ToString());
                ordersFlowers_dgw.AllowUserToAddRows = !isCompleted;
                ordersFlowers_dgw.ReadOnly = isCompleted;

                ordersFlowers_dgw.Refresh();

                List<Record> selectedOrderedFlowers = new OrderedFlowerManager().Select(orderRecord);
                foreach (FlowerRecord orderedFlowers in selectedOrderedFlowers)
                {
                    FlowerRecord flowerData = (FlowerRecord)(new FlowerManager().Select(new FlowerRecord(orderedFlowers.Id)));
                    ordersFlowers_dgw.Rows.Add(
                        new object[]
                        {
                        orderedFlowers.Id,
                        flowerData.Name,
                        orderedFlowers.Quantity
                        }
                    );
                }


                Record customer = new CustomerRecord(int.Parse(selectedRow.Cells["OrderingCustomerId"].Value.ToString()));
                CustomerRecord orderingCustomer = (CustomerRecord)new CustomerManager().Select(customer);
                FillCustomerRecords(orderingCustomer);
            }
            catch (DatabaseException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void orders_dgw_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.ColumnIndex == orders_dgw.Columns["ModifyOrder"].Index &&
                e.RowIndex >= 0)
            {
                OrderRecord modifiedOrderRecord = new OrderRecord(
                    int.Parse(senderGrid.Rows[e.RowIndex].Cells["OrderId"].Value.ToString()),
                    bool.Parse(senderGrid.Rows[e.RowIndex].Cells["IsCompleted"].Value.ToString()),
                    bool.Parse(senderGrid.Rows[e.RowIndex].Cells["IsDeliveryRequested"].Value.ToString()),
                    senderGrid.Rows[e.RowIndex].Cells["CommentColumn"].Value.ToString()
                );

                try
                {
                    int updatedRecords = new OrderManager().Update(modifiedOrderRecord);
                    if (updatedRecords > 0)
                        MessageBox.Show("Sikeres módosítás!");
                    else MessageBox.Show("Sikertelen módosítás");
                }
                catch (DatabaseException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                LoadOrdersForm(orders_dgw.CurrentRow.Index);
            }

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.ColumnIndex == orders_dgw.Columns["DeleteOrder"].Index &&
                e.RowIndex >= 0)
            {
                OrderRecord toBeDeletedRecord =
                    new OrderRecord(int.Parse(senderGrid.Rows[e.RowIndex].Cells["OrderId"].Value.ToString()));
                try
                {
                    int deletedRecords = new OrderManager().Delete(toBeDeletedRecord);
                    if (deletedRecords > 0)
                        MessageBox.Show("Sikeres törlés!");
                    else MessageBox.Show("Sikertelen törlés!");
                }
                catch (DatabaseException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                LoadOrdersForm();
            }
        }

        private void ordersFlowers_dgw_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.ColumnIndex == ordersFlowers_dgw.Columns["ModifyFlower"].Index &&
                e.RowIndex >= 0 &&
                orders_dgw.RowCount > 0 &&
                ordersFlowers_dgw.RowCount > 0 &&
                orders_dgw.SelectedRows[0].Cells["IsCompleted"].Value != null &&
                bool.Parse(orders_dgw.SelectedRows[0].Cells["IsCompleted"].Value.ToString()) == false &&
                orders_dgw.SelectedRows[0].Cells["OrderId"].Value != null &&
                senderGrid.Rows[e.RowIndex].Cells["FlowerId"].Value != null &&
                senderGrid.Rows[e.RowIndex].Cells["Quantity"].Value != null)
            {
                OrderRecord modifiedRecord = new OrderRecord(
                    int.Parse(orders_dgw.SelectedRows[0].Cells["OrderId"].Value.ToString()),
                    int.Parse(senderGrid.Rows[e.RowIndex].Cells["FlowerId"].Value.ToString()),
                    int.Parse(senderGrid.Rows[e.RowIndex].Cells["Quantity"].Value.ToString())
                );

                if (modifiedRecord.FlowerId != null)
                {
                    try
                    {
                        int modifiedRows = new OrderedFlowerManager().Save(modifiedRecord);
                        if (modifiedRows > 0)
                            MessageBox.Show("Sikeres módosítás!");
                        else MessageBox.Show("A módosítás sikertelen volt!\nLehetséges ok: nincs ennyi elérhető virág!");
                    }
                    catch (DatabaseException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                    MessageBox.Show("A felajánlott lehetőségekből válassz virág fajtát!");
                LoadOrdersForm(orders_dgw.CurrentRow.Index);
            }

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.ColumnIndex == ordersFlowers_dgw.Columns["DeleteFlower"].Index &&
                e.RowIndex >= 0 &&
                orders_dgw.RowCount > 0 &&
                ordersFlowers_dgw.RowCount > 0 &&
                orders_dgw.SelectedRows[0].Cells["IsCompleted"].Value != null &&
                bool.Parse(orders_dgw.SelectedRows[0].Cells["IsCompleted"].Value.ToString()) == false &&
                orders_dgw.SelectedRows[0].Cells["OrderId"].Value != null &&
                senderGrid.Rows[e.RowIndex].Cells["FlowerId"].Value != null)
            {
                OrderRecord toBeDeleted = new OrderRecord(
                    int.Parse(orders_dgw.SelectedRows[0].Cells["OrderId"].Value.ToString()),
                    int.Parse(senderGrid.Rows[e.RowIndex].Cells["FlowerId"].Value.ToString())
                );
                try
                {
                    int deletedRows = new OrderedFlowerManager().Delete(toBeDeleted);
                    if (deletedRows > 0)
                        MessageBox.Show("Sikeres törlés!");
                    else MessageBox.Show("Sikertelen törlés");
                }
                catch (DatabaseException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                LoadOrdersForm(orders_dgw.CurrentRow.Index);
            }
        }

        private void saveCustomerData_btn_Click(object sender, EventArgs e)
        {
            if (orders_dgw.RowCount > 0)
            {
                CustomerRecord customerData = new CustomerRecord(int.Parse(orders_dgw.CurrentRow.Cells["OrderingCustomerId"].Value.ToString()));
                customerData.Name = customerName_tb.Text;
                customerData.PhoneNumber = customerPhoneNumber_tb.Text;
                customerData.Email = customerEmail_tb.Text;
                customerData.City = customerCity_tb.Text;
                customerData.Address = customerAddress_tb.Text;
                try
                {
                    int affectedRows = new CustomerManager().Update(customerData);
                    if (affectedRows > 0)
                        MessageBox.Show("Sikeres módosítás!");
                    else MessageBox.Show("Sikertelen módosítás!");
                }
                catch (DatabaseException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                LoadOrdersForm(orders_dgw.CurrentRow.Index);
            }
        }

        private void ordersFlowers_dgw_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tbControl = e.Control as TextBox;
            if (ordersFlowers_dgw.CurrentCell.ColumnIndex == 1)
            {
                if (tbControl != null)
                {
                    tbControl.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    tbControl.AutoCompleteCustomSource = AutoCompleteLoad();
                    tbControl.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            }
            else
            {
                if (tbControl != null)
                    tbControl.AutoCompleteMode = AutoCompleteMode.None;
            }
        }

        private void ordersFlowers_dgw_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //If edited cell was FlowerName Column AND FlowerId Column is null
            if (e.ColumnIndex == 1 &&
                ordersFlowers_dgw.Rows[e.RowIndex].Cells["FlowerId"].Value == null &&
                ordersFlowers_dgw.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                FlowerRecord flowerRecord = new FlowerRecord();
                flowerRecord.Name = ordersFlowers_dgw.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                try
                {

                    int flowerId = new FlowerManager().SelectFlowerIdByFlowerName(flowerRecord);
                    if (flowerId != -1)
                        ordersFlowers_dgw.Rows[e.RowIndex].Cells["FlowerId"].Value = flowerId;
                    else MessageBox.Show("A listából válassz virágfajtát!");
                }
                catch (DatabaseException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void LoadOrdersForm(int selectedRow = 0)
        {
            ClearCustomerRecords();
            orders_dgw.Rows.Clear();
            orders_dgw.Refresh();

            try
            {
                List<Record> orders = new OrderManager().Select();

                foreach (OrderRecord actualRecord in orders)
                {
                    orders_dgw.Rows.Add(
                        new object[]
                        {
                        actualRecord.Id,
                        actualRecord.CustomerId,
                        actualRecord.Customer.Name,
                        actualRecord.IsDeliveryRequested,
                        actualRecord.IsCompleted,
                        actualRecord.Comment
                        }
                    );
                }
                if (orders_dgw.Rows.Count != 0)
                {
                    orders_dgw.CurrentCell = orders_dgw.Rows[selectedRow].Cells[2];
                    orders_dgw.Rows[selectedRow].Selected = true;
                    orders_dgw_SelectionChanged(orders_dgw, null);
                }
            }
            catch (DatabaseException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearCustomerRecords()
        {
            customerName_tb.Text = "";
            customerPhoneNumber_tb.Text = "";
            customerEmail_tb.Text = "";
            customerCity_tb.Text = "";
            customerAddress_tb.Text = "";
        }

        private void FillCustomerRecords(CustomerRecord customer)
        {
            customerName_tb.Text = customer.Name;
            customerPhoneNumber_tb.Text = customer.PhoneNumber;
            customerEmail_tb.Text = customer.Email;
            customerCity_tb.Text = customer.City;
            customerAddress_tb.Text = customer.Address;
        }

        private AutoCompleteStringCollection AutoCompleteLoad()
        {
            List<Record> availableFlowers = new List<Record>();
            try
            {
                availableFlowers = new FlowerManager().SelectAvailableFlowers();
            }
            catch (DatabaseException)
            {
                MessageBox.Show("Nem tudta betölteni a viráglistát!");
            }
            AutoCompleteStringCollection flowerNameCollection = new AutoCompleteStringCollection();
            foreach (FlowerRecord item in availableFlowers)
            {
                flowerNameCollection.Add(item.Name);
            }
            return flowerNameCollection;
        }
    }
}
