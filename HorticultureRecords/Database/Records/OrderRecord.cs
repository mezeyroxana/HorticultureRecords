﻿using System;

namespace HorticultureRecords.Database.Records
{
    class OrderRecord : Record
    {
        private CustomerRecord customer;
        public CustomerRecord Customer
        {
            get { return customer; }
            set { customer = value; }
        }

        public int? CustomerId
        {
            get { return customer.Id; }
        }

        private FlowerRecord flower;
        public FlowerRecord Flower
        {
            get { return flower; }
            set { flower = value; }
        }

        public int? FlowerId
        {
            get { return flower.Id; }
        }

        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (value < 0)
                    throw new Exception("The ordered flower quantity cannot be negative value");
                quantity = value;
            }
        }

        private bool isDeliveryRequested;
        public bool IsDeliveryRequested
        {
            get { return isDeliveryRequested; }
            set { isDeliveryRequested = value; }
        }

        private bool isCompleted;
        public bool IsCompleted
        {
            get { return isCompleted; }
            set { isCompleted = value; }
        }

        public OrderRecord() : base() { }

        public OrderRecord(int? id) : base(id) { }

        public OrderRecord(int? id, bool isCompleted, bool isDeliveryRequested) : this(id)
        {
            this.isCompleted = isCompleted;
            this.isDeliveryRequested = isDeliveryRequested;
        }

        public OrderRecord(int? orderId, int? customerId, bool isCompleted, bool isDeliveryRequested) : this(orderId, isCompleted, isDeliveryRequested)
        {
            customer = new CustomerRecord(customerId);
        }

        public OrderRecord(int? id, int? flowerId) : this(id)
        {
            Flower = new FlowerRecord(flowerId);
        }

        public OrderRecord(int? id, int? flowerId, int quantity) : this(id, flowerId)
        {
            this.quantity = quantity;
        }

    }
}
