using EHR.CoreShared.Entities;
using EHRIntegracao.Domain.Repository;
using NUnit.Framework;

namespace EHRIntegracao.Test.Repository
{
    [TestFixture]
    public class HospitalsTest
    {
        [Test]
        public void a_Verify_if_get_all_hospitals_return_object()
        {
            var repository = new Hospitals();
            var hospitals = repository.All<Hospital>();
            Assert.IsNotNull(hospitals, "Lista de hospitais nula");
        }

        [Test]
        public void b_Verify_if_get_all_hospitals_return_itens()
        {
            var repository = new Hospitals();
            var hospitals = repository.All<Hospital>();
            Assert.Greater(hospitals.Count, 0, "Lista de hospitais vazia");
        }

        [Test]
        public void c_Verify_if_get_all_hospitals_cached_return_object()
        {
            var repository = new Hospitals();
            var hospitals = repository.GetAllCached();
            Assert.Greater(hospitals.Count, 0, "Lista de hospitais vazia");
        }

        [Test]
        public void b_Verify_if_get_all_hospitals_cached_return_itens()
        {
            var repository = new Hospitals();
            var hospitals = repository.GetAllCached();
            Assert.Greater(hospitals.Count, 0, "Lista de hospitais vazia");
        }
    }
}
