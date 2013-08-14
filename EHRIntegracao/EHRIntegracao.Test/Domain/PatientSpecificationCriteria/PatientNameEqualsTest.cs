using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHR.CoreShared;
using EHRIntegracao.Domain.Domain.PatientSpecificationCriteria.PatientSpecification;

using EHRIntegracao.Test.Mocks;
using NUnit.Framework;

namespace EHRIntegracao.Test.Domain.PatientSpecificationCriteria
{
    [TestFixture]
    public class PatientNameEqualsTest
    {
        [Test]
        public void add_criteria_criterion_with_successfully()
        {
            var criterion = new Criterion();
            var nameEqualsSpecification = new PatientNameEqualsSpecification();
            nameEqualsSpecification.AddCriteria(new Patient() { Name = "test" }, criterion);

            Assert.AreEqual(criterion.criterions.Count(), 1);
        }
    }
}
