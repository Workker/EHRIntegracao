using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHRIntegracao.Domain.Factorys;

namespace EHRIntegracao.Domain.Services.DTO
{
    public enum HospitalPatientEnum : short
    {
        QuintaDor = 1,
        NiteroiDor,
        CopaDor,
        BarraDor
    }

    public class PatientDTO : IPatientDTO
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime DateBirthday { get; set; }
        public virtual string CPF { get; set; }
        public virtual string Identity { get; set; }
        public virtual DbEnum Hospital { get; set; }
    }
}
