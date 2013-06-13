using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHRIntegracao.Domain.Domain;
using FluentNHibernate.Mapping;

namespace EHRIntegracao.Domain.Mapping
{
    public class TreatmentMap : ClassMap<Treatment>
    {
        public TreatmentMap()
        {
            Table("FAPACCAD");
            Id(d=> d.ROWID, "ROWID");
            Map(p => p.Id, "COD_PRT").Column("COD_PRT");
            Map(p => p.EntryDate, "DATA_ENT").Column("DATA_ENT");
            Map(p => p.CheckOutDate, "DATA_ALTA").Column("DATA_ALTA");
        }
    }
}
