using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrders
{
    public interface IGateway
    {
        IEnumerable<IDatabaseEntity> SearchByName(String token);

        IDatabaseEntity Find(String id);

        DatabaseConnection.QueryStatus Delete(String id);

        DatabaseConnection.QueryStatus Insert(IDatabaseEntity obj);

        DatabaseConnection.QueryStatus Update(IDatabaseEntity obj);

        String GetNextID();
    }
}
