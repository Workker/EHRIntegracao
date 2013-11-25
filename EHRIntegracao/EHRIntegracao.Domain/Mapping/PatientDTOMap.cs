using EHRIntegracao.Domain.Domain;
using FluentNHibernate.Mapping;

namespace EHRIntegracao.Domain.Mapping
{
    public class PatientDTOMap : ClassMap<PatientDTO>
    {
        public PatientDTOMap()
        {
            Table("faprtcad");
            Id(d => d.ROWID, "ROWID");
            Map(p => p.Id, "cod_prt");
            Map(p => p.Cpf, "CPF");
            Map(p => p.DateBirthday, "NASCIMENTO");
            Map(p => p.Identity, "IDENTIDADE");
            Map(p => p.Name, "NOME_PAC");
            //Map(p => p.Genre, "SEXO"); Todo: solicitar que seja incluido na view
        }
    }
}
