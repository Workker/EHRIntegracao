﻿using EHR.CoreShared.Entities;

namespace EHRIntegracao.Domain.Mapping
{
    public class HospitalMap : ValueObjectMap<Hospital>
    {
        HospitalMap()
        {
            Cache.NonStrictReadWrite();
            Id(h => h.Id).GeneratedBy.Identity();
            Map(h => h.Name);
            Map(h => h.URLImage);
            References(h => h.State).Cascade.None();
            Map(h => h.Key).Column("HospitalKey");
            References(h => h.Database).Cascade.All();
        }
    }
}
