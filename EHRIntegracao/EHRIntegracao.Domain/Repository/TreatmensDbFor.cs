using Db4objects.Db4o;
using EHR.CoreShared.Interfaces;
using System.Collections.Generic;
using System.Linq;


namespace EHRIntegracao.Domain.Repository
{
    public class TreatmensDbFor
    {
        public virtual void inserir(IList<ITreatment> treatments)
        {
            IList<ITreatment> treatmentsLote1 = new List<ITreatment>();
            IList<ITreatment> treatmentsLote2 = new List<ITreatment>();

            for (int i = 0; i < treatments.Count / 2; i++)
            {
                treatmentsLote1.Add(treatments[i]);
            }
            for (int i = (treatments.Count / 2); i < (treatments.Count); i++)
            {
                treatmentsLote2.Add(treatments[i]);
            }

            using (IObjectContainer db = Db4oEmbedded.OpenFile("TreatmentsHospital"))
            {
                db.Store(treatmentsLote1);
            }

            using (IObjectContainer db = Db4oEmbedded.OpenFile("TreatmentsHospital"))
            {
                db.Store(treatmentsLote2);
            }
        }

        public virtual IList<ITreatment> Todos()
        {
            IList<ITreatment> treatments = new List<ITreatment>();
            using (IObjectContainer db = Db4oEmbedded.OpenFile("TreatmentsHospital"))
            {
                var Iobject = db.QueryByExample(typeof(ITreatment));
                treatments = Iobject.Cast<ITreatment>().ToList();
            }

            return treatments;
        }
    }
}
