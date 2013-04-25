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

    [ProtoContract(SkipConstructor = true)]
    //[ProtoInclude(7, typeof(PatientDTO))]
    public interface IPatientDTO
    {
        [ProtoMember(1)]
        string Id { get; set; }
        [ProtoMember(2)]
        string Name { get; set; }
        [ProtoMember(3)]
        DateTime? DateBirthday { get; set; }
        [ProtoMember(4)]
        string CPF { get; set; }
        [ProtoMember(5)]
        string Identity { get; set; }
        [ProtoMember(6)]
        DbEnum Hospital { get; set; }
        [ProtoMember(7)]
        List<string> Records { get; set; }

        string GetCPF();
        void AddRecord(string record);
        
    }
}
