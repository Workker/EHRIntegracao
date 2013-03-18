using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHRIntegracao.Domain.Services.DTO
{
    public class PatientDTO
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime DateBirthday { get; set; }
        public virtual string CPF { get; set; }
        public virtual string Identity { get; set; }
    }
}
