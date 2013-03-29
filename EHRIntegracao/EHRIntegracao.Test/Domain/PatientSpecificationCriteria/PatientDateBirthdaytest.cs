using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHRIntegracao.Domain.Domain.PatientSpecificationCriteria.PatientSpecification;
using EHRIntegracao.Domain.Services.DTO;
using EHRIntegracao.Test.Mocks;
using NHibernate;
using NHibernate.Criterion;
using NUnit.Framework;

namespace EHRIntegracao.Test.Domain.PatientSpecificationCriteria
{

    [TestFixture]
    public class PatientDateBirthdaytest
    {
        [Test]
        public void add_criteria_criterion_with_successfully()
        {
            var criterion = new Criterion();
            var dateBirthdaySpecificarion = new PatientDateBirthdayEqualsSpecification();
            dateBirthdaySpecificarion.AddCriteria(new PatientDTO() { DateBirthday = DateTime.Now.ToShortDateString() },criterion);

            Assert.AreEqual(criterion.criterions.Count(), 1);
        }
    }
}
