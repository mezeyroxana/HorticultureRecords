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

            List<Record> selectedOrderedFlowers = new OrderManager().SelectFlowersForSpecificOrder(orderRecord);
            foreach (FlowerRecord orderedFlowers in selectedOrderedFlowers)
            {
                FlowerRecord flowerData = (FlowerRecord)(new FlowerManager().Select(new FlowerRecord(orderedFlowers.Id)));
                ordersFlowers_dgw.Rows.Add(
                    new object[]
                    {
                        orderRecord.Id,
                        orderedFlowers.Id,
                        flowerData.Name,
                        orderedFlowers.Quantity
                    }
                );
            }

            Record customer = new CustomerRecord(int.Parse(selectedRow.Cells["OrderingCustomerId"].Value.ToString()));
            CustomerRecord orderingCustomer = (CustomerRecord)new CustomerManager().Select(customer);
            if (orderingCustomer.Zipcode != "")
            {
                CityRecord cityRecord = new CityManager().SelectCityByZipcode(orderingCustomer.Zipcode);
                orderingCustomer.City = cityRecord;
            }
            FillCustomerRecords(orderingCustomer);
        }

        private void ordersFlowers_dgw_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.ColumnIndex == ordersFlowers_dgw.Columns["ModifyFlower"].Index &&
                e.RowIndex >= 0)
            {
                OrderRecord modifiedRecord = new OrderRecord(
                   int.Parse(senderGrid.Rows[e.RowIndex].Cells["FlowerOrderId"].Value.ToString()),
                   int.Parse(senderGrid.Rows[e.RowIndex].Cells["FlowerId"].Value.ToString()),
                   int.Parse(senderGrid.Rows[e.RowIndex].Cells["Quantity"].Value.ToString())
                );
                int modifiedRows = new OrderManager().UpdateFlowerOrder(modifiedRecord);
                if (modifiedRows > 0)
                    MessageBox.Show("Sikeres módosítás!");
                else MessageBox.Show("Sikertelen módosítás!");
                LoadOrdersForm();
            }

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.ColumnIndex == ordersFlowers_dgw.Columns["DeleteFlower"].Index &&
                e.RowIndex >= 0)
            {
                OrderRecord toBeDeleted = new OrderRecord(
                    int.Parse(senderGrid.Rows[e.RowIndex].Cells["FlowerOrderId"].Value.ToString()),
                    int.Parse(senderGrid.Rows[e.RowIndex].Cells["FlowerId"].Value.ToString())
                );
                int deletedRows = new OrderManager().DeleteFlowerOrder(toBeDeleted);
                if (deletedRows < 1)
                    MessageBox.Show("Sikeres törlés!");
                else MessageBox.Show("Sikertelen törlés");
                LoadOrdersForm();
            }
        }

        private void saveCustomerData_btn_Click(object sender, EventArgs e)
        {
            CustomerRecord customerData = new CustomerRecord(int.Parse(orders_dgw.CurrentRow.Cells["OrderingCustomerId"].Value.ToString()));
            customerData.Name = customerName_tb.Text;
            customerData.PhoneNumber = customerPhoneNumber_tb.Text;
            customerData.Email = customerEmail_tb.Text;
            customerData.City = new CityRecord(customerZipcode_tb.Text, customerCity_tb.Text);
            customerData.Address = customerAddress_tb.Text;
            int affectedRows = new CustomerManager().Update(customerData);
            if (affectedRows >= 1)
                MessageBox.Show("Sikeres módosítás!");
            else MessageBox.Show("Sikertelen módosítás!");
            LoadOrdersForm();
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
                    bool.Parse(senderGrid.Rows[e.RowIndex].Cells["IsDeliveryRequested"].Value.ToString())
                );
                //Needs work - modify Flowers table if isCompleted is changed
                int updatedRecords = new OrderManager().Update(modifiedOrderRecord);
                if (updatedRecords > 0)
                    MessageBox.Show("Sikeres módosítás!");
                else MessageBox.Show("Sikertelen módosítás");
                LoadOrdersForm();
            }

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.ColumnIndex == orders_dgw.Columns["DeleteOrder"].Index &&
                e.RowIndex >= 0)
            {
                OrderRecord toBeDeletedRecord =
                    new OrderRecord(int.Parse(senderGrid.Rows[e.RowIndex].Cells["OrderId"].Value.ToString()));
                int deletedRecords = new OrderManager().Delete(toBeDeletedRecord);
                if (deletedRecords > 0)
                    MessageBox.Show("Sikeres törlés!");
                else MessageBox.Show("Sikertelen törlés!");
                LoadOrdersForm();
            }
        }

        private void LoadOrdersForm()
        {
            orders_dgw.Rows.Clear();
            orders_dgw.Refresh();

            List<Record> orders = new OrderManager().SelectOrders();

            foreach (OrderRecord actualRecord in orders)
            {
                actualRecord.Customer = (CustomerRecord)(new CustomerManager().Select(new CustomerRecord(actualRecord.CustomerId)));
                orders_dgw.Rows.Add(
                    new object[]
                    {
                        actualRecord.Id,
                        actualRecord.CustomerId,
                        actualRecord.Customer.Name,
                        actualRecord.IsDeliveryRequested,
                        actualRecord.IsCompleted
                    }
                );
            }
        }

        private void ClearCustomerRecords()
        {
            customerName_tb.Text = "";
            customerPhoneNumber_tb.Text = "";
            customerEmail_tb.Text = "";
            customerZipcode_tb.Text = "";
            customerCity_tb.Text = "";
            customerAddress_tb.Text = "";
        }

        private void FillCustomerRecords(CustomerRecord customer)
        {
            customerName_tb.Text = customer.Name;
            customerPhoneNumber_tb.Text = customer.PhoneNumber;
            customerEmail_tb.Text = customer.Email;
            customerZipcode_tb.Text = customer.Zipcode;
            customerCity_tb.Text = customer.CityName;
            customerAddress_tb.Text = customer.Address;
        }
    }
}
