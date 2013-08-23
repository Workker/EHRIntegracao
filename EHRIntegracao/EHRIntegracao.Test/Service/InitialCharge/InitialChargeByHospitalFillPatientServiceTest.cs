using EHR.CoreShared;
using EHR.CoreShared.Interfaces;
using EHRIntegracao.Domain.Services;
using EHRIntegracao.Domain.Services.GetEntities;
using EHRIntegracao.Domain.Services.InitialCharge;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Mocks;

namespace EHRIntegracao.Test.Service.InitialCharge
{
    [TestFixture]
    public class InitialChargeByHospitalFillPatientServiceTest
    {
        [Test]
        public void do_search_witch_sucess()
        {
            var initialCharge = new InitialChargeByHospitalFillPatientService();

            initialCharge.GetPatientsService = MockRepository.GenerateMock<GetPatientsService>();
            initialCharge.GetPatientsService.Expect(g => g.GetPatients(DbEnum.CopaDor, new Patient())).IgnoreArguments()
                .Return(new List<IPatient>());

            initialCharge.DoSearch(DbEnum.CopaDor, new Patient());

            Assert.NotNull(initialCharge.Patients);
        }

        [Test]
        public void do_search_witch_patient_greater_witch_sucess()
        {
            var initialCharge = new InitialChargeByHospitalFillPatientService();

            initialCharge.GetPatientsService = MockRepository.GenerateMock<GetPatientsService>();
            initialCharge.GetPatientsService.Expect(g => g.GetPatients(DbEnum.CopaDor, new Patient())).IgnoreArguments()
                .Return(new List<IPatient>()
                            {
                                new Patient(){DateBirthday = new DateTime(1989,06,27),CPF = "14041907756"}
                            }
                );

            initialCharge.DoSearch(DbEnum.CopaDor, new Patient());

            Assert.IsTrue(initialCharge.Patients.Count == 1);
        }
    }
}
