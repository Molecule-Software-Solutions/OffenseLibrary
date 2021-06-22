using Microsoft.EntityFrameworkCore.Storage;
using OffenseLibrary.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OffenseLibrary
{
    internal class CRUDOperations
    {
        /// <summary>
        /// Saves a particular offense to the database 
        /// </summary>
        /// <param name="offense"></param>
        /// <returns></returns>
        public int SaveOffense(Offense offense)
        {
            using DataContext context = new DataContext();
            using IDbContextTransaction transaction = context.Database.BeginTransaction();
            try
            {
                context.Add(offense);
                context.SaveChanges();
                transaction.Commit();
                return 0;
            }
            catch (Exception)
            {
                transaction.Rollback();
                return 1;
            }
        }

        /// <summary>
        /// Deletes an offense from the database 
        /// </summary>
        /// <param name="offense"></param>
        /// <returns></returns>
        public int DeleteOffense(Offense offense)
        {
            using DataContext context = new DataContext();
            using IDbContextTransaction transaction = context.Database.BeginTransaction();
            try
            {
                context.Remove(offense);
                context.SaveChanges();
                transaction.Commit();
                return 0;
            }
            catch (Exception)
            {
                transaction.Rollback();
                return 1;
            }
        }

        /// <summary>
        /// Updates an offense in the database 
        /// </summary>
        /// <param name="offense"></param>
        /// <returns></returns>
        public int UpdateOffense(Offense offense)
        {
            using DataContext context = new DataContext();
            using IDbContextTransaction transaction = context.Database.BeginTransaction();
            try
            {
                context.Update(offense);
                context.SaveChanges();
                transaction.Commit();
                return 0;
            }
            catch (Exception)
            {
                transaction.Rollback();
                return 1;
            }
        }

        /// <summary>
        /// Purges the offenses from the database 
        /// </summary>
        /// <returns></returns>
        public int PurgeDatabase()
        {
            using DataContext context = new DataContext();
            using IDbContextTransaction transaction = context.Database.BeginTransaction();
            try
            {
                context.Offenses.RemoveRange(context.Offenses);
                context.SaveChanges();
                transaction.Commit();
                return 0; 
            }
            catch (Exception)
            {
                return 1; 
            }
        }

        /// <summary>
        /// Retrieve all <see cref="Offense"/> from the database 
        /// </summary>
        /// <returns></returns>
        public List<Offense> GetAllOffenses()
        {
            using DataContext context = new DataContext();
            return context.Offenses.ToList(); 
        }

        /// <summary>
        /// Retrieve a single <see cref="Offense"/> by searching for the offense code
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Offense RetrieveOffenseByCode(int code)
        {
            using DataContext context = new DataContext();
            return context.Offenses.Where(o => o.Code == code).FirstOrDefault(); 
        }

        /// <summary>
        /// Retrieves a <see cref="List{Offense}<"/> by searching for matching statutory references 
        /// </summary>
        /// <param name="statute"></param>
        /// <returns></returns>
        public List<Offense> RetrieveOffensesByStatute(string statute)
        {
            using DataContext context = new DataContext();
            return context.Offenses.Where(o => o.Statute.Contains(statute)).ToList(); 
        }

        /// <summary>
        /// Retrieves a <see cref="List{Offense}"/> by searching for matching descriptions
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        public List<Offense> RetrieveOffensesByDescription(string description)
        {
            using DataContext context = new DataContext();
            return context.Offenses.Where(o => o.OffenseDescription.Contains(description)).ToList(); 
        }
    }
}
