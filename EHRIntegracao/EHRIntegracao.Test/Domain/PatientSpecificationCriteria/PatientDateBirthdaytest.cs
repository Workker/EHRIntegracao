using EHR.CoreShared.Entities;
using EHRIntegracao.Domain.Domain.PatientSpecificationCriteria.PatientSpecification;
using EHRIntegracao.Test.Mocks;
using NUnit.Framework;
using System;
using System.Linq;

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
            dateBirthdaySpecificarion.AddCriteria(new Patient() { DateBirthday = DateTime.Now }, criterion);

            Assert.AreEqual(criterion.criterions.Count(), 1);
        }
    }
}
