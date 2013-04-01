using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHRIntegracao.Domain.Factorys;
using ProtoBuf;

namespace EHRIntegracao.Domain.Services.DTO
{
   
   [Serializable]
   [ProtoContract(SkipConstructor = true)]
    public class PatientDTO : IPatientDTO
    {
        [ProtoMember(1)]
        public virtual string Id { get; set; }
        [ProtoMember(2)]
        public virtual string Name { get; set; }
        [ProtoMember(3)]
        public virtual string DateBirthday { get; set; }
        [ProtoMember(4)]
        public virtual string CPF { get; set; }
        [ProtoMember(5)]
        public virtual string Identity { get; set; }
        [ProtoMember(6)]
        public virtual DbEnum Hospital { get; set; }
    }

    public enum HospitalPatientEnum : short
    {
        QuintaDor = 1,
        NiteroiDor,
        CopaDor,
        BarraDor
    }

    
   
}
