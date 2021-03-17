using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorticultureRecords.Database.Records
{
    class Record
    {
        private readonly int? id;
        public int? Id
        {
            get { return id; }
        }

        protected Record() { }

        protected Record(int? id)
        {
            if (id == null)
                throw new ArgumentNullException();
            this.id = id;
        }
    }
}
