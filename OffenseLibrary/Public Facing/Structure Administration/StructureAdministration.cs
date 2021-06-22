using Microsoft.EntityFrameworkCore;
using OffenseLibrary.Context;

namespace OffenseLibrary
{
    public static class StructureAdministration
    {
        /// <summary>
        /// Builds and migrates the database 
        /// </summary>
        public static void ConfirmOffenseDatabase()
        {
            DataContext context = new DataContext();
            // Create and migrate the database. If Created, ensures that migrations occur
            context.Database.Migrate(); 
        }
    }
}
