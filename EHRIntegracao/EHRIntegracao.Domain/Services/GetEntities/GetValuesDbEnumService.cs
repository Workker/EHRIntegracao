using EHR.CoreShared.Entities;
using EHRIntegracao.Domain.Repository;
using System.Collections.Generic;

namespace EHRIntegracao.Domain.Services.GetEntities
{
    public class GetValuesDbEnumService
    {
        public virtual IList<Hospital> GetValues()
        {
            var repository = new Hospitals();
            return repository.All<Hospital>();
        }
    }
}
