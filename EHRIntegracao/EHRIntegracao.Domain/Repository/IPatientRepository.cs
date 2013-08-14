using EHR.CoreShared.Interfaces;
using System.Collections.Generic;


namespace EHRIntegracao.Domain.Repository
{
    public interface IPatientRepository
    {
        IList<T> GetAll<T>();
        IList<T> GetPatientsBy<T>(IPatient patient);
        void SalvarLista<T>(IList<T> roots);
    }
}
