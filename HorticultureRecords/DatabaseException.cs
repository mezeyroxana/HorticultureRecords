using System;

namespace HorticultureRecords
{
    class DatabaseException : Exception
    {
        public DatabaseException() : base() { }

        public DatabaseException(string message) : base(message) { }
    }
}
