using CSVHandler;
using System;
using System.Data;

namespace OffenseLibrary.Factory
{
    internal class ObjectFactory
    {
        /// <summary>
        /// Retrieves a <see cref="DataTable"/> using the <see cref="CSVEngine"/>
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public DataTable RetrieveDatatable(string path)
        {
            return new Output(path).RetrieveDatatable();
        }

        /// <summary>
        /// Generates an <see cref="Offense"/> by parsing a valid <see cref="DataRow"/>
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public Offense GenerateOffense(DataRow dr)
        {
            char typeCode = string.IsNullOrEmpty(dr[2].ToString()) ? '-' : Convert.ToChar(dr[2].ToString()); 
            return new Offense()
            {
                Code = Convert.ToInt32(dr[1].ToString()),
                Type = typeCode,
                OffenseDescription = dr[3].ToString(),
                Statute = dr[4].ToString(),
                BeginDate = GenerateActualDateTimeFromAOCVariant(dr[5].ToString()),
                EndDate = GenerateActualDateTimeFromAOCVariant(dr[6].ToString()),
                Class = dr[7].ToString(),
            }; 
        }

        /// <summary>
        /// Parses a <see cref="DateTime"/> value from a specific AOC string
        /// NOTE: Will return null if all 9s
        /// NOTE: Will return null if empty
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private DateTime? GenerateActualDateTimeFromAOCVariant(string date)
        {
            // Guard clause
            if (string.IsNullOrEmpty(date))
                return null;
            if (date == "0")
                return null; 
            if (date.Length < 8)
                return null; 
            if (date == "99999999")
                return null;
            if (date == "00000000")
                return null; 

            string year = date.Substring(0, 4);
            string month = date.Substring(4, 2);
            string day = date.Substring(6, 2);

            DateTime newDt = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));
            return newDt; 
        }
    }
}
