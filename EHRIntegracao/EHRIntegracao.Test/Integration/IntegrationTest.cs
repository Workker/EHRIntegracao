﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHR.CoreShared;
using EHRIntegracao.Domain.Domain;
using EHRIntegracao.Domain.Factorys;
using EHRIntegracao.Domain.Repository;
using NUnit.Framework;

namespace EHRIntegracao.Test.Integration
{
    [TestFixture]
    public class IntegrationTest
    {
        [Test]
        [Ignore]
        public void IntegrarPacientesRedeDor() 
        {
            PatientRepository pacientes = new PatientRepository(FactorryNhibernate.GetSession(DbEnum.QuintaDor));
            

            var resultados = pacientes.All<Patient>();

            

            IList<Patient> patients = new List<Patient>();
            foreach (var paciente  in resultados)
            {
                patients.Add(new Patient()
                {
                    Cpf = paciente.Cpf,
                    DateBirthday = paciente.DateBirthday,
                    Identity = paciente.Identity,
                    Id = paciente.Id,
                    Name = paciente.Name
                });
            }
            pacientes.Dispose();
            resultados = null;
            var patietsRepositrory = new PatientRepository(FactorryNhibernate.GetSession(DbEnum.QuintaDor));
            patietsRepositrory.SalvarLista(patients);
        }

        [Test]
        [Ignore]
        public void SalvarEdeletarPaciente()
        {
            PatientRepository pacientes = new PatientRepository(FactorryNhibernate.GetSession(DbEnum.QuintaDor));
            var paciente = new Patient(){Id = "JK",DateBirthday =DateTime.Now,Identity="sas",Name = "javet", Cpf = "234"};

            pacientes.Save<string>(paciente);

            pacientes.Delete<string>(paciente);

        }
    }
}
