using System;
using System.ComponentModel.DataAnnotations;

namespace OffenseLibrary
{
    internal class Offense : IOffense
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int Code { get; set; }
        public char Type { get; set; }

        [Required]
        public string OffenseDescription { get; set; }
        public string Statute { get; set; }
        public string Class { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
