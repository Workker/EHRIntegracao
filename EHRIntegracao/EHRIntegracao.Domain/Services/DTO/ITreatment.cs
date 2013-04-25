using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHRIntegracao.Domain.Services.DTO
{
    public interface ITreatmentDTO
    {
        string Id { get; set; }
        DateTime EntryDate { get; set; }
        DateTime CheckOutDate { get; set; }
    }
}
