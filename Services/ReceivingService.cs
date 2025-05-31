using Csms_api.Helpers;
using Csms_api.Models;

namespace Csms_api.Services
{
    public class ReceivingService
    {
        public void UpdateStatus(Receiving receiving, string status)
        {
            switch (status.ToLower())
            {
                case "approve":
                    receiving.Pending = false;
                    receiving.Received = true;
                    receiving.Declined = false;
                    receiving.Dispatched = false;
                    receiving.Removed = false;
                    receiving.Date_received = TimeHelper.GetPhilippineTime();
                    break;

                case "decline":
                    receiving.Pending = false;
                    receiving.Received = false;
                    receiving.Declined = true;
                    receiving.Dispatched = false;
                    receiving.Removed = false;
                    receiving.Date_declined = TimeHelper.GetPhilippineTime();
                    break;
            }
        }
    }
}
