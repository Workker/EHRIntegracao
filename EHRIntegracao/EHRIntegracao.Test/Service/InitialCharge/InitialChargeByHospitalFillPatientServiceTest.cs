using EHR.CoreShared.Entities;
using EHR.CoreShared.Interfaces;
using EHRIntegracao.Domain.Repository;
using EHRIntegracao.Domain.Services.GetEntities;
using EHRIntegracao.Domain.Services.InitialCharge;
using NUnit.Framework;
using Rhino.Mocks;
using System;
using System.Collections.Generic;

namespace EHRIntegracao.Test.Service.InitialCharge
{
    [TestFixture]
    public class InitialChargeByHospitalFillPatientServiceTest
    {
        [Test]
        public void do_search_witch_sucess()
        {
            var repositoryH = new Hospitals();
            var hospital = repositoryH.GetBy("CopaDor");
            var initialCharge = new InitialChargeByHospitalFillPatientService();

            initialCharge.GetPatientsService = MockRepository.GenerateMock<GetPatientsService>();
            initialCharge.GetPatientsService.Expect(g => g.GetPatients(hospital, new Patient())).IgnoreArguments()
                .Return(new List<IPatient>());

            initialCharge.DoSearch(hospital, new Patient());

            Assert.NotNull(initialCharge.Patients);
        }

        [Test]
        public void do_search_witch_patient_greater_witch_sucess()
        {
            var repositoryH = new Hospitals();
            var hospital = repositoryH.GetBy("CopaDor");
            var initialCharge = new InitialChargeByHospitalFillPatientService();

            initialCharge.GetPatientsService = MockRepository.GenerateMock<GetPatientsService>();
            initialCharge.GetPatientsService.Expect(g => g.GetPatients(hospital, new Patient())).IgnoreArguments()
                .Return(new List<IPatient>()
                            {
                                new Patient(){DateBirthday = new DateTime(1989,06,27),CPF = "14041907756"}
                            }
                );

            initialCharge.DoSearch(hospital, new Patient());

            Assert.IsTrue(initialCharge.Patients.Count == 1);
        }
    }
}
