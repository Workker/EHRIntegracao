using EHR.CoreShared;
using EHRIntegracao.Domain.Repository;
using EHRIntegracao.Domain.Services;
using EHRIntegracao.Domain.Services.GetEntities;
using EHRIntegracao.Domain.Services.InitialCharge;
using EHRIntegracao.Test.Performace;
using FizzWare.NBuilder;
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
  //  [Ignore]
    public class InitialChargeByHospitalServiceTest
    {
        //[Test]
        //public void charge_witch_sucess()
        //{
        //    var initialCharge = new InitialChargeByHospitalService();

        //    initialCharge.InitialChargeByHospitalFillPatientService.GetPatientsService = MockRepository.GenerateMock<GetPatientsService>();
        //    initialCharge.InitialChargeByHospitalFillPatientService.GetPatientsService
        //        .Expect(get => get.GetPatients(DbEnum.QuintaDor, new PatientDTO()))
        //        .IgnoreArguments()
        //        .Return(
        //            new List<IPatientDTO>()
        //                {
        //                    new PatientDTO() {Hospital = DbEnum.Bangu, Id = "123", CPF = "14041907756",DateBirthday = new DateTime(1989,06,27)},
        //                    new PatientDTO() {Hospital = DbEnum.Bangu, Id = "124", CPF = "14041907756",DateBirthday = new DateTime(1989,06,27)}
        //                });

        //    initialCharge.GetTreatmentService = MockRepository.GenerateMock<GetTreatmentService>();
        //    initialCharge.GetTreatmentService.Expect(e => e.GetTreatments(DbEnum.QuintaDor))
        //        .IgnoreArguments()
        //        .Return(
        //            new List<ITreatmentDTO>()
        //                {
        //                    new TreatmentDTO(){Hospital = DbEnum.Bangu,EntryDate =new DateTime(2012,06,27),CheckOutDate =new DateTime(2012,06,30),Id = "123"},
        //                    new TreatmentDTO(){Hospital = DbEnum.Bangu,EntryDate =new DateTime(2011,06,27),CheckOutDate =new DateTime(2011,06,30),Id  = "123"},
        //                    new TreatmentDTO(){Hospital = DbEnum.Bangu,EntryDate =new DateTime(2012,06,27),CheckOutDate =new DateTime(2010,06,30),Id  = "124"},
        //                    new TreatmentDTO(){Hospital = DbEnum.Bangu,EntryDate =new DateTime(2011,06,27),CheckOutDate =new DateTime(2009,06,30),Id  = "124"}
        //                }
        //            );

        //    //initialCharge.TreatmensDbFor = MockRepository.GenerateMock<TreatmensDbFor>();
        //    //initialCharge.TreatmensDbFor.Expect(t => t.inserir(new List<ITreatmentDTO>())).IgnoreArguments();

        //    //initialCharge.TreatmentsLuceneService = MockRepository.GenerateMock<TreatmentsLuceneService>();
        //    //initialCharge.TreatmentsLuceneService.Expect(t => t.SaveTreatment(new List<ITreatmentDTO>())).
        //    //    IgnoreArguments();

        //    initialCharge.PatientRepositoryDbFor = MockRepository.GenerateMock<PatientsDbFor>();
        //    initialCharge.PatientRepositoryDbFor.Expect(p => p.inserirPacientes(new List<IPatientDTO>())).
        //        IgnoreArguments();

        //    initialCharge.SavePatientsLuceneService = MockRepository.GenerateMock<SavePatientsLuceneService>();
        //    initialCharge.SavePatientsLuceneService.Expect(s => s.SavePatientsLucene(new List<IPatientDTO>())).
        //        IgnoreArguments();

        //    initialCharge.GetValuesDbEnumService = MockRepository.GenerateMock<GetValuesDbEnumService>();
        //    initialCharge.GetValuesDbEnumService.Expect(g => g.GetValues()).IgnoreArguments().Return(
        //        new List<DbEnum>() { DbEnum.Bangu });

        //    initialCharge.DoSearch(new PatientDTO());

        //    Assert.IsTrue(initialCharge.Patients.Count == 1);
        //    Assert.IsTrue(initialCharge.Patients.First().Treatments.Count == 4);
        //}

        //[Test]
        //[ExpectedException(typeof(ApplicationException), ExpectedMessage = "Paciente não informado.")]
        //public  void charge_witch_patient_equals_null_must_return_exception()
        //{
        //    var initialCharge = new InitialChargeByHospitalService();
        //    initialCharge.DoSearch(null);
        //}

        //[Test]
        ////Teste de Performance Deixar comentado
        //[Ignore]
        //public void charge_wicth_multiple_patients_and_multiple_treatments_sucess()
        //{
        //    var initialCharge = new InitialChargeByHospitalService();

        //    var patients = Builder<PatientDTO>.CreateListOfSize(90000)
        //                           .TheFirst(7)
        //                           .With(x => x.CPF = "14041907756")
        //                           .With(x => x.Id = "123")
        //                           .And(x => x.DateBirthday = new DateTime(1989, 06, 27))
        //                           .And(x => x.Hospital = DbEnum.Bangu)
        //                           .TheNext(89993)
        //                           .With(x => x.CPF = "41123764808")
        //                           .And(x => x.DateBirthday = new DateTime(1990, 06, 27))
        //                           .And(x => x.Hospital = DbEnum.Bangu)
        //                           .Build();

        //    var treatments = Builder<TreatmentDTO>.CreateListOfSize(90000)
        //        .TheFirst(1)
        //        .And(x => x.Id = "123")
        //        .And(x => x.Hospital = DbEnum.Bangu)
        //        .And(x => x.CheckOutDate = new DateTime(2012, 06, 30))
        //        .And(x => x.EntryDate = new DateTime(2012, 06, 27))
        //        .TheNext(1)
        //        .And(x => x.Id = "123")
        //        .And(x => x.Hospital = DbEnum.Bangu)
        //        .And(x => x.CheckOutDate = new DateTime(2012, 05, 05))
        //        .And(x => x.EntryDate = new DateTime(2012, 05, 01))
        //        .TheNext(89998)
        //        .And(x => x.Hospital = DbEnum.Bangu)
        //        .And(x => x.CheckOutDate = new DateTime(2011, 07, 05))
        //        .And(x => x.EntryDate = new DateTime(2011, 07, 01))
        //        .Build();


        //    initialCharge.InitialChargeByHospitalFillPatientService.GetPatientsService = MockRepository.GenerateMock<GetPatientsService>();
        //    initialCharge.InitialChargeByHospitalFillPatientService.GetPatientsService
        //        .Expect(get => get.GetPatients(DbEnum.QuintaDor, new PatientDTO()))
        //        .IgnoreArguments()
        //        .Return(Convert(patients));

        //    initialCharge.GetTreatmentService = MockRepository.GenerateMock<GetTreatmentService>();
        //    initialCharge.GetTreatmentService.Expect(e => e.GetTreatments(DbEnum.QuintaDor))
        //        .IgnoreArguments()
        //        .Return(Convert(treatments));

        //    //initialCharge.TreatmensDbFor = MockRepository.GenerateMock<TreatmensDbFor>();
        //    //initialCharge.TreatmensDbFor.Expect(t => t.inserir(new List<ITreatmentDTO>())).IgnoreArguments();

        //    //initialCharge.TreatmentsLuceneService = MockRepository.GenerateMock<TreatmentsLuceneService>();
        //    //initialCharge.TreatmentsLuceneService.Expect(t => t.SaveTreatment(new List<ITreatmentDTO>())).
        //    //    IgnoreArguments();

        //    initialCharge.PatientRepositoryDbFor = MockRepository.GenerateMock<PatientsDbFor>();
        //    initialCharge.PatientRepositoryDbFor.Expect(p => p.inserirPacientes(new List<IPatientDTO>())).
        //        IgnoreArguments();

        //    initialCharge.SavePatientsLuceneService = MockRepository.GenerateMock<SavePatientsLuceneService>();
        //    initialCharge.SavePatientsLuceneService.Expect(s => s.SavePatientsLucene(new List<IPatientDTO>())).
        //        IgnoreArguments();

        //    initialCharge.GetValuesDbEnumService = MockRepository.GenerateMock<GetValuesDbEnumService>();
        //    initialCharge.GetValuesDbEnumService.Expect(g => g.GetValues()).IgnoreArguments().Return(
        //        new List<DbEnum>() { DbEnum.Bangu });

        //    initialCharge.DoSearch(new PatientDTO());

        //}

        //private IList<ITreatmentDTO> Convert(IList<TreatmentDTO> treatments)
        //{
        //    IList<ITreatmentDTO> Itreatments = new List<ITreatmentDTO>();
        //    foreach (var treatment in treatments)
        //    {
        //        Itreatments.Add(treatment);
        //    }

        //    return Itreatments;
        //}

        //private IList<IPatientDTO> Convert(IList<PatientDTO> patients)
        //{
        //    IList<IPatientDTO> Ipatients = new List<IPatientDTO>();
        //    foreach (var patient in patients)
        //    {
        //        Ipatients.Add(patient);
        //    }

        //    return Ipatients;
        //}
    }
}

