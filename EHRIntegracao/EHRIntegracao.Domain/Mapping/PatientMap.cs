using EHRIntegracao.Domain.Domain;
using FluentNHibernate.Mapping;

namespace EHRIntegracao.Domain.Mapping
{
    public class PatientMap : ClassMap<Patient>
    {
        public PatientMap()
        {
            Table("faprtcad");
            Id(d => d.ROWID, "ROWID");
            Map(p => p.Id, "cod_prt");
            Map(p => p.Cpf, "CPF");
            Map(p => p.DateBirthday, "NASCIMENTO");
            Map(p => p.Identity, "IDENTIDADE");
            Map(p => p.Name, "NOME_PAC");
        }
    }
}
