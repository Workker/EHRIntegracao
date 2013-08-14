using EHR.CoreShared.Interfaces;
using EHRLucene.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EHRIntegracao.Domain.Services.GetEntities
{
    public class GetPatientsLuceneService
    {
        public int fatia = 300;
        public int Totalrecords;
        public int TotalDePacientesEmProcessamento = 0;
        public int totalRecordsProcess = 0;

        public IPatient GetPatientBy(string cpf)
        {
            var lucene = new LuceneClient("");
            return lucene.SearchBy(cpf);
        }

        public List<IPatient> GetPatients(string name)
        {
            var lucene = new LuceneClient("");
            return lucene.SimpleSearch(name).Take(10).ToList();
        }
        //Todo: Mock
        public List<IPatient> MockPatients(string name)
        {
            var lucene = new LuceneClient("E:\\Projects\\EHR\\EHR.Solution\\EHR.UI\\lucene_index");
            return lucene.SimpleSearch(name).Take(10).ToList();
        }

        public List<IPatient> GetPatientsAdvancedSearch(IPatient patient, List<string> hospitals)
        {
            var lucene = new LuceneClient("");
            return lucene.AdvancedSearch(patient, hospitals).ToList();
        }

        public List<IPatient> GetPatientPeriodic(List<IPatient> patients)
        {

            try
            {
                var lucene = new LuceneClient("");
                Totalrecords = patients.Count;
                var patientsLucene = new List<IPatient>();
                while (totalRecordsProcess < Totalrecords)
                {
                    var records = patients.Skip(totalRecordsProcess).Take(fatia).ToList();
                    var patientsFatia = lucene.AdvancedSearch(records).ToList();
                    patientsLucene.AddRange(patientsFatia);
                    Fatiar();
                }
                return patientsLucene;
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void Fatiar()
        {
            int totalOffRecords = Totalrecords - totalRecordsProcess;

            if (totalOffRecords < fatia)
                totalRecordsProcess += totalOffRecords;
            else
                totalRecordsProcess += fatia;

        }
    }
}
