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
           using (IObjectContainer db = Db4oEmbedded.OpenFile("TreatmentsHospital"))
           {
               db.Store(treatments);
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
