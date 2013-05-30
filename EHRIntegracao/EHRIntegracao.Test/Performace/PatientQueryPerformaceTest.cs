using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using FizzWare.NBuilder;
using NUnit.Framework;

namespace EHRIntegracao.Test.Performace
{
    public class Paciente
    {
        public string Nome { get; set; }
    }

    [TestFixture]
    public class PatientQueryPerformaceTest
    {
        [Test]
        public void get_patient_by_criteria()
        {
            var pacientes = Builder<Paciente>.CreateListOfSize(10)
                                   .TheFirst(2)
                                   .With(x => x.Nome = "temboel")
                                   .TheNext(4)
                                   .With(x => x.Nome = "temboel do ceu")
               
                                   .Build();



            var paciente = new Paciente(){Nome = "temboel"};


            var patients = pacientes.Where(pac => PacienteValido(pac));


            Assert.AreEqual(patients.Count(), 6);

        }

        public bool PacienteValido(Paciente paciente) 
        {
            Predicate<Paciente> predicate1 = pac => pac.Nome.Contains("temboel");
  //            Predicate<Paciente> predicate2 = pac => pac.Nome.Contains("temboel do");

            IList<Predicate<Paciente>> predicates = new List<Predicate<Paciente>>();

            predicates.Add(predicate1);
  //          predicates.Add(predicate2);

            foreach (var item in predicates)
            {
                if (!item(paciente))
                    return false;
            }

            return true;
        }

        
    }
}
