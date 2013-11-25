using EHR.CoreShared.Interfaces;
using System;

namespace EHRIntegracao.Domain.Domain
{
    public class PatientDTO : IAggregateRoot<string>
    {
        public virtual string ROWID { get; set; }

        public virtual string Id { get; set; }

        public virtual string Cpf { get; set; }

        public virtual DateTime DateBirthday { get; set; }

        public virtual string Identity { get; set; }

        public virtual string Name { get; set; }

        public virtual char Genre { get; set; }
    }
}
