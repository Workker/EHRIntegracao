using EHR.CoreShared.Interfaces;
using EHRIntegracao.Domain.Common;
using System;

namespace EHRIntegracao.Domain.Domain
{
    [Serializable]
    public class Treatment : IAggregateRoot<string>
    {
        public virtual string ROWID { get; set; }
        public virtual string Id { get; set; }
        public virtual DateTime EntryDate { get; set; }
        public virtual DateTime CheckOutDate { get; set; }
    }
}
