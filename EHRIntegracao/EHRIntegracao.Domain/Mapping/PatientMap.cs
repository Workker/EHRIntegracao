using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHRIntegracao.Domain.Domain;
using FluentNHibernate.Mapping;

namespace EHRIntegracao.Domain.Mapping
{
    public class PatientMap : ClassMap<Patient>
    {
        public PatientMap()
        {
            Table("faprtcad");
            Id(p => p.Id, "cod_prt").GeneratedBy.Assigned();
            Map(p => p.Cpf, "CPF");
            Map(p => p.DateBirthday, "NASCIMENTO");
            Map(p => p.Identity, "IDENTIDADE");
            Map(p => p.Name, "NOME_PAC");
        }
    }
}
