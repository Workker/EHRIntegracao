using EHR.CoreShared;
using EHRIntegracao.Domain.Domain;
using EHRIntegracao.Domain.Factorys;
using EHRIntegracao.Domain.Repository;
using NUnit.Framework;
using System.Collections.Generic;

namespace EHRIntegracao.Test.Repository
{
    [TestFixture]
    public class PatientsDBForTest
    {
        [Test]
        [Ignore]
        public void obter_todos_paciente_teste()
        {
            PatientsDbFor repository = new PatientsDbFor();
            IList<IPatientDTO> patients = repository.Todos(new PatientDTO() { }, DbEnum.QuintaDor);

            Assert.NotNull(patients);
        }

        [Test]
        [Ignore]
        public void obter_paciente_teste()
        {
            PatientsDbFor repository = new PatientsDbFor();
            IList<IPatientDTO> patients = repository.Todos();
            var count = patients.Count;

            Assert.NotNull(patients);
        }
        [Test]
        [Ignore]
        public void inserir_patients_mockados()
        {
            var a = DbEnum.BarraDor.ToString();
            IList<IPatientDTO> patients = new List<IPatientDTO>();
            patients.Add(new PatientDTO() { Name = "temboel" });
            PatientsDbFor repository = new PatientsDbFor();

            repository.inserirPacientes(patients);

            Assert.NotNull(patients);
        }
        [Test]
        [Ignore]
        public void inserir_patients()
        {
            PatientRepository pacientes = new PatientRepository(FactorryNhibernate.GetSession(DbEnum.QuintaDor));


            var resultados = pacientes.All<Patient>();



            IList<IPatientDTO> patients = new List<IPatientDTO>();
            foreach (var paciente in resultados)
            {
                patients.Add(new PatientDTO()
                {
                    CPF = paciente.Cpf,
                    DateBirthday = paciente.DateBirthday,
                    Identity = paciente.Identity,
                    Id = DbEnum.BarraDor.ToString() + paciente.Id,
                    Name = paciente.Name,
                    Hospital = DbEnum.QuintaDor
                });
            }
            pacientes.Dispose();
            resultados = null;

            PatientsDbFor repository = new PatientsDbFor();

            repository.inserirPacientes(patients);

        }
    }
}
