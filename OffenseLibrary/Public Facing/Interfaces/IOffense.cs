using System;

namespace OffenseLibrary
{
    public interface IOffense
    {
        DateTime? BeginDate { get; set; }
        string Class { get; set; }
        int Code { get; set; }
        DateTime? EndDate { get; set; }
        int ID { get; set; }
        string OffenseDescription { get; set; }
        string Statute { get; set; }
        char Type { get; set; }
    }
}