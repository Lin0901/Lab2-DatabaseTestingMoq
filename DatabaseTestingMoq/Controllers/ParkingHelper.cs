using DatabaseTestingMoq.Data;
using DatabaseTestingMoq.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseTestingMoq.Controllers
{
    public class ParkingHelper : Controller
    {
        private readonly DatabaseTestingMoqContext db;

        public ParkingHelper(DatabaseTestingMoqContext context)
        {
            db = context;
        }
        public Pass CreatePass(string purchaser, bool premium, int capacity)
        {
            Pass newPass = new Pass(purchaser, capacity);
            newPass.Purchaser = purchaser;
            newPass.Premium = premium;
            newPass.Capacity = capacity;

            db.Passes.Add(newPass);
            db.SaveChanges();

            return newPass;
        }

        public ParkingSpot CreateParkingSpot()
        {
            ParkingSpot newSpot = new ParkingSpot();
            newSpot.Occupied = false;

            db.ParkingSpot.Add(newSpot);

            db.SaveChanges();
            return newSpot;
        }

        public void AddVehicleToPass(string passholderName, string vehicleLicence)
        {
            foreach (Vehicle vehicle in db.Vehicle)
            {
                if (vehicle.Licence == vehicleLicence)
                {
                    Pass newPass = new Pass(passholderName, 5);
                    db.Passes.Add(newPass);
                    if (newPass.Capacity.Equals(newPass.Vehicles.Count()))
                    {
                        throw new Exception();
                    }
                }
            }
            if (!db.Vehicle.Any(v => v.Licence == vehicleLicence))
            {
                throw new Exception();
            }

        }
    }
}
