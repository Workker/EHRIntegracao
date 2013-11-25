using EHRIntegracao.Domain.Factorys;
using EHRIntegracao.Domain.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace EHRIntegracao.Test.Integration
{
    [TestFixture]
    public class IntegrationTest
    {
        [Test]
        [Ignore]
        public void IntegrarPacientesRedeDor()
        {
            var repository = new Hospitals();
            var hospital = repository.GetBy("QuintaDor");
            PatientDTORepository pacientes = new PatientDTORepository(FactorryNhibernate.GetSession(hospital.Database));


            var resultados = pacientes.All<EHRIntegracao.Domain.Domain.PatientDTO>();



            IList<EHRIntegracao.Domain.Domain.PatientDTO> patients = new List<EHRIntegracao.Domain.Domain.PatientDTO>();
            foreach (var paciente in resultados)
            {
                patients.Add(new EHRIntegracao.Domain.Domain.PatientDTO()
                {
                    Cpf = paciente.Cpf,
                    DateBirthday = paciente.DateBirthday,
                    Identity = paciente.Identity,
                    Id = paciente.Id,
                    Name = paciente.Name
                });
            }
            pacientes.Dispose();
            resultados = null;
            var patietsRepositrory = new PatientDTORepository(FactorryNhibernate.GetSession(hospital.Database));
            patietsRepositrory.SalvarLista(patients);
        }

        [Test]
        [Ignore]
        public void SalvarEdeletarPaciente()
        {
            var repository = new Hospitals();
            var hospital = repository.GetBy("QuintaDor");
            PatientDTORepository pacientes = new PatientDTORepository(FactorryNhibernate.GetSession(hospital.Database));
            var paciente = new EHRIntegracao.Domain.Domain.PatientDTO() { Id = "JK", DateBirthday = DateTime.Now, Identity = "sas", Name = "javet", Cpf = "234" };

            pacientes.Save<string>(paciente);

            pacientes.Delete<string>(paciente);

        }
    }
}
