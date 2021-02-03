using System;
using SQLite;

namespace SpectrumTest.Database.Repository
{
    public abstract class BaseDatabaseItem : IDatabaseItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
