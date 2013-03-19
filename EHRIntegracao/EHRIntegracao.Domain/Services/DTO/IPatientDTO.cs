using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHRIntegracao.Domain.Services.DTO
{
    public interface IPatientDTO
    {
        int Id { get; set; }
        string Name { get; set; }
        DateTime DateBirthday { get; set; }
        string CPF { get; set; }
        string Identity { get; set; }
        HospitalPatientEnum Hospital { get; set; }
    }
}
