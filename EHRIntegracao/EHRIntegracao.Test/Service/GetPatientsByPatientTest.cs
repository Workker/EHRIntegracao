using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHR.CoreShared;
using EHRIntegracao.Domain.Services.Integration;
using NUnit.Framework;

namespace EHRIntegracao.Test.Service
{
    [TestFixture]
    public class GetPatientsByPatientTest 
    {
        [Test]
        public void Get_witch_sucess() 
        {
            GetPatientsByPatient service = new GetPatientsByPatient();
            var patients = service.GetAll(new PatientDTO() { Name = "Marcelo" });

            Assert.NotNull(patients);
        }
    }
}
