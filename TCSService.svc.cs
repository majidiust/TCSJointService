using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using TCSAService.Model;

namespace TCSAService
{
       public class TCSService : ITCSService
    {

        public void InsertTraffic(string trafficId, string takenDate, string takenTime, string persianPlate, string agentCode)
        {
            try
            {
                DatabaseDataContext db = new DatabaseDataContext();
                if (db.Traffics.Count(P => P.recordId.Equals(trafficId)) == 0)
                {
                    Traffic traffic = new Traffic();
                    traffic.agentId = agentCode;
                    traffic.recordDate = takenDate;
                    traffic.recordTime = takenTime;
                    traffic.detectedPlatePersian = persianPlate;
                    traffic.insertDate = DateTime.Now;
                    traffic.state = true;
                    db.Traffics.InsertOnSubmit(traffic);
                    db.SubmitChanges();
                }
                else
                {
                    OutgoingWebResponseContext response = WebOperationContext.Current.OutgoingResponse;
                    response.StatusCode = HttpStatusCode.Found;
                    response.StatusDescription = "traffic with specific id has been added before";
                }
            }
            catch (Exception ex)
            {
                OutgoingWebResponseContext response = WebOperationContext.Current.OutgoingResponse;
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.StatusDescription = ex.Message;
            }
        }

        public void updateTraffic(string trafficId, string persianPlate)
        {
            try
            {
                DatabaseDataContext db = new DatabaseDataContext();
                if (db.Traffics.Count(P => P.recordId.Equals(trafficId)) > 0)
                {
                    Traffic traffic = db.Traffics.Single(P => P.recordId.Equals(trafficId));
                    ActionLog actionLog = new ActionLog();
                    actionLog.action = "update";
                    actionLog.date = DateTime.Now;
                    actionLog.recordId = traffic.Id ;
                    actionLog.lastValue = traffic.detectedPlatePersian;
                    db.ActionLogs.InsertOnSubmit(actionLog);
                    traffic.detectedPlatePersian = persianPlate;
                    traffic.lastModifiedDate = DateTime.Now;
                    db.SubmitChanges();
                }
                else
                {
                    OutgoingWebResponseContext response = WebOperationContext.Current.OutgoingResponse;
                    response.StatusCode = HttpStatusCode.NoContent;
                    response.StatusDescription = "traffic with specific id does not exist";
                }
            }
            catch (Exception ex)
            {
                OutgoingWebResponseContext response = WebOperationContext.Current.OutgoingResponse;
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.StatusDescription = ex.Message;
            }
        }


        public void changeTrafficStatus(string trafficId, bool status)
        {
            try
            {
                DatabaseDataContext db = new DatabaseDataContext();
                if (db.Traffics.Count(P => P.recordId.Equals(trafficId)) > 0)
                {
                    Traffic traffic = db.Traffics.Single(P => P.recordId.Equals(trafficId));
                    ActionLog actionLog = new ActionLog();
                    actionLog.action = "change state";
                    actionLog.date = DateTime.Now;
                    actionLog.recordId = traffic.Id;
                    actionLog.lastValue = String.Format("{0}", traffic.state);
                    db.ActionLogs.InsertOnSubmit(actionLog);
                    traffic.state = status;
                    traffic.lastModifiedDate = DateTime.Now;
                    db.SubmitChanges();
                }
                else
                {
                    OutgoingWebResponseContext response = WebOperationContext.Current.OutgoingResponse;
                    response.StatusCode = HttpStatusCode.NoContent;
                    response.StatusDescription = "traffic with specific id does not exist";
                }
            }
            catch (Exception ex)
            {
                OutgoingWebResponseContext response = WebOperationContext.Current.OutgoingResponse;
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.StatusDescription = ex.Message;
            }
        }
    }
}
