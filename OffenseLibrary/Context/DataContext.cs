using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace OffenseLibrary.Context
{
    internal class DataContext : DbContext
    {
        // Data
        public DbSet<Offense> Offenses { get; set; }

        // Context
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqliteConnectionStringBuilder cstringBuilder = new SqliteConnectionStringBuilder();
            cstringBuilder.DataSource = "OffenseData.db";
            cstringBuilder.Mode = SqliteOpenMode.ReadWriteCreate;
            cstringBuilder.ForeignKeys = true; 
            optionsBuilder.UseSqlite(cstringBuilder.ConnectionString); 
        }
    }
}
