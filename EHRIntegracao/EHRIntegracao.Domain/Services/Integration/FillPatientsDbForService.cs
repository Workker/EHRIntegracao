using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHR.CoreShared;
using EHRIntegracao.Domain.Repository;


namespace EHRIntegracao.Domain.Services
{
    public class FillPatientsDbForService
    {
        public void Fill() 
        {
            GetPatientsService getPatients =new GetPatientsService();
            var patients = getPatients.GetPatients(DbEnum.QuintaDor,new PatientDTO());
            PatientsDbFor repository = new PatientsDbFor();
            repository.inserirPacientes(patients);
        }
    }
}
