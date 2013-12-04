using System.Diagnostics;
using EHR.CoreShared.Entities;
using EHRIntegracao.Domain.Services.InitialCharge;

namespace EHRIntegracao.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //TreatmentsLuceneService service = new TreatmentsLuceneService();
            //var tretments = service.GetTreatments(new PatientDTO() { Id = "000001707" });

            Stopwatch sw;

            //var serviceInitial = new InitialChargeTreatmentByHospitalService();

            //sw = Stopwatch.StartNew();

            //serviceInitial.DoSearch();

            //sw.Stop();

            //System.Console.WriteLine("Treatments Time taken: {0}ms", sw.Elapsed.TotalMilliseconds);

            var service = new InitialChargeByHospitalService();

            sw = Stopwatch.StartNew();

            service.DoSearch(new Patient());

            sw.Stop();

            System.Console.WriteLine("Treatments Time taken: {0}ms", sw.Elapsed.TotalMilliseconds);

            //PatientRepository pacientes = new PatientRepository(FactorryNhibernate.GetSession(DbEnum.Copa));

            //var resultados = pacientes.GetPatientsWithPeriod();


            //var integration = new IntregationPeriodicCharge();
            //integration.Do();

            //service.Patients = new List<IPatientDTO>();
            //service.Patients.Add(new PatientDTO() { Hospital = DbEnum.Copa ,Records = new List<RecordDTO>(){new RecordDTO(){Hospital = DbEnum.Copa,Code ="123"}}});
            //service.Patients.Add(new PatientDTO() { Hospital = DbEnum.Copa, Records = new List<RecordDTO>() { new RecordDTO() { Hospital = DbEnum.Copa, Code = "124" } } });
            //service.Patients.Add(new PatientDTO() { Hospital = DbEnum.Copa, Records = new List<RecordDTO>() { new RecordDTO() { Hospital = DbEnum.Copa, Code = "125" } } });



            // FillPatientsDbForService service = new FillPatientsDbForService();
            // service.Fill();

            //var serviceSave = new SavePatientsCacheService();
            //serviceSave.Save(DbEnum.QuintaDor);

            //var service = new GetPatientsLuceneService();
            //var patientsSimple = service.GetPatients("LEA");
            //var patients =  service.GetPatientsAdvancedSearch(new PatientDTO() {Name = "LEA", DateBirthday = ""},new List<string>());


            // var service = new GetPatientRedisService();
            //  var result = service.GetPatientByKey(DbEnum.QuintaDorWorkker);


            //  SavePatientsCacheService service = new SavePatientsCacheService();

            ////  Esse serviço eu insiro no memcache com a chave quintaDOrWorkker
            //  service.Save(Domain.Factorys.DbEnum.QuintaDorWorkker);


            //ObterPacientes(DbEnum.QuintaDor, new PatientDTO() { Name = "LEA" }).ContinueWith(Finalizer);
            //ObterPacientes(DbEnum.QuintaDorWorkker, new PatientDTO() { Name = "LEA" }).ContinueWith(Finalizer);
            //ObterPacientes(DbEnum.CopaDor, new PatientDTO() { Name = "LEA" }).ContinueWith(Finalizer);
            //ObterPacientes(DbEnum.sumario, new PatientDTO() { Name = "LEA" }).ContinueWith(Finalizer);
            //ObterPacientes(DbEnum.QuintaDorWorkker, new PatientDTO() { Name = "LEA" }).ContinueWith(Finalizer);
            //ObterPacientes(DbEnum.QuintaDorWorkker, new PatientDTO() { Name = "LEA" }).ContinueWith(Finalizer);

            //var pacientesNovos = ObterPacientes(DbEnum.QuintaDorWorkker, new PatientDTO() { Name = "LEA" }).ContinueWith(Finalizer);
            //var pacientesNovos = ObterPacientes(DbEnum.QuintaDorWorkker, new PatientDTO() { Name = "LEA" }).ContinueWith(Finalizer);
            //var pacientesNovos = ObterPacientes(DbEnum.QuintaDorWorkker, new PatientDTO() { Name = "LEA" }).ContinueWith(Finalizer);

            System.Console.WriteLine("Acabou!");
            System.Console.ReadKey();
        }

        //private static void Finalizer(Task<IList<IPatientDTO>> task)
        //{
        //    foreach (var item in task.Result)
        //    {
        //        System.Console.WriteLine(item.Name);
        //    }
        //}

        //private static Task<IList<IPatientDTO>> ObterPacientes(DbEnum db, IPatientDTO patient)
        //{
        //    return Task<IList<IPatientDTO>>.Factory.StartNew(() => GetPatient(db, patient));
        //}

        //private static IList<PatientDTO> GetPatient(DbEnum nome, IPatientDTO patient)
        //{

        //    GetPatientsService serviceGet = new GetPatientsService();

        //    //Aqui eu recupero com a chave quintaDOrWorkker
        //    var result = serviceGet.GetPatientsRedis(nome, patient);

        //    return result;
        //}
    }
}
