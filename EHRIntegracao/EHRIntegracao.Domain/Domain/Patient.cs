using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHR.CoreShared.Interfaces;
using EHRIntegracao.Domain.Common;

namespace EHRIntegracao.Domain.Domain
{
    public class Patient : IAggregateRoot<string>
    {
        public virtual string ROWID { get; set; }

        public virtual string Id { get; set; }

        public virtual string Cpf { get; set; }

        public virtual DateTime DateBirthday { get; set; }

        public virtual string Identity { get; set; }

        public virtual string Name { get; set; }
    }
}
