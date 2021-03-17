using HorticultureRecords.Database.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorticultureRecords.Database.Interfaces
{
    interface IQueryLanguage
    {
        Record Select(Record record);

        List<Record> Select();
    }
}
