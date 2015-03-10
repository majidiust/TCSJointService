using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TCSAService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITCSService" in both code and config file together.
    [ServiceContract]
    public interface ITCSService
    {

        [OperationContract]
        void InsertTraffic(String trafficId, String takenDate, String takenTime, String persianPlate, String agentCode);

        [OperationContract]
        void updateTraffic(String trafficId, String persianPlate);

        [OperationContract]
        void changeTrafficStatus(String trafficId, Boolean status);
    }
}
