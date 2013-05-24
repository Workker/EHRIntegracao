using EHR.CoreShared;
using EHRIntegracao.Domain.Repository;
using EHRIntegracao.Domain.Services;
using EHRIntegracao.Domain.Services.GetEntities;
using EHRIntegracao.Domain.Services.InitialCharge;
using NUnit.Framework;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHRIntegracao.Test.Service.InitialCharge
{
    [TestFixture]
    public class InitialChargeByHospitalServiceTest
    {
        [Test]
        public void charge_wicth_sucess()
        {
            InitialChargeByHospitalService initialCharge = new InitialChargeByHospitalService();

            initialCharge.InitialChargeByHospitalFillPatientService.GetPatientsService = MockRepository.GenerateMock<GetPatientsService>();
            initialCharge.InitialChargeByHospitalFillPatientService.GetPatientsService
                .Expect(get => get.GetPatients(DbEnum.QuintaDor, new PatientDTO()))
                .IgnoreArguments()
                .Return(
                    new List<IPatientDTO>()
                        {
                            new PatientDTO() {Hospital = DbEnum.BarraDor, Id = "123", CPF = "14041907756",DateBirthday = new DateTime(1989,06,27)},
                            new PatientDTO() {Hospital = DbEnum.BarraDor, Id = "124", CPF = "14041907756",DateBirthday = new DateTime(1989,06,27)}
                        });

            initialCharge.GetTreatmentService = MockRepository.GenerateMock<GetTreatmentService>();
            initialCharge.GetTreatmentService.Expect(e => e.GetTreatments(DbEnum.QuintaDor))
                .IgnoreArguments()
                .Return(
                    new List<ITreatmentDTO>()
                        {
                            new TreatmentDTO(){Hospital = DbEnum.BarraDor,EntryDate =new DateTime(2012,06,27),CheckOutDate =new DateTime(2012,06,30),Id = "123"},
                            new TreatmentDTO(){Hospital = DbEnum.BarraDor,EntryDate =new DateTime(2011,06,27),CheckOutDate =new DateTime(2011,06,30),Id = "123"},
                            new TreatmentDTO(){Hospital = DbEnum.BarraDor,EntryDate =new DateTime(2012,06,27),CheckOutDate =new DateTime(2010,06,30),Id = "124"},
                            new TreatmentDTO(){Hospital = DbEnum.BarraDor,EntryDate =new DateTime(2011,06,27),CheckOutDate =new DateTime(2009,06,30),Id = "124"}
                        }
                    );

            initialCharge.TreatmensDbFor = MockRepository.GenerateMock<TreatmensDbFor>();
            initialCharge.TreatmensDbFor.Expect(t => t.inserir(new List<ITreatmentDTO>())).IgnoreArguments();

            initialCharge.TreatmentsLuceneService = MockRepository.GenerateMock<TreatmentsLuceneService>();
            initialCharge.TreatmentsLuceneService.Expect(t => t.SaveTreatment(new List<ITreatmentDTO>())).
                IgnoreArguments();

            initialCharge.PatientRepositoryDbFor = MockRepository.GenerateMock<PatientsDbFor>();
            initialCharge.PatientRepositoryDbFor.Expect(p => p.inserirPacientes(new List<IPatientDTO>())).
                IgnoreArguments();

            initialCharge.SavePatientsLuceneService = MockRepository.GenerateMock<SavePatientsLuceneService>();
            initialCharge.SavePatientsLuceneService.Expect(s => s.SavePatientsLucene(new List<IPatientDTO>())).
                IgnoreArguments();

            initialCharge.GetValuesDbEnumService = MockRepository.GenerateMock<GetValuesDbEnumService>();
            initialCharge.GetValuesDbEnumService.Expect(g => g.GetValues()).IgnoreArguments().Return(
                new List<DbEnum>() {DbEnum.BarraDor});

            initialCharge.DoSearch(new PatientDTO());

            Assert.IsTrue(initialCharge.PatientsDb.Count == 1);
            Assert.IsTrue(initialCharge.PatientsDb.First().Treatments.Count == 4);
        }
    }
}

