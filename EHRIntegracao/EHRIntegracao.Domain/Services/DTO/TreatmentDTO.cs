using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace EHRIntegracao.Domain.Services.DTO
{
    [Serializable]
    [ProtoContract(SkipConstructor = true)]
    public class TreatmentDTO : ITreatmentDTO
    {
        [ProtoMember(1)]
        public string Id { get; set; }

        [ProtoMember(2)]
        public DateTime EntryDate { get; set; }

        [ProtoMember(3)]
        public DateTime CheckOutDate { get; set; }
    }
}
