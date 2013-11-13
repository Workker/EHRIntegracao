using EHR.CoreShared.Entities;
using EHR.CoreShared.Interfaces;
using EHRIntegracao.Domain.Repository;
using EHRIntegracao.Domain.Services.GetEntities;
using EHRIntegracao.Domain.Services.Integration;
using NUnit.Framework;
using Rhino.Mocks;
using System.Collections.Generic;

namespace EHRIntegracao.Test.Service
{
    [TestFixture]
    public class GetPatientsByPatientTest 
    {
        [Test]
        public void get_patients_by_hospital_witch_sucess() 
        {
            var repositoryH = new Hospitals();
            var hospital = repositoryH.GetBy("Bangu");
            GetPatientsByPatient service = new GetPatientsByPatient();
            service.GetPatientsService = MockRepository.GenerateMock<GetPatientsService>();
            service.GetPatientsService.Expect(s => s.GetPatients(hospital, new Patient())).IgnoreArguments().Return(new List<IPatient>());
            var patients = service.GetAll(new Patient() { Name = "Marcelo",Hospital = hospital});

            Assert.NotNull(patients);
        }

        [Test]
        public void get_all_patients_witch_sucess()
        {
            var repositoryH = new Hospitals();
            var hospital = repositoryH.GetBy("Bangu");
            GetPatientsByPatient service = new GetPatientsByPatient();
            service.GetPatientsService = MockRepository.GenerateMock<GetPatientsService>();
            service.GetPatientsService.Expect(s => s.GetPatients(hospital, new Patient())).IgnoreArguments().Return(new List<IPatient>());
            var patients = service.GetAll(new Patient() { Name = "Marcelo" });

            Assert.NotNull(patients);
        }
    }
}
