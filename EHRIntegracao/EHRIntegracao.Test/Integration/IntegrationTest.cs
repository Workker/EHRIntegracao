using EHR.CoreShared;
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
            PatientRepository pacientes = new PatientRepository(FactorryNhibernate.GetSession(DbEnum.QuintaDor));


            var resultados = pacientes.All<EHRIntegracao.Domain.Domain.Patient>();



            IList<EHRIntegracao.Domain.Domain.Patient> patients = new List<EHRIntegracao.Domain.Domain.Patient>();
            foreach (var paciente in resultados)
            {
                patients.Add(new EHRIntegracao.Domain.Domain.Patient()
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
            var patietsRepositrory = new PatientRepository(FactorryNhibernate.GetSession(DbEnum.QuintaDor));
            patietsRepositrory.SalvarLista(patients);
        }

        [Test]
        [Ignore]
        public void SalvarEdeletarPaciente()
        {
            PatientRepository pacientes = new PatientRepository(FactorryNhibernate.GetSession(DbEnum.QuintaDor));
            var paciente = new EHRIntegracao.Domain.Domain.Patient() { Id = "JK", DateBirthday = DateTime.Now, Identity = "sas", Name = "javet", Cpf = "234" };

            pacientes.Save<string>(paciente);

            pacientes.Delete<string>(paciente);

        }
    }
}
