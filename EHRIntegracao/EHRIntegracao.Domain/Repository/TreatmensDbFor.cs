using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db4objects.Db4o;
using EHR.CoreShared;


namespace EHRIntegracao.Domain.Repository
{
   public  class TreatmensDbFor
    {
       public virtual void inserir(IList<ITreatmentDTO> treatments)
       {
           IList<ITreatmentDTO> treatmentsLote1 = new List<ITreatmentDTO>();
           IList<ITreatmentDTO> treatmentsLote2 = new List<ITreatmentDTO>();

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

       public virtual IList<ITreatmentDTO> Todos()
       {
           IList<ITreatmentDTO> treatments = new List<ITreatmentDTO>();
           using (IObjectContainer db = Db4oEmbedded.OpenFile("TreatmentsHospital"))
           {
               var Iobject = db.QueryByExample(typeof(ITreatmentDTO));
               treatments = Iobject.Cast<ITreatmentDTO>().ToList();
           }

           return treatments;
       }
    }
}
