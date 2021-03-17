using System;

namespace HorticultureRecords.Database.Records
{
    class FlowerRecord : Record
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set
            {
                checkQuantity(value);
                quantity = value;
            }
        }

        private string genus;
        public string Genus
        {
            get { return genus; }
            set { genus = value; }
        }

        public FlowerRecord() : base() { }

        public FlowerRecord(int? id) : base(id) { }

        public FlowerRecord(int? id, string name) : this(id)
        {
            this.name = name;
        }

        public FlowerRecord(int? id,int quantity): this(id)
        {
            checkQuantity(quantity);
            this.quantity = quantity;
        }

        public FlowerRecord(int? id, string name, int quantity, string genus) : this(id, name)
        {
            checkQuantity(quantity);
            this.quantity = quantity;
            this.genus = genus;
        }

        private static void checkQuantity(int quantity)
        {
            if (quantity < 0)
                throw new Exception("Flower quantity cannot be negative value");
        }

    }
}
