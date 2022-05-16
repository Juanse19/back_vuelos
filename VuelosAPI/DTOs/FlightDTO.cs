using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VuelosAPI.DTOs
{
    public class FlightDTO
    {
        public int Id { get; set; }
        public string CityOrigin { get; set; }
        public string CityDestination { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
        public string FlightNumber { get; set; }
        public int AirlineId { get; set; }
        public bool status { get; set; }
    }
}
