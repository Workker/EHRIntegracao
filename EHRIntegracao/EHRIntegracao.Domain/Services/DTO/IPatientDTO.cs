using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHRIntegracao.Domain.Factorys;

namespace EHRIntegracao.Domain.Services.DTO
{
    
    public interface IPatientDTO
    {
        string Id { get; set; }
        string Name { get; set; }
        string DateBirthday { get; set; }
        string CPF { get; set; }
        string Identity { get; set; }
        DbEnum Hospital { get; set; }
    }
}
