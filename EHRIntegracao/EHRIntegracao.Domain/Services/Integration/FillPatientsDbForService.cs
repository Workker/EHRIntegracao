using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHRIntegracao.Domain.Repository;
using EHRIntegracao.Domain.Services.DTO;

namespace EHRIntegracao.Domain.Services
{
    public class FillPatientsDbForService
    {
        public void Fill() 
        {
            GetPatientsService getPatients =new GetPatientsService();
            var patients = getPatients.GetPatients(Factorys.DbEnum.QuintaDor,new PatientDTO());
            PatientsDbFor repository = new PatientsDbFor();
            repository.inserirPacientes(patients);
        }
    }
}
