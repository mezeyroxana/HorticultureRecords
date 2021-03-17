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

        public string Zipcode
        {
            get { return city.Zipcode; }
        }

        public string CityName
        {
            get { return city.Name; }
        }

        private CityRecord city;
        public CityRecord City
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

        public CustomerRecord(int? id, string name, string phoneNumber, string email, string cityZipcode, string address) : this(id)
        {
            this.name = name;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.city = new CityRecord(cityZipcode);
            this.address = address;
        }
    }
}
