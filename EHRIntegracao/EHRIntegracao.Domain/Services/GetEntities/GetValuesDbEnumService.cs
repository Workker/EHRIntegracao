using EHR.CoreShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHRIntegracao.Domain.Services.GetEntities
{
    public class GetValuesDbEnumService
    {
        public  virtual  List<DbEnum> GetValues()
        {
            var dbs = Enum.GetValues(typeof(DbEnum));
            List<DbEnum> dbList = new List<DbEnum>();
            foreach (var db in dbs)
            {
                dbList.Add((DbEnum)db);
            }

            return dbList;
        }
    }
}
