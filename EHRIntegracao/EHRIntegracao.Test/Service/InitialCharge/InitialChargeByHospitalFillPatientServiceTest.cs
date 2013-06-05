using EHR.CoreShared;
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
            initialCharge.GetPatientsService.Expect(g => g.GetPatients(DbEnum.Copa, new PatientDTO())).IgnoreArguments()
                .Return(new List<IPatientDTO>());

            initialCharge.DoSearch(DbEnum.Copa, new PatientDTO());

            Assert.NotNull(initialCharge.Patients);
        }

        [Test]
        public void do_search_witch_patient_greater_witch_sucess()
        {
            var initialCharge = new InitialChargeByHospitalFillPatientService();

            initialCharge.GetPatientsService = MockRepository.GenerateMock<GetPatientsService>();
            initialCharge.GetPatientsService.Expect(g => g.GetPatients(DbEnum.Copa, new PatientDTO())).IgnoreArguments()
                .Return(new List<IPatientDTO>()
                            {
                                new PatientDTO(){DateBirthday = new DateTime(1989,06,27),CPF = "14041907756"}
                            }
                );

            initialCharge.DoSearch(DbEnum.Copa, new PatientDTO());

            Assert.IsTrue(initialCharge.Patients.Count == 1);
        }
    }
}
