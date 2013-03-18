using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHRIntegracao.Domain.Domain;
using EHRIntegracao.Domain.Factorys;
using EHRIntegracao.Domain.Repository;
using NUnit.Framework;

namespace EHRIntegracao.Test.Repository
{
    [TestFixture]
    public class PatientsTest
    {
        [Test]
        public void buscarPacientes()
        {
            PatientRepository pacientes = new PatientRepository(FactorryNhibernate.GetSession(DbEnum.QuintaDor));

            var resultados = pacientes.All<Patient>();

            Assert.NotNull(resultados);

        }
    }
}
