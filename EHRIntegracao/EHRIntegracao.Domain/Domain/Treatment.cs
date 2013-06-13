using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHRIntegracao.Domain.Common;

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
