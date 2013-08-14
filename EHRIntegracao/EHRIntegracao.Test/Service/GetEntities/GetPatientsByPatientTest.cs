using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHR.CoreShared;
using EHR.CoreShared.Interfaces;
using EHRIntegracao.Domain.Services.Integration;
using NUnit.Framework;
using Rhino;
using Rhino.Mocks;
using EHRIntegracao.Domain.Services.GetEntities;

namespace EHRIntegracao.Test.Service
{
    [TestFixture]
    public class GetPatientsByPatientTest 
    {
        [Test]
        public void get_patients_by_hospital_witch_sucess() 
        {
            GetPatientsByPatient service = new GetPatientsByPatient();
            service.GetPatientsService = MockRepository.GenerateMock<GetPatientsService>();
            service.GetPatientsService.Expect(s => s.GetPatients(DbEnum.Bangu, new Patient())).IgnoreArguments().Return(new List<IPatient>());
            var patients = service.GetAll(new Patient() { Name = "Marcelo",Hospital = DbEnum.Bangu});

            Assert.NotNull(patients);
        }

        [Test]
        public void get_all_patients_witch_sucess()
        {
            GetPatientsByPatient service = new GetPatientsByPatient();
            service.GetPatientsService = MockRepository.GenerateMock<GetPatientsService>();
            service.GetPatientsService.Expect(s => s.GetPatients(DbEnum.Bangu, new Patient())).IgnoreArguments().Return(new List<IPatient>());
            var patients = service.GetAll(new Patient() { Name = "Marcelo" });

            Assert.NotNull(patients);
        }
    }
}
