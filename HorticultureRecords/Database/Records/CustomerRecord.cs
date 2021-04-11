namespace HorticultureRecords.Database.Records
{
    class CustomerRecord : Record
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string phoneNumber;
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string city;
        public string City
        {
            get { return city; }
            set { city = value; }
        }

        private string address;
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public CustomerRecord() : base() { }

        public CustomerRecord(int? id) : base(id) { }

        public CustomerRecord(int? id, string name) : this(id)
        {
            this.name = name;
        }

        public CustomerRecord(int? id, string name, string phoneNumber, string email, string city, string address) : this(id, name)
        {
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.city = city;
            this.address = address;
        }
    }
}
