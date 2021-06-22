using OffenseLibrary.Factory;
using System;
using System.Collections.Generic;
using System.Data;

namespace OffenseLibrary
{
    public class OffenseResearch
    {
        ObjectFactory m_Factory = new ObjectFactory();
        CRUDOperations m_CRUDOperations = new CRUDOperations(); 

        /// <summary>
        /// Constructs the database by retrieving CSV data from the path provided
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public int ConstructDatabase(string path)
        {
            try
            {
                var table = m_Factory.RetrieveDatatable(path);
                foreach (DataRow dataRow in table.Rows)
                {
                    var offense = m_Factory.GenerateOffense(dataRow);
                    m_CRUDOperations.SaveOffense(offense); 
                }
                return 0;
            }
            catch (Exception)
            {
                return 1;
                throw; 
            }
        }

        /// <summary>
        /// Purges the content of the database 
        /// </summary>
        /// <returns></returns>
        public int PurgeDatabase()
        {
            try
            {
                m_CRUDOperations.PurgeDatabase();
                return 0; 
            }
            catch (Exception)
            {
                return 1; 
            }
        }

        /// <summary>
        /// Deletes a particular <see cref="Offense"/> from the database 
        /// </summary>
        /// <param name="offense"></param>
        /// <returns></returns>
        public int DeleteOffense(IOffense offense)
        {
            try
            {
                m_CRUDOperations.DeleteOffense((Offense)offense);
                return 0; 
            }
            catch (Exception)
            {
                return 1; 
            }
        }

        /// <summary>
        /// Retrieves a single <see cref="IOffense"/> from the database by searching for the offense code
        /// </summary>
        /// <param name="offenseCode"></param>
        /// <returns></returns>
        public IOffense GetOffenseByOffenseCode(int offenseCode)
        {
            return m_CRUDOperations.RetrieveOffenseByCode(offenseCode);
        }

        /// <summary>
        /// Retrieves a <see cref="List{IOffense}<"/> by searching for statutory references or partial statutory references
        /// </summary>
        /// <param name="statute"></param>
        /// <returns></returns>
        public List<IOffense> GetOffensesByStatutoryReference(string statute)
        {
            return new List<IOffense>(m_CRUDOperations.RetrieveOffensesByStatute(statute)); 
        }

        /// <summary>
        /// Retrieves a <see cref="List{IOffense}"/> by searching for matching descriptions or partial descriptions
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        public List<IOffense> GetOffensesByDescription(string description)
        {
            return new List<IOffense>(m_CRUDOperations.RetrieveOffensesByDescription(description));
        }

        /// <summary>
        /// Retrieves a <see cref="List{IOffense}"/> for all offenses listed in the database 
        /// </summary>
        /// <returns></returns>
        public List<IOffense> GetAllOffenses()
        {
            return new List<IOffense>(m_CRUDOperations.GetAllOffenses());
        }
    }
}
