using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorticultureRecords.Database.Records
{
    class CityRecord
    {
        private string zipcode;
        public string Zipcode
        {
            get { return zipcode; }
            set { zipcode = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public CityRecord(string zipcode)
        {
            this.zipcode = zipcode;
        }

        public CityRecord(string zipcode, string city) : this(zipcode)
        {
            this.name = city;
        }

        public CityRecord()
        {

        }
    }
}
