using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public virtual DateTime? DateBirthday { get; set; }
        [ProtoMember(4)]
        public virtual string CPF { get; set; }
        [ProtoMember(5)]
        public virtual string Identity { get; set; }
        [ProtoMember(6)]
        public virtual DbEnum Hospital { get; set; }
        [ProtoMember(7)]
        public virtual List<string> Records { get; set; }

        public virtual List<ITreatmentDTO> Treatments { get; set; }

        public virtual string GetCPF()
        {
            return Regex.Replace(CPF, "[^0-9]", string.Empty);
        }

        public virtual void AddRecord(string record)
        {
            if (Records == null)
                Records = new List<string>();

            Records.Add(record);
        }


        public virtual void AddTreatments(IList<ITreatmentDTO> treatments)
        {
            if (Treatments == null)
                Treatments = new List<ITreatmentDTO>();

            Treatments.AddRange(treatments);
        }
    }

    public enum HospitalPatientEnum : short
    {
        QuintaDor = 1,
        NiteroiDor,
        CopaDor,
        BarraDor
    }



}
