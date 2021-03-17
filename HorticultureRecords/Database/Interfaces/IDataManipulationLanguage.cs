using HorticultureRecords.Database.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorticultureRecords.Database.Interfaces
{
    interface IDataManipulationLanguage
    {
        int Insert(Record record);

        int Update(Record record);

        int Delete(Record record);

    }
}
