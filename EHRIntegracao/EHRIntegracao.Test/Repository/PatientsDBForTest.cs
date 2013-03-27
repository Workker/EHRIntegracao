using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHRIntegracao.Domain.Domain;
using EHRIntegracao.Domain.Factorys;
using EHRIntegracao.Domain.Repository;
using EHRIntegracao.Domain.Services.DTO;
using NUnit.Framework;
using Db4objects.Db4o;
using Db4objects.Db4o.Query;

namespace EHRIntegracao.Test.Repository
{
    [TestFixture]
    public class PatientsDBForTest
    {
        [Test]
        public void obter_todos_paciente_teste()
        {
            PatientsDbFor repository = new PatientsDbFor();
            IList<IPatientDTO> patients = repository.Todos(new PatientDTO() { }, DbEnum.QuintaDorWorkker);

            Assert.NotNull(patients);
        }

        [Test]
        [Ignore]
        public void obter_paciente_teste()
        {
            PatientsDbFor repository = new PatientsDbFor();
            IList<PatientDTO> patients = repository.Todos();
            var count = patients.Count;

            Assert.NotNull(patients);
        }
        [Test]
        [Ignore]
        public void inserir_patients_mockados()
        {
            IList<PatientDTO> patients = new List<PatientDTO>();
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



            IList<PatientDTO> patients = new List<PatientDTO>();
            foreach (var paciente in resultados)
            {
                patients.Add(new PatientDTO()
                {
                    CPF = paciente.Cpf,
                    DateBirthday = paciente.DateBirthday,
                    Identity = paciente.Identity,
                    Id = paciente.Id,
                    Name = paciente.Name,
                    Hospital = DbEnum.QuintaDorWorkker
                });
            }
            pacientes.Dispose();
            resultados = null;

            PatientsDbFor repository = new PatientsDbFor();

            repository.inserirPacientes(patients);
        }
    }
}
