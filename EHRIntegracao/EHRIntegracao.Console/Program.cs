﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHRCache.Service;
using EHRIntegracao.Domain.Factorys;
using EHRIntegracao.Domain.Services;
using EHRIntegracao.Domain.Services.DTO;

namespace EHRIntegracao.Console
{
    class Program
    {
        static void Main(string[] args)
        {


            var serviceSave = new SavePatientsCacheService();
            serviceSave.Save(DbEnum.QuintaDorWorkker);


            var service = new GetPatientRedisService();
            var result = service.GetPatientByKey(DbEnum.QuintaDorWorkker);


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


            System.Console.ReadLine();
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
