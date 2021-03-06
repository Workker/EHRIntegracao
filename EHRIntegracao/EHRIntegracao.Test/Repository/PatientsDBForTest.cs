﻿using EHR.CoreShared;
using EHR.CoreShared.Entities;
using EHR.CoreShared.Interfaces;
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
            var repositoryH = new Hospitals();
            var hospital = repositoryH.GetBy("QuintaDor");
            PatientsDbFor repository = new PatientsDbFor();
            IList<IPatient> patients = repository.Todos(new Patient() { }, hospital);

            Assert.NotNull(patients);
        }

        [Test]
        [Ignore]
        public void obter_paciente_teste()
        {
            PatientsDbFor repository = new PatientsDbFor();
            IList<IPatient> patients = repository.Todos();
            var count = patients.Count;

            Assert.NotNull(patients);
        }

    }
}
